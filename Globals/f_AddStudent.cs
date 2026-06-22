using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]

    public partial class f_AddStudent : Form
    {
        public f_AddStudent()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpDob_ValueChanged(object sender, EventArgs e) { }

        private void picStudent_Click(object sender, EventArgs e) { }

        // ─── Voice Recording ──────────────────────────────────────────────────
        private WaveInEvent waveIn;
        private MemoryStream audioStream;
        private WaveFileWriter waveWriter;
        private bool isRecording = false;

        private void f_AddStudent_Load(object sender, EventArgs e)
        {
            this.Text = $"Thêm sinh viên — Thao tác bởi {Globals.GlobalUsername}";
            lblVoiceStatus.Text = "Nhấn 🎤 để bắt đầu ghi âm (tiếng Việt)";
        }

        private void btnVoiceInput_Click(object sender, EventArgs e)
        {
            if (!isRecording)
                StartRecording();
            else
                _ = StopAndTranscribeAsync(); // fire-and-forget trên UI thread
        }

        private void StartRecording()
        {
            try
            {
                audioStream = new MemoryStream();

                waveIn = new WaveInEvent
                {
                    WaveFormat = new WaveFormat(16000, 16, 1), // 16kHz mono – chuẩn cho Whisper
                    BufferMilliseconds = 100
                };

                waveWriter = new WaveFileWriter(audioStream, waveIn.WaveFormat);

                waveIn.DataAvailable += (s, ev) =>
                {
                    waveWriter.Write(ev.Buffer, 0, ev.BytesRecorded);
                };

                waveIn.StartRecording();
                isRecording = true;

                btnVoiceInput.Text = "🛑 Dừng & Nhận dạng";
                btnVoiceInput.BackColor = Color.FromArgb(231, 76, 60);
                lblVoiceStatus.Text = "🔴 Đang ghi âm... Hãy nói tiếng Việt rồi nhấn dừng!";
            }
            catch (Exception ex)
            {
                lblVoiceStatus.Text = $"❌ Lỗi mic: {ex.Message}";
            }
        }

        private async Task StopAndTranscribeAsync()
        {
            // --- Dừng ghi ---
            try { waveIn?.StopRecording(); } catch { }
            try { waveWriter?.Flush(); } catch { }

            isRecording = false;
            btnVoiceInput.Text = "🎤 Nhập bằng giọng nói";
            btnVoiceInput.BackColor = Color.FromArgb(46, 204, 113);
            lblVoiceStatus.Text = "⏳ Đang gửi lên Whisper AI...";
            btnVoiceInput.Enabled = false;

            byte[] wavBytes = audioStream?.ToArray();

            // Dọn dẹp
            try { waveIn?.Dispose(); } catch { }
            try { waveWriter?.Dispose(); } catch { }
            waveIn = null; waveWriter = null;

            if (wavBytes == null || wavBytes.Length < 44 + 3200) // < 0.1s audio
            {
                lblVoiceStatus.Text = "⚠ Không thu được âm thanh. Hãy thử lại.";
                btnVoiceInput.Enabled = true;
                return;
            }

            // --- Gửi Whisper ---
            var chatbot = new ProjectMonHoc.Classes.ChatbotService();
            var (transcribed, whisperError) = await chatbot.TranscribeAudioAsync(wavBytes);

            if (!string.IsNullOrEmpty(whisperError))
            {
                lblVoiceStatus.Text = $"❌ Lỗi Whisper: {whisperError}";
                btnVoiceInput.Enabled = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(transcribed))
            {
                lblVoiceStatus.Text = "⚠ Whisper không nhận ra giọng nói. Hãy nói to hơn.";
                btnVoiceInput.Enabled = true;
                return;
            }

            lblVoiceStatus.Text = $"📝 Whisper nghe được: \"{transcribed}\" — Đang phân tích...";

            // --- Gửi AI bóc tách ---
            var parsed = await chatbot.ParseVoiceInputAsync(transcribed);

            if (!string.IsNullOrEmpty(parsed.ErrorMessage))
            {
                lblVoiceStatus.Text = $"❌ Lỗi AI: {parsed.ErrorMessage}";
                btnVoiceInput.Enabled = true;
                return;
            }

            bool hasData = !string.IsNullOrWhiteSpace(parsed.MSSV)
                        || !string.IsNullOrWhiteSpace(parsed.Fname)
                        || !string.IsNullOrWhiteSpace(parsed.Lname);

            if (hasData)
            {
                if (!string.IsNullOrWhiteSpace(parsed.MSSV))  txtMSSV.Text  = parsed.MSSV;
                if (!string.IsNullOrWhiteSpace(parsed.Fname)) txtFname.Text = parsed.Fname;
                if (!string.IsNullOrWhiteSpace(parsed.Lname)) txtLname.Text = parsed.Lname;

                lblVoiceStatus.Text = $"✅ Đã điền: MSSV={parsed.MSSV} | Họ đệm={parsed.Fname} | Tên={parsed.Lname}";
            }
            else
            {
                lblVoiceStatus.Text = $"⚠ AI không tách được từ: \"{transcribed}\" — Hãy thử nói lại theo mẫu: \"Thêm sinh viên Nguyễn Văn A MSSV 22110001\"";
            }

            btnVoiceInput.Enabled = true;
        }


        byte[]? studentImage = null;

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                MemoryStream ms = new MemoryStream();
                picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                studentImage = ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtLname.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ MSSV và Tên!", "Cảnh báo");
                return;
            }

            if (studentImage == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh đại diện cho sinh viên!", "Cảnh báo");
                return;
            }

            Student sv = new Student(
                int.Parse(txtMSSV.Text), txtFname.Text, txtLname.Text,
                dtpDob.Value, cboGender.Text, txtPhone.Text,
                txtAddress.Text, txtHometown.Text, txtEmail.Text, studentImage);

            if (sv.AddStudent())
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
            else
                MessageBox.Show("Thêm thất bại! MSSV có thể đã tồn tại.", "Lỗi");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "Nhập MSSV";
            txtFname.Text = "Nhập họ và tên đệm";
            txtLname.Text = "Nhập tên";
            txtPhone.Text = "Nhập số điện thoại";
            txtAddress.Text = "Nhập địa chỉ";
            txtHometown.Text = "Nhập quê quán";
            txtEmail.Text = "Nhập email";
            cboGender.SelectedIndex = -1;
            dtpDob.Value = new DateTime(2008, 1, 1);
            picStudent.Image = null;
            studentImage = null;
        }

        private void txtMSSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}