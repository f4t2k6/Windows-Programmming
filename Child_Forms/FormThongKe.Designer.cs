namespace ProjectMonHoc
{
    partial class FormThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            lblFormSubtitle = new Label();
            btnRefresh = new Button();
            btnExportExcel = new Button();
            btnClose = new Button();
            pnlCards = new Panel();
            cardSV = new Panel();
            lblCardSVTitle = new Label();
            lblCardSVIcon = new Label();
            lblCardSVCount = new Label();
            cardMH = new Panel();
            lblCardMHTitle = new Label();
            lblCardMHIcon = new Label();
            lblCardMHCount = new Label();
            cardDiem = new Panel();
            lblCardDiemTitle = new Label();
            lblCardDiemIcon = new Label();
            lblCardDiemCount = new Label();
            cardGPA = new Panel();
            lblCardGPATitle = new Label();
            lblCardGPAIcon = new Label();
            lblCardGPAAvg = new Label();
            pnlChartArea = new Panel();
            tabControl = new TabControl();
            tabXepLoai = new TabPage();
            pnlChartXepLoai = new Panel();
            tabTopGPA = new TabPage();
            pnlChartTopGPA = new Panel();
            tabMonHoc = new TabPage();
            pnlChartMonHoc = new Panel();
            tabDangKy = new TabPage();
            pnlChartDangKy = new Panel();
            lblChartTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlCards.SuspendLayout();
            cardSV.SuspendLayout();
            cardMH.SuspendLayout();
            cardDiem.SuspendLayout();
            cardGPA.SuspendLayout();
            pnlChartArea.SuspendLayout();
            tabControl.SuspendLayout();
            tabXepLoai.SuspendLayout();
            tabTopGPA.SuspendLayout();
            tabMonHoc.SuspendLayout();
            tabDangKy.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(41, 98, 255);
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Controls.Add(lblFormSubtitle);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(btnExportExcel);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(16, 0, 16, 0);
            pnlHeader.Size = new Size(1027, 70);
            pnlHeader.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(16, 9);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(452, 37);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "THỐNG KÊ VÀ BIỂU ĐỒ SINH VIÊN";
            // 
            // lblFormSubtitle
            // 
            lblFormSubtitle.AutoSize = true;
            lblFormSubtitle.Font = new Font("Segoe UI", 9F);
            lblFormSubtitle.ForeColor = Color.FromArgb(180, 210, 255);
            lblFormSubtitle.Location = new Point(18, 44);
            lblFormSubtitle.Name = "lblFormSubtitle";
            lblFormSubtitle.Size = new Size(382, 20);
            lblFormSubtitle.TabIndex = 1;
            lblFormSubtitle.Text = "Tổng quan dữ liệu sinh viên - Chỉ dành cho HR và Admin";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(70, 120, 255);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(100, 140, 255);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1597, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 34);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Lam moi";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.BackColor = Color.FromArgb(34, 197, 94);
            btnExportExcel.Cursor = Cursors.Hand;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(1707, 18);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(110, 34);
            btnExportExcel.TabIndex = 3;
            btnExportExcel.Text = "Xuat Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(239, 68, 68);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1827, 18);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 34);
            btnClose.TabIndex = 4;
            btnClose.Text = "Dong";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlCards
            // 
            pnlCards.BackColor = Color.FromArgb(245, 247, 250);
            pnlCards.Controls.Add(cardSV);
            pnlCards.Controls.Add(cardMH);
            pnlCards.Controls.Add(cardDiem);
            pnlCards.Controls.Add(cardGPA);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 70);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(16, 12, 16, 0);
            pnlCards.Size = new Size(1027, 110);
            pnlCards.TabIndex = 1;
            // 
            // cardSV
            // 
            cardSV.BackColor = Color.White;
            cardSV.Controls.Add(lblCardSVTitle);
            cardSV.Controls.Add(lblCardSVIcon);
            cardSV.Controls.Add(lblCardSVCount);
            cardSV.Location = new Point(16, 12);
            cardSV.Name = "cardSV";
            cardSV.Size = new Size(230, 86);
            cardSV.TabIndex = 0;
            // 
            // lblCardSVTitle
            // 
            lblCardSVTitle.AutoSize = true;
            lblCardSVTitle.Font = new Font("Segoe UI", 9F);
            lblCardSVTitle.ForeColor = Color.FromArgb(100, 110, 130);
            lblCardSVTitle.Location = new Point(126, 66);
            lblCardSVTitle.Name = "lblCardSVTitle";
            lblCardSVTitle.Size = new Size(104, 20);
            lblCardSVTitle.TabIndex = 2;
            lblCardSVTitle.Text = "Tổng sinh viên";
            // 
            // lblCardSVIcon
            // 
            lblCardSVIcon.AutoSize = true;
            lblCardSVIcon.Font = new Font("Segoe UI", 20F);
            lblCardSVIcon.Location = new Point(12, 14);
            lblCardSVIcon.Name = "lblCardSVIcon";
            lblCardSVIcon.Size = new Size(59, 46);
            lblCardSVIcon.TabIndex = 0;
            lblCardSVIcon.Text = "SV";
            // 
            // lblCardSVCount
            // 
            lblCardSVCount.AutoSize = true;
            lblCardSVCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardSVCount.ForeColor = Color.FromArgb(41, 98, 255);
            lblCardSVCount.Location = new Point(77, 12);
            lblCardSVCount.Name = "lblCardSVCount";
            lblCardSVCount.Size = new Size(59, 50);
            lblCardSVCount.TabIndex = 1;
            lblCardSVCount.Text = "—";
            // 
            // cardMH
            // 
            cardMH.BackColor = Color.White;
            cardMH.Controls.Add(lblCardMHTitle);
            cardMH.Controls.Add(lblCardMHIcon);
            cardMH.Controls.Add(lblCardMHCount);
            cardMH.Location = new Point(262, 12);
            cardMH.Name = "cardMH";
            cardMH.Size = new Size(230, 86);
            cardMH.TabIndex = 1;
            // 
            // lblCardMHTitle
            // 
            lblCardMHTitle.AutoSize = true;
            lblCardMHTitle.Font = new Font("Segoe UI", 9F);
            lblCardMHTitle.ForeColor = Color.FromArgb(100, 110, 130);
            lblCardMHTitle.Location = new Point(163, 66);
            lblCardMHTitle.Name = "lblCardMHTitle";
            lblCardMHTitle.Size = new Size(67, 20);
            lblCardMHTitle.TabIndex = 2;
            lblCardMHTitle.Text = "Môn học";
            // 
            // lblCardMHIcon
            // 
            lblCardMHIcon.AutoSize = true;
            lblCardMHIcon.Font = new Font("Segoe UI", 20F);
            lblCardMHIcon.Location = new Point(12, 14);
            lblCardMHIcon.Name = "lblCardMHIcon";
            lblCardMHIcon.Size = new Size(75, 46);
            lblCardMHIcon.TabIndex = 0;
            lblCardMHIcon.Text = "MH";
            // 
            // lblCardMHCount
            // 
            lblCardMHCount.AutoSize = true;
            lblCardMHCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardMHCount.ForeColor = Color.FromArgb(34, 197, 94);
            lblCardMHCount.Location = new Point(83, 12);
            lblCardMHCount.Name = "lblCardMHCount";
            lblCardMHCount.Size = new Size(59, 50);
            lblCardMHCount.TabIndex = 1;
            lblCardMHCount.Text = "—";
            // 
            // cardDiem
            // 
            cardDiem.BackColor = Color.White;
            cardDiem.Controls.Add(lblCardDiemTitle);
            cardDiem.Controls.Add(lblCardDiemIcon);
            cardDiem.Controls.Add(lblCardDiemCount);
            cardDiem.Location = new Point(508, 12);
            cardDiem.Name = "cardDiem";
            cardDiem.Size = new Size(230, 86);
            cardDiem.TabIndex = 2;
            // 
            // lblCardDiemTitle
            // 
            lblCardDiemTitle.AutoSize = true;
            lblCardDiemTitle.Font = new Font("Segoe UI", 9F);
            lblCardDiemTitle.ForeColor = Color.FromArgb(100, 110, 130);
            lblCardDiemTitle.Location = new Point(133, 66);
            lblCardDiemTitle.Name = "lblCardDiemTitle";
            lblCardDiemTitle.Size = new Size(97, 20);
            lblCardDiemTitle.TabIndex = 2;
            lblCardDiemTitle.Text = "Bản ghi điểm";
            // 
            // lblCardDiemIcon
            // 
            lblCardDiemIcon.AutoSize = true;
            lblCardDiemIcon.Font = new Font("Segoe UI", 20F);
            lblCardDiemIcon.Location = new Point(12, 14);
            lblCardDiemIcon.Name = "lblCardDiemIcon";
            lblCardDiemIcon.Size = new Size(75, 46);
            lblCardDiemIcon.TabIndex = 0;
            lblCardDiemIcon.Text = "DM";
            // 
            // lblCardDiemCount
            // 
            lblCardDiemCount.AutoSize = true;
            lblCardDiemCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardDiemCount.ForeColor = Color.FromArgb(234, 179, 8);
            lblCardDiemCount.Location = new Point(83, 12);
            lblCardDiemCount.Name = "lblCardDiemCount";
            lblCardDiemCount.Size = new Size(59, 50);
            lblCardDiemCount.TabIndex = 1;
            lblCardDiemCount.Text = "—";
            // 
            // cardGPA
            // 
            cardGPA.BackColor = Color.White;
            cardGPA.Controls.Add(lblCardGPATitle);
            cardGPA.Controls.Add(lblCardGPAIcon);
            cardGPA.Controls.Add(lblCardGPAAvg);
            cardGPA.Location = new Point(754, 12);
            cardGPA.Name = "cardGPA";
            cardGPA.Size = new Size(230, 86);
            cardGPA.TabIndex = 3;
            // 
            // lblCardGPATitle
            // 
            lblCardGPATitle.AutoSize = true;
            lblCardGPATitle.Font = new Font("Segoe UI", 9F);
            lblCardGPATitle.ForeColor = Color.FromArgb(100, 110, 130);
            lblCardGPATitle.Location = new Point(122, 66);
            lblCardGPATitle.Name = "lblCardGPATitle";
            lblCardGPATitle.Size = new Size(108, 20);
            lblCardGPATitle.TabIndex = 2;
            lblCardGPATitle.Text = "GPA trung bình";
            // 
            // lblCardGPAIcon
            // 
            lblCardGPAIcon.AutoSize = true;
            lblCardGPAIcon.Font = new Font("Segoe UI", 20F);
            lblCardGPAIcon.Location = new Point(12, 14);
            lblCardGPAIcon.Name = "lblCardGPAIcon";
            lblCardGPAIcon.Size = new Size(62, 46);
            lblCardGPAIcon.TabIndex = 0;
            lblCardGPAIcon.Text = "GP";
            // 
            // lblCardGPAAvg
            // 
            lblCardGPAAvg.AutoSize = true;
            lblCardGPAAvg.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardGPAAvg.ForeColor = Color.FromArgb(239, 68, 68);
            lblCardGPAAvg.Location = new Point(80, 12);
            lblCardGPAAvg.Name = "lblCardGPAAvg";
            lblCardGPAAvg.Size = new Size(59, 50);
            lblCardGPAAvg.TabIndex = 1;
            lblCardGPAAvg.Text = "—";
            // 
            // pnlChartArea
            // 
            pnlChartArea.BackColor = Color.FromArgb(245, 247, 250);
            pnlChartArea.Controls.Add(tabControl);
            pnlChartArea.Controls.Add(lblChartTitle);
            pnlChartArea.Dock = DockStyle.Fill;
            pnlChartArea.Location = new Point(0, 180);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Padding = new Padding(16, 0, 16, 16);
            pnlChartArea.Size = new Size(1027, 448);
            pnlChartArea.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.Controls.Add(tabXepLoai);
            tabControl.Controls.Add(tabTopGPA);
            tabControl.Controls.Add(tabMonHoc);
            tabControl.Controls.Add(tabDangKy);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9.5F);
            tabControl.Location = new Point(16, 36);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(995, 396);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabXepLoai
            // 
            tabXepLoai.BackColor = Color.White;
            tabXepLoai.Controls.Add(pnlChartXepLoai);
            tabXepLoai.Location = new Point(4, 33);
            tabXepLoai.Name = "tabXepLoai";
            tabXepLoai.Size = new Size(987, 359);
            tabXepLoai.TabIndex = 0;
            tabXepLoai.Text = "Xếp loại";
            // 
            // pnlChartXepLoai
            // 
            pnlChartXepLoai.BackColor = Color.White;
            pnlChartXepLoai.Dock = DockStyle.Fill;
            pnlChartXepLoai.Location = new Point(0, 0);
            pnlChartXepLoai.Name = "pnlChartXepLoai";
            pnlChartXepLoai.Size = new Size(987, 359);
            pnlChartXepLoai.TabIndex = 0;
            // 
            // tabTopGPA
            // 
            tabTopGPA.BackColor = Color.White;
            tabTopGPA.Controls.Add(pnlChartTopGPA);
            tabTopGPA.Location = new Point(4, 33);
            tabTopGPA.Name = "tabTopGPA";
            tabTopGPA.Size = new Size(987, 359);
            tabTopGPA.TabIndex = 1;
            tabTopGPA.Text = "Top GPA";
            // 
            // pnlChartTopGPA
            // 
            pnlChartTopGPA.BackColor = Color.White;
            pnlChartTopGPA.Dock = DockStyle.Fill;
            pnlChartTopGPA.Location = new Point(0, 0);
            pnlChartTopGPA.Name = "pnlChartTopGPA";
            pnlChartTopGPA.Size = new Size(987, 359);
            pnlChartTopGPA.TabIndex = 0;
            // 
            // tabMonHoc
            // 
            tabMonHoc.BackColor = Color.White;
            tabMonHoc.Controls.Add(pnlChartMonHoc);
            tabMonHoc.Location = new Point(4, 33);
            tabMonHoc.Name = "tabMonHoc";
            tabMonHoc.Size = new Size(987, 359);
            tabMonHoc.TabIndex = 2;
            tabMonHoc.Text = "Điểm theo môn";
            // 
            // pnlChartMonHoc
            // 
            pnlChartMonHoc.BackColor = Color.White;
            pnlChartMonHoc.Dock = DockStyle.Fill;
            pnlChartMonHoc.Location = new Point(0, 0);
            pnlChartMonHoc.Name = "pnlChartMonHoc";
            pnlChartMonHoc.Size = new Size(987, 359);
            pnlChartMonHoc.TabIndex = 0;
            // 
            // tabDangKy
            // 
            tabDangKy.BackColor = Color.White;
            tabDangKy.Controls.Add(pnlChartDangKy);
            tabDangKy.Location = new Point(4, 33);
            tabDangKy.Name = "tabDangKy";
            tabDangKy.Size = new Size(987, 359);
            tabDangKy.TabIndex = 3;
            tabDangKy.Text = "Đăng ký môn";
            // 
            // pnlChartDangKy
            // 
            pnlChartDangKy.BackColor = Color.White;
            pnlChartDangKy.Dock = DockStyle.Fill;
            pnlChartDangKy.Location = new Point(0, 0);
            pnlChartDangKy.Name = "pnlChartDangKy";
            pnlChartDangKy.Size = new Size(987, 359);
            pnlChartDangKy.TabIndex = 0;
            // 
            // lblChartTitle
            // 
            lblChartTitle.Dock = DockStyle.Top;
            lblChartTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(30, 30, 46);
            lblChartTitle.Location = new Point(16, 0);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Padding = new Padding(0, 6, 0, 0);
            lblChartTitle.Size = new Size(995, 36);
            lblChartTitle.TabIndex = 1;
            lblChartTitle.Text = "PHÂN BỐ XẾP LOẠI HỌC LỰC";
            // 
            // FormThongKe
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1027, 628);
            Controls.Add(pnlChartArea);
            Controls.Add(pnlCards);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(900, 600);
            Name = "FormThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thong ke & Bieu do";
            Load += FormThongKe_Load_1;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCards.ResumeLayout(false);
            cardSV.ResumeLayout(false);
            cardSV.PerformLayout();
            cardMH.ResumeLayout(false);
            cardMH.PerformLayout();
            cardDiem.ResumeLayout(false);
            cardDiem.PerformLayout();
            cardGPA.ResumeLayout(false);
            cardGPA.PerformLayout();
            pnlChartArea.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabXepLoai.ResumeLayout(false);
            tabTopGPA.ResumeLayout(false);
            tabMonHoc.ResumeLayout(false);
            tabDangKy.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // ── Field declarations ───────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblFormSubtitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel cardSV;
        private System.Windows.Forms.Label lblCardSVIcon;
        private System.Windows.Forms.Label lblCardSVCount;
        private System.Windows.Forms.Label lblCardSVTitle;

        private System.Windows.Forms.Panel cardMH;
        private System.Windows.Forms.Label lblCardMHIcon;
        private System.Windows.Forms.Label lblCardMHCount;
        private System.Windows.Forms.Label lblCardMHTitle;

        private System.Windows.Forms.Panel cardDiem;
        private System.Windows.Forms.Label lblCardDiemIcon;
        private System.Windows.Forms.Label lblCardDiemCount;
        private System.Windows.Forms.Label lblCardDiemTitle;

        private System.Windows.Forms.Panel cardGPA;
        private System.Windows.Forms.Label lblCardGPAIcon;
        private System.Windows.Forms.Label lblCardGPAAvg;
        private System.Windows.Forms.Label lblCardGPATitle;

        private System.Windows.Forms.Panel pnlChartArea;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.TabControl tabControl;

        private System.Windows.Forms.TabPage tabXepLoai;
        private System.Windows.Forms.Panel pnlChartXepLoai;

        private System.Windows.Forms.TabPage tabTopGPA;
        private System.Windows.Forms.Panel pnlChartTopGPA;

        private System.Windows.Forms.TabPage tabMonHoc;
        private System.Windows.Forms.Panel pnlChartMonHoc;

        private System.Windows.Forms.TabPage tabDangKy;
        private System.Windows.Forms.Panel pnlChartDangKy;
    }
}