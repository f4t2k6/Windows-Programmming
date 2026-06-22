using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

/// <summary>
/// Logger tự động cho mọi sự kiện mở/đóng kết nối database.
/// Thread-safe, ghi ra file log theo ngày và Debug output.
/// </summary>
static class DbConnectionLogger
{
    // =============================================
    // CẤU HÌNH
    // =============================================
    private static readonly string LogDir =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

    /// <summary>Ngưỡng cảnh báo leak (giây). Mặc định 60s.</summary>
    public static int LeakThresholdSeconds { get; set; } = 60;

    // =============================================
    // THỐNG KÊ TOÀN CỤC
    // =============================================
    private static long _totalOpen;
    private static long _totalClose;
    private static long _totalLeaks;
    private static long _currentOpen;
    private static long _maxConcurrent;
    private static long _longestOpenMs;

    public static long TotalOpen      => Volatile.Read(ref _totalOpen);
    public static long TotalClose     => Volatile.Read(ref _totalClose);
    public static long TotalLeaks     => Volatile.Read(ref _totalLeaks);
    public static long CurrentOpen    => Volatile.Read(ref _currentOpen);
    public static long MaxConcurrent  => Volatile.Read(ref _maxConcurrent);
    public static long LongestOpenMs  => Volatile.Read(ref _longestOpenMs);

    // =============================================
    // TRACKING CÁC CONNECTION ĐANG MỞ
    // key = instanceId, value = thông tin mở
    // =============================================
    internal record OpenEntry(DateTime OpenedAt, string CallerInfo, int ThreadId);

    private static readonly ConcurrentDictionary<Guid, OpenEntry> _openEntries = new();

    // =============================================
    // LOCK GHI FILE
    // =============================================
    private static readonly object _fileLock = new();

    // =============================================
    // PUBLIC API
    // =============================================

    /// <summary>
    /// Ghi log khi openConnection() được gọi thành công.
    /// </summary>
    public static void LogOpen(Guid instanceId, string callerInfo)
    {
        var entry = new OpenEntry(DateTime.Now, callerInfo, Thread.CurrentThread.ManagedThreadId);
        _openEntries[instanceId] = entry;

        Interlocked.Increment(ref _totalOpen);
        long cur = Interlocked.Increment(ref _currentOpen);

        // Cập nhật max concurrent
        long prev = Volatile.Read(ref _maxConcurrent);
        while (cur > prev)
        {
            long updated = Interlocked.CompareExchange(ref _maxConcurrent, cur, prev);
            if (updated == prev) break;
            prev = updated;
        }

        Write($"[OPEN ] [inst:{Fmt(instanceId)}] [Thread:{entry.ThreadId:D2}] " +
              $"caller: {callerInfo}  (active={cur})");
    }

    /// <summary>
    /// Ghi log khi closeConnection() được gọi.
    /// </summary>
    public static void LogClose(Guid instanceId)
    {
        long durationMs = 0;
        string callerInfo = "?";

        if (_openEntries.TryRemove(instanceId, out var entry))
        {
            durationMs = (long)(DateTime.Now - entry.OpenedAt).TotalMilliseconds;
            callerInfo = entry.CallerInfo;

            // Cập nhật longest open
            long prev = Volatile.Read(ref _longestOpenMs);
            while (durationMs > prev)
            {
                long upd = Interlocked.CompareExchange(ref _longestOpenMs, durationMs, prev);
                if (upd == prev) break;
                prev = upd;
            }
        }

        Interlocked.Increment(ref _totalClose);
        long cur = Interlocked.Decrement(ref _currentOpen);

        string status = durationMs > LeakThresholdSeconds * 1000L ? "⚠️ SLOW" : "✓ OK";
        Write($"[CLOSE] [inst:{Fmt(instanceId)}] [Thread:{Thread.CurrentThread.ManagedThreadId:D2}] " +
              $"duration: {durationMs}ms  {status}  (active={Math.Max(cur, 0)})");
    }

    /// <summary>
    /// Ghi cảnh báo leak khi finalizer phát hiện connection chưa đóng.
    /// </summary>
    public static void ReportLeak(Guid instanceId, string callerInfo, DateTime openedAt)
    {
        _openEntries.TryRemove(instanceId, out _);
        Interlocked.Increment(ref _totalLeaks);
        Interlocked.Decrement(ref _currentOpen);

        double seconds = (DateTime.Now - openedAt).TotalSeconds;
        string msg = $"[⚠️ LEAK ] [inst:{Fmt(instanceId)}] " +
                     $"opened by {callerInfo} at {openedAt:HH:mm:ss.fff} — " +
                     $"open for {seconds:F1}s WITHOUT closing!";
        Write(msg);
    }

    /// <summary>
    /// Quét tất cả connection đang mở và cảnh báo nếu quá ngưỡng.
    /// Được gọi bởi DbLeakMonitor.
    /// </summary>
    public static void ScanForLeaks()
    {
        var now = DateTime.Now;
        foreach (var (id, entry) in _openEntries)
        {
            double seconds = (now - entry.OpenedAt).TotalSeconds;
            if (seconds >= LeakThresholdSeconds)
            {
                Write($"[⚠️ SLOW ] [inst:{Fmt(id)}] [Thread:{entry.ThreadId:D2}] " +
                      $"opened by {entry.CallerInfo} at {entry.OpenedAt:HH:mm:ss.fff} — " +
                      $"still open for {seconds:F1}s (threshold={LeakThresholdSeconds}s)");
            }
        }
    }

    /// <summary>
    /// Trả về chuỗi thống kê tổng quan.
    /// </summary>
    public static string GetSummary() =>
        $"=== DB Connection Summary ===\n" +
        $"  Total OPEN    : {TotalOpen}\n" +
        $"  Total CLOSE   : {TotalClose}\n" +
        $"  Unmatched     : {TotalOpen - TotalClose} (nên = 0)\n" +
        $"  Current OPEN  : {CurrentOpen}\n" +
        $"  Max Concurrent: {MaxConcurrent}\n" +
        $"  Longest Open  : {LongestOpenMs}ms\n" +
        $"  Total LEAKS   : {TotalLeaks}";

    /// <summary>
    /// Ghi summary vào log khi app kết thúc.
    /// </summary>
    public static void Flush()
    {
        Write(GetSummary());
        Write("=== Application EXIT ===\n");
    }

    // =============================================
    // INTERNAL — đọc danh sách đang mở (cho Monitor)
    // =============================================
    internal static IEnumerable<(Guid Id, OpenEntry Entry)> GetOpenEntries()
    {
        foreach (var kv in _openEntries)
            yield return (kv.Key, kv.Value);
    }

    // =============================================
    // PRIVATE HELPERS
    // =============================================

    /// <summary>Lấy 8 ký tự đầu của GUID để hiển thị ngắn gọn.</summary>
    private static string Fmt(Guid id) => id.ToString("N")[..8];

    private static void Write(string message)
    {
        string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";

        // Debug output (Visual Studio Output)
        Debug.WriteLine("[DB-LOG] " + message);

        // Ghi ra file (thread-safe)
        try
        {
            lock (_fileLock)
            {
                Directory.CreateDirectory(LogDir);
                string filePath = Path.Combine(LogDir,
                    $"db_connection_{DateTime.Now:yyyy-MM-dd}.log");
                File.AppendAllText(filePath, line + Environment.NewLine, Encoding.UTF8);
            }
        }
        catch
        {
            // Không để lỗi ghi log làm crash ứng dụng
        }
    }
}
