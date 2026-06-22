using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    /// <summary>
    /// Quản lý phiên đăng nhập với cơ chế tự đăng xuất khi không hoạt động.
    /// Singleton thread-safe. Dùng System.Threading.Timer để không phụ thuộc UI thread.
    /// </summary>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal sealed class SessionManager
    {
        // =============================================
        // SINGLETON
        // =============================================
        private static readonly Lazy<SessionManager> _instance =
            new(() => new SessionManager());

        public static SessionManager Instance => _instance.Value;

        private SessionManager() { }

        // =============================================
        // CẤU HÌNH (có thể thay đổi trước khi gọi Start)
        // =============================================

        /// <summary>
        /// Số giây idle trước khi hiển thị popup cảnh báo.
        /// Mặc định 90 giây (1 phút 30 giây).
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30; //đây chỉ là test thực tế phải để khoảng 30p

        /// <summary>
        /// Số giây đếm ngược trong popup trước khi tự đăng xuất.
        /// Mặc định 30 giây → tổng 2 phút.
        /// </summary>
        public int WarningSeconds { get; set; } = 30;

        // =============================================
        // TRẠNG THÁI NỘI BỘ
        // =============================================
        private System.Threading.Timer? _timer;
        private DateTime _lastActivity = DateTime.Now;
        private bool _warningShown = false;
        private volatile bool _isRunning = false;
        private Action? _onLogout;
        private Form? _ownerForm;   // form chính để marshal về UI thread

        public bool IsRunning   => _isRunning;
        public DateTime LastActivity => _lastActivity;

        // =============================================
        // LOG
        // =============================================
        private static readonly string LogDir =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static readonly object _logLock = new object();

        // =============================================
        // PUBLIC API
        // =============================================

        /// <summary>
        /// Bắt đầu theo dõi session. Gọi trong FormLoad của form chính.
        /// </summary>
        /// <param name="ownerForm">Form chính (để Invoke về UI thread khi cần).</param>
        /// <param name="onLogout">Action thực hiện đăng xuất (trên UI thread).</param>
        public void Start(Form ownerForm, Action onLogout)
        {
            Stop(); // dừng phiên cũ nếu còn tồn tại

            _ownerForm    = ownerForm;
            _onLogout     = onLogout;
            _lastActivity = DateTime.Now;
            _warningShown = false;
            _isRunning    = true;

            // Quét mỗi 5 giây để kiểm tra idle
            _timer = new System.Threading.Timer(OnTick, null,
                dueTime: 5_000, period: 5_000);

            WriteLog($"[SESSION START] User={Globals.GlobalUsername} Role={Globals.GlobalRole} " +
                     $"Timeout={TimeoutSeconds}s Warning={WarningSeconds}s");
        }

        /// <summary>
        /// Dừng theo dõi. Gọi khi form chính đóng hoặc đăng xuất thủ công.
        /// </summary>
        public void Stop()
        {
            if (!_isRunning) return;
            _isRunning = false;
            _timer?.Dispose();
            _timer = null;
            WriteLog($"[SESSION STOP] User={Globals.GlobalUsername}");
        }

        /// <summary>
        /// Reset bộ đếm idle về 0. Gọi khi phát hiện bất kỳ hoạt động nào.
        /// </summary>
        public void ResetActivity()
        {
            _lastActivity = DateTime.Now;
            _warningShown = false;   // cho phép hiện lại popup nếu idle tiếp
        }

        // =============================================
        // TIMER CALLBACK — chạy trên thread pool
        // =============================================
        private void OnTick(object? state)
        {
            if (!_isRunning || _warningShown) return;
            if (_ownerForm == null || _ownerForm.IsDisposed) return;

            double idleSeconds = (DateTime.Now - _lastActivity).TotalSeconds;

            if (idleSeconds >= TimeoutSeconds)
            {
                _warningShown = true;   // chặn hiện popup 2 lần
                WriteLog($"[WARNING] Idle {idleSeconds:F0}s — hiển thị popup cảnh báo đăng xuất");

                // Marshal về UI thread để show dialog
                try
                {
                    _ownerForm.Invoke(ShowWarningDialog);
                }
                catch (ObjectDisposedException) { /* form đã đóng */ }
                catch (InvalidOperationException) { /* handle chưa tạo  */ }
            }
        }

        /// <summary>
        /// Hiển thị popup cảnh báo countdown (chạy trên UI thread).
        /// </summary>
        private void ShowWarningDialog()
        {
            if (!_isRunning || _ownerForm == null || _ownerForm.IsDisposed) return;

            using var dlg = new f_SessionWarning(WarningSeconds);
            DialogResult result = dlg.ShowDialog(_ownerForm);

            if (result == DialogResult.OK)
            {
                // Người dùng nhấn "Tôi vẫn ở đây" → tiếp tục phiên
                ResetActivity();
                WriteLog($"[RESUMED] User={Globals.GlobalUsername} — tiếp tục phiên làm việc");
            }
            else
            {
                // Countdown hết hoặc nhấn "Đăng xuất ngay"
                WriteLog($"[TIMEOUT LOGOUT] User={Globals.GlobalUsername} — tự động đăng xuất sau {TimeoutSeconds + WarningSeconds}s idle");
                Stop();
                _onLogout?.Invoke();
            }
        }

        // =============================================
        // LOGGING — ghi vào file session_yyyy-MM-dd.log
        // =============================================
        internal static void WriteLog(string message)
        {
            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
            Debug.WriteLine("[SESSION] " + message);
            try
            {
                lock (_logLock)
                {
                    Directory.CreateDirectory(LogDir);
                    string path = Path.Combine(LogDir,
                        $"session_{DateTime.Now:yyyy-MM-dd}.log");
                    File.AppendAllText(path, line + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch { /* không để lỗi log crash app */ }
        }
    }
}
