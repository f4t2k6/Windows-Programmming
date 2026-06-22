using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using ProjectMonHoc.Classes;

namespace ProjectMonHoc.Login
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class f_FaceLogin : Form
    {
        private VideoCapture _capture;
        private CascadeClassifier _faceCascade;
        private PictureBox pbWebcam;
        private Label lblStatus;
        private Button btnCancel;
        private System.Windows.Forms.Timer _timer;

        private FaceRecognizerHelper _faceHelper;
        
        // Anti-spoof / stabilization tracking
        private string _lastRecognizedUser = "";
        private int _consecutiveRecognitions = 0;
        private const int REQUIRED_RECOGNITIONS = 5; // requires 5 consecutive matches

        public string LoggedInUsername { get; private set; } = "";

        public f_FaceLogin()
        {
            InitializeComponent();
            _faceHelper = new FaceRecognizerHelper(Path.Combine(Application.StartupPath, "TrainedFaces"));
            _faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
            
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 30; // ~33 FPS
            _timer.Tick += ProcessFrame;
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng nhập bằng khuôn mặt";
            this.Size = new Size(600, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += F_FaceLogin_FormClosing;

            pbWebcam = new PictureBox();
            pbWebcam.Size = new Size(480, 360);
            pbWebcam.Location = new Point(50, 20);
            pbWebcam.BorderStyle = BorderStyle.FixedSingle;
            pbWebcam.SizeMode = PictureBoxSizeMode.StretchImage;

            lblStatus = new Label();
            lblStatus.Text = "Đang nhận diện...";
            lblStatus.Location = new Point(50, 400);
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial", 12, FontStyle.Bold);

            btnCancel = new Button();
            btnCancel.Text = "Hủy bỏ";
            btnCancel.Location = new Point(220, 440);
            btnCancel.Size = new Size(120, 40);
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(pbWebcam);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnCancel);
        }

        private void F_FaceLogin_Load(object sender, EventArgs e)
        {
            if (_faceHelper.LabelMap.Count == 0)
            {
                MessageBox.Show("Chưa có khuôn mặt nào được đăng ký trong hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            try
            {
                _capture = new VideoCapture(0);
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
            F_FaceLogin_Load(this, EventArgs.Empty);
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
                        
                        bool faceDetectedInThisFrame = false;

                        foreach (var face in faces)
                        {
                            faceDetectedInThisFrame = true;
                            imageFrame.Draw(face, new Bgr(Color.Orange), 2);
                            
                            var faceCrop = grayFrame.Copy(face).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                            var (username, distance) = _faceHelper.Predict(faceCrop);
                            
                            // Distance < 80 is a good threshold for LBPH, > 100 is likely unknown
                            if (!string.IsNullOrEmpty(username) && distance < 80)
                            {
                                // Draw recognized info
                                CvInvoke.PutText(imageFrame, username, new Point(face.X, face.Y - 10), 
                                                 Emgu.CV.CvEnum.FontFace.HersheySimplex, 1.0, new MCvScalar(0, 255, 0), 2);
                                
                                if (username == _lastRecognizedUser)
                                {
                                    _consecutiveRecognitions++;
                                }
                                else
                                {
                                    _lastRecognizedUser = username;
                                    _consecutiveRecognitions = 1;
                                }

                                if (_consecutiveRecognitions >= REQUIRED_RECOGNITIONS)
                                {
                                    // Successful Login
                                    _timer.Stop();
                                    LoggedInUsername = username;
                                    lblStatus.Text = $"Chào mừng {username}!";
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                    return; // break out
                                }
                            }
                            else
                            {
                                // Unknown or too far
                                CvInvoke.PutText(imageFrame, "Unknown", new Point(face.X, face.Y - 10), 
                                                 Emgu.CV.CvEnum.FontFace.HersheySimplex, 1.0, new MCvScalar(0, 0, 255), 2);
                                _consecutiveRecognitions = 0;
                            }
                        }

                        if (!faceDetectedInThisFrame)
                        {
                            _consecutiveRecognitions = 0;
                        }
                    }
                    
                    if (pbWebcam.Image != null) pbWebcam.Image.Dispose();
                    pbWebcam.Image = imageFrame.ToBitmap();
                }
            }
        }

        private void F_FaceLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            if (_capture != null)
            {
                _capture.Dispose();
            }
        }
    }
}
