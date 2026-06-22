using System;
using System.Threading;

/// <summary>
/// Background monitor: quét định kỳ các connection đang mở,
/// cảnh báo khi bất kỳ connection nào mở quá ngưỡng thời gian.
/// </summary>
sealed class DbLeakMonitor : IDisposable
{
    // =============================================
    // SINGLETON
    // =============================================
    private static readonly Lazy<DbLeakMonitor> _lazy =
        new(() => new DbLeakMonitor(), LazyThreadSafetyMode.ExecutionAndPublication);

    public static DbLeakMonitor Instance => _lazy.Value;

    // =============================================
    // CẤU HÌNH
    // =============================================

    /// <summary>Chu kỳ quét (milliseconds). Mặc định 30 giây.</summary>
    public int ScanIntervalMs { get; set; } = 30_000;

    // =============================================
    // FIELDS
    // =============================================
    private System.Threading.Timer? _timer;
    private bool _running;
    private bool _disposed;
    private readonly object _lock = new();

    // Constructor private — dùng Instance
    private DbLeakMonitor() { }

    // =============================================
    // PUBLIC API
    // =============================================

    /// <summary>
    /// Khởi động monitor. Gọi từ Program.cs khi app bắt đầu.
    /// </summary>
    public void Start()
    {
        lock (_lock)
        {
            if (_running || _disposed) return;
            _running = true;

            _timer = new System.Threading.Timer(
                callback:  _ => Scan(),
                state:     null,
                dueTime:   ScanIntervalMs,   // lần đầu sau 30s
                period:    ScanIntervalMs);

            System.Diagnostics.Debug.WriteLine(
                $"[DbLeakMonitor] Started — scan every {ScanIntervalMs / 1000}s, " +
                $"leak threshold = {DbConnectionLogger.LeakThresholdSeconds}s");
        }
    }

    /// <summary>
    /// Dừng monitor. Gọi từ Program.cs khi app kết thúc.
    /// </summary>
    public void Stop()
    {
        lock (_lock)
        {
            if (!_running) return;
            _running = false;
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            _timer?.Dispose();
            _timer = null;

            System.Diagnostics.Debug.WriteLine("[DbLeakMonitor] Stopped.");
        }
    }

    // =============================================
    // SCAN LOGIC
    // =============================================
    private void Scan()
    {
        try
        {
            DbConnectionLogger.ScanForLeaks();
        }
        catch
        {
            // Không để exception từ scan làm crash timer
        }
    }

    // =============================================
    // IDISPOSABLE
    // =============================================
    public void Dispose()
    {
        lock (_lock)
        {
            if (_disposed) return;
            _disposed = true;
            Stop();
        }
    }
}
