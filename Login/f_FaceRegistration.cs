using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using ProjectMonHoc.Classes;

namespace ProjectMonHoc.Login
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class f_FaceRegistration : Form
    {
        private VideoCapture _capture;
        private CascadeClassifier _faceCascade;
        private PictureBox pbWebcam;
        private Button btnStartCapture;
        private Label lblStatus;
        private System.Windows.Forms.Timer _timer;

        private bool _isCapturing = false;
        private int _captureCount = 0;
        private const int MAX_CAPTURES = 30;
        private List<Image<Gray, byte>> _capturedFaces;
        
        private FaceRecognizerHelper _faceHelper;

        public f_FaceRegistration()
        {
            InitializeComponent();
            _faceHelper = new FaceRecognizerHelper(Path.Combine(Application.StartupPath, "TrainedFaces"));
            _faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
            _capturedFaces = new List<Image<Gray, byte>>();
            
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 30; // ~33 FPS
            _timer.Tick += ProcessFrame;
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng ký khuôn mặt";
            this.Size = new Size(600, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += F_FaceRegistration_FormClosing;

            pbWebcam = new PictureBox();
            pbWebcam.Size = new Size(480, 360);
            pbWebcam.Location = new Point(50, 20);
            pbWebcam.BorderStyle = BorderStyle.FixedSingle;
            pbWebcam.SizeMode = PictureBoxSizeMode.StretchImage;

            lblStatus = new Label();
            lblStatus.Text = "Chuẩn bị lấy mẫu...";
            lblStatus.Location = new Point(50, 400);
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial", 12, FontStyle.Bold);

            btnStartCapture = new Button();
            btnStartCapture.Text = "Bắt đầu lấy mẫu";
            btnStartCapture.Location = new Point(200, 440);
            btnStartCapture.Size = new Size(150, 40);
            btnStartCapture.Click += BtnStartCapture_Click;

            this.Controls.Add(pbWebcam);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnStartCapture);
        }

        private void F_FaceRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                _capture = new VideoCapture(0); // Mở webcam mặc định
                _timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Webcam: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            F_FaceRegistration_Load(this, EventArgs.Empty);
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture == null || !_capture.IsOpened) return;

            using (var frame = _capture.QueryFrame())
            {
                if (frame == null) return;
                
                using (var imageFrame = frame.ToImage<Bgr, byte>())
                {
                    using (var grayFrame = imageFrame.Convert<Gray, byte>())
                    {
                        var faces = _faceCascade.DetectMultiScale(grayFrame, 1.2, 5, Size.Empty);
                        
                        foreach (var face in faces)
                        {
                            imageFrame.Draw(face, new Bgr(Color.LimeGreen), 2);
                            
                            if (_isCapturing && _captureCount < MAX_CAPTURES)
                            {
                                var faceCrop = grayFrame.Copy(face).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                                _capturedFaces.Add(faceCrop);
                                _captureCount++;
                                
                                this.Invoke((MethodInvoker)delegate {
                                    lblStatus.Text = $"Đang lấy mẫu: {_captureCount}/{MAX_CAPTURES}";
                                });

                                if (_captureCount >= MAX_CAPTURES)
                                {
                                    _isCapturing = false;
                                    FinishRegistration();
                                }
                            }
                        }
                    }
                    
                    if (pbWebcam.Image != null) pbWebcam.Image.Dispose();
                    pbWebcam.Image = imageFrame.ToBitmap();
                }
            }
        }

        private void BtnStartCapture_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Globals.GlobalUsername))
            {
                MessageBox.Show("Chưa có thông tin phiên đăng nhập. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _capturedFaces.Clear();
            _captureCount = 0;
            _isCapturing = true;
            btnStartCapture.Enabled = false;
            lblStatus.Text = "Nhìn thẳng vào camera...";
        }

        private void FinishRegistration()
        {
            _timer.Stop();
            lblStatus.Text = "Đang huấn luyện mô hình (Training)...";
            Application.DoEvents();

            try
            {
                int labelId = Math.Abs(Globals.GlobalUsername.GetHashCode());
                _faceHelper.TrainModel(_capturedFaces, labelId, Globals.GlobalUsername);
                
                lblStatus.Text = "Đăng ký thành công!";
                MessageBox.Show("Khuôn mặt của bạn đã được ghi nhớ!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi Train: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStartCapture.Enabled = true;
                _timer.Start();
            }
        }

        private void F_FaceRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            if (_capture != null)
            {
                _capture.Dispose();
            }
        }
    }
}
