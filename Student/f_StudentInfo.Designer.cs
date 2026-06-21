namespace ProjectMonHoc
{
    partial class f_StudentInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // ===== Header Badge =====
        private System.Windows.Forms.Panel panelHeaderBadge;
        private System.Windows.Forms.Label lblHeaderBadge;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panelHeaderBadge = new Panel();
            lblHeaderBadge = new Label();
            pnlContent = new Panel();
            panelInfo = new Panel();
            lblPersonalTitle = new Label();
            sepPersonal = new Panel();
            lblMSSVCap = new Label();
            lblMSSVVal = new Label();
            lblDobCap = new Label();
            lblDobVal = new Label();
            lblGenderCap = new Label();
            lblGenderVal = new Label();
            lblContactTitle = new Label();
            sepContact = new Panel();
            lblPhoneCap = new Label();
            lblPhoneVal = new Label();
            lblEmailCap = new Label();
            lblEmailVal = new Label();
            lblAddressCap = new Label();
            lblAddressVal = new Label();
            lblHtownCap = new Label();
            lblHtownVal = new Label();
            panelAvatarCard = new Panel();
            picAvatar = new PictureBox();
            lblFullName = new Label();
            panelStatus = new Panel();
            lblStatusTitle = new Label();
            sepStatus = new Panel();
            lblPrintReqCap = new Label();
            lblPrintReqVal = new Label();
            lblPrintReqDateCap = new Label();
            lblPrintReqDateVal = new Label();
            panelChart = new Panel();
            lblChartTitle = new Label();
            sepChart = new Panel();
            chartScores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblMSSVHeader = new Label();
            label_Line = new Label();
            panelHeaderBadge.SuspendLayout();
            pnlContent.SuspendLayout();
            panelInfo.SuspendLayout();
            panelAvatarCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            panelStatus.SuspendLayout();
            panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartScores).BeginInit();
            SuspendLayout();
            // 
            // panelHeaderBadge
            // 
            panelHeaderBadge.BackColor = Color.FromArgb(22, 110, 191);
            panelHeaderBadge.Controls.Add(lblHeaderBadge);
            panelHeaderBadge.Location = new Point(13, 13);
            panelHeaderBadge.Margin = new Padding(4);
            panelHeaderBadge.Name = "panelHeaderBadge";
            panelHeaderBadge.Size = new Size(300, 69);
            panelHeaderBadge.TabIndex = 0;
            // 
            // lblHeaderBadge
            // 
            lblHeaderBadge.Font = new Font("Segoe UI", 14.5F, FontStyle.Bold);
            lblHeaderBadge.ForeColor = Color.White;
            lblHeaderBadge.Location = new Point(0, 0);
            lblHeaderBadge.Margin = new Padding(4, 0, 4, 0);
            lblHeaderBadge.Name = "lblHeaderBadge";
            lblHeaderBadge.Size = new Size(300, 69);
            lblHeaderBadge.TabIndex = 0;
            lblHeaderBadge.Text = "THÔNG TIN SINH VIÊN";
            lblHeaderBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Controls.Add(panelInfo);
            pnlContent.Controls.Add(panelAvatarCard);
            pnlContent.Controls.Add(panelStatus);
            pnlContent.Controls.Add(panelChart);
            pnlContent.Location = new Point(13, 107);
            pnlContent.Margin = new Padding(4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1594, 913);
            pnlContent.TabIndex = 1;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(lblPersonalTitle);
            panelInfo.Controls.Add(sepPersonal);
            panelInfo.Controls.Add(lblMSSVCap);
            panelInfo.Controls.Add(lblMSSVVal);
            panelInfo.Controls.Add(lblDobCap);
            panelInfo.Controls.Add(lblDobVal);
            panelInfo.Controls.Add(lblGenderCap);
            panelInfo.Controls.Add(lblGenderVal);
            panelInfo.Controls.Add(lblContactTitle);
            panelInfo.Controls.Add(sepContact);
            panelInfo.Controls.Add(lblPhoneCap);
            panelInfo.Controls.Add(lblPhoneVal);
            panelInfo.Controls.Add(lblEmailCap);
            panelInfo.Controls.Add(lblEmailVal);
            panelInfo.Controls.Add(lblAddressCap);
            panelInfo.Controls.Add(lblAddressVal);
            panelInfo.Controls.Add(lblHtownCap);
            panelInfo.Controls.Add(lblHtownVal);
            panelInfo.Location = new Point(4, 332);
            panelInfo.Margin = new Padding(4);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(800, 577);
            panelInfo.TabIndex = 2;
            panelInfo.Paint += panelInfo_Paint;
            // 
            // lblPersonalTitle
            // 
            lblPersonalTitle.AutoSize = true;
            lblPersonalTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPersonalTitle.ForeColor = Color.FromArgb(24, 54, 92);
            lblPersonalTitle.Location = new Point(31, 19);
            lblPersonalTitle.Margin = new Padding(4, 0, 4, 0);
            lblPersonalTitle.Name = "lblPersonalTitle";
            lblPersonalTitle.Size = new Size(167, 25);
            lblPersonalTitle.TabIndex = 0;
            lblPersonalTitle.Text = "Thông tin cá nhân";
            // 
            // sepPersonal
            // 
            sepPersonal.BackColor = Color.FromArgb(225, 228, 232);
            sepPersonal.Location = new Point(31, 48);
            sepPersonal.Margin = new Padding(4);
            sepPersonal.Name = "sepPersonal";
            sepPersonal.Size = new Size(862, 2);
            sepPersonal.TabIndex = 1;
            // 
            // lblMSSVCap
            // 
            lblMSSVCap.AutoSize = true;
            lblMSSVCap.Font = new Font("Segoe UI", 9F);
            lblMSSVCap.ForeColor = Color.Gray;
            lblMSSVCap.Location = new Point(31, 71);
            lblMSSVCap.Margin = new Padding(4, 0, 4, 0);
            lblMSSVCap.Name = "lblMSSVCap";
            lblMSSVCap.Size = new Size(91, 20);
            lblMSSVCap.TabIndex = 2;
            lblMSSVCap.Text = "Mã sinh viên";
            // 
            // lblMSSVVal
            // 
            lblMSSVVal.AutoSize = true;
            lblMSSVVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMSSVVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblMSSVVal.Location = new Point(320, 71);
            lblMSSVVal.Margin = new Padding(4, 0, 4, 0);
            lblMSSVVal.Name = "lblMSSVVal";
            lblMSSVVal.Size = new Size(28, 21);
            lblMSSVVal.TabIndex = 3;
            lblMSSVVal.Text = "---";
            // 
            // lblDobCap
            // 
            lblDobCap.AutoSize = true;
            lblDobCap.Font = new Font("Segoe UI", 9F);
            lblDobCap.ForeColor = Color.Gray;
            lblDobCap.Location = new Point(31, 135);
            lblDobCap.Margin = new Padding(4, 0, 4, 0);
            lblDobCap.Name = "lblDobCap";
            lblDobCap.Size = new Size(74, 20);
            lblDobCap.TabIndex = 8;
            lblDobCap.Text = "Ngày sinh";
            // 
            // lblDobVal
            // 
            lblDobVal.AutoSize = true;
            lblDobVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDobVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblDobVal.Location = new Point(320, 134);
            lblDobVal.Margin = new Padding(4, 0, 4, 0);
            lblDobVal.Name = "lblDobVal";
            lblDobVal.Size = new Size(28, 21);
            lblDobVal.TabIndex = 9;
            lblDobVal.Text = "---";
            // 
            // lblGenderCap
            // 
            lblGenderCap.AutoSize = true;
            lblGenderCap.Font = new Font("Segoe UI", 9F);
            lblGenderCap.ForeColor = Color.Gray;
            lblGenderCap.Location = new Point(31, 201);
            lblGenderCap.Margin = new Padding(4, 0, 4, 0);
            lblGenderCap.Name = "lblGenderCap";
            lblGenderCap.Size = new Size(65, 20);
            lblGenderCap.TabIndex = 10;
            lblGenderCap.Text = "Giới tính";
            // 
            // lblGenderVal
            // 
            lblGenderVal.AutoSize = true;
            lblGenderVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGenderVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblGenderVal.Location = new Point(320, 200);
            lblGenderVal.Margin = new Padding(4, 0, 4, 0);
            lblGenderVal.Name = "lblGenderVal";
            lblGenderVal.Size = new Size(28, 21);
            lblGenderVal.TabIndex = 11;
            lblGenderVal.Text = "---";
            // 
            // lblContactTitle
            // 
            lblContactTitle.AutoSize = true;
            lblContactTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblContactTitle.ForeColor = Color.FromArgb(24, 54, 92);
            lblContactTitle.Location = new Point(31, 258);
            lblContactTitle.Margin = new Padding(4, 0, 4, 0);
            lblContactTitle.Name = "lblContactTitle";
            lblContactTitle.Size = new Size(157, 25);
            lblContactTitle.TabIndex = 12;
            lblContactTitle.Text = "Thông tin liên hệ";
            // 
            // sepContact
            // 
            sepContact.BackColor = Color.FromArgb(225, 228, 232);
            sepContact.Location = new Point(31, 287);
            sepContact.Margin = new Padding(4);
            sepContact.Name = "sepContact";
            sepContact.Size = new Size(862, 2);
            sepContact.TabIndex = 13;
            // 
            // lblPhoneCap
            // 
            lblPhoneCap.AutoSize = true;
            lblPhoneCap.Font = new Font("Segoe UI", 9F);
            lblPhoneCap.ForeColor = Color.Gray;
            lblPhoneCap.Location = new Point(31, 313);
            lblPhoneCap.Margin = new Padding(4, 0, 4, 0);
            lblPhoneCap.Name = "lblPhoneCap";
            lblPhoneCap.Size = new Size(97, 20);
            lblPhoneCap.TabIndex = 14;
            lblPhoneCap.Text = "Số điện thoại";
            // 
            // lblPhoneVal
            // 
            lblPhoneVal.AutoSize = true;
            lblPhoneVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPhoneVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblPhoneVal.Location = new Point(320, 312);
            lblPhoneVal.Margin = new Padding(4, 0, 4, 0);
            lblPhoneVal.Name = "lblPhoneVal";
            lblPhoneVal.Size = new Size(28, 21);
            lblPhoneVal.TabIndex = 15;
            lblPhoneVal.Text = "---";
            // 
            // lblEmailCap
            // 
            lblEmailCap.AutoSize = true;
            lblEmailCap.Font = new Font("Segoe UI", 9F);
            lblEmailCap.ForeColor = Color.Gray;
            lblEmailCap.Location = new Point(31, 359);
            lblEmailCap.Margin = new Padding(4, 0, 4, 0);
            lblEmailCap.Name = "lblEmailCap";
            lblEmailCap.Size = new Size(46, 20);
            lblEmailCap.TabIndex = 16;
            lblEmailCap.Text = "Email";
            // 
            // lblEmailVal
            // 
            lblEmailVal.AutoSize = true;
            lblEmailVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmailVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblEmailVal.Location = new Point(320, 358);
            lblEmailVal.Margin = new Padding(4, 0, 4, 0);
            lblEmailVal.Name = "lblEmailVal";
            lblEmailVal.Size = new Size(28, 21);
            lblEmailVal.TabIndex = 17;
            lblEmailVal.Text = "---";
            // 
            // lblAddressCap
            // 
            lblAddressCap.AutoSize = true;
            lblAddressCap.Font = new Font("Segoe UI", 9F);
            lblAddressCap.ForeColor = Color.Gray;
            lblAddressCap.Location = new Point(31, 467);
            lblAddressCap.Margin = new Padding(4, 0, 4, 0);
            lblAddressCap.Name = "lblAddressCap";
            lblAddressCap.Size = new Size(55, 20);
            lblAddressCap.TabIndex = 18;
            lblAddressCap.Text = "Địa chỉ";
            // 
            // lblAddressVal
            // 
            lblAddressVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAddressVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblAddressVal.Location = new Point(320, 467);
            lblAddressVal.Margin = new Padding(4, 0, 4, 0);
            lblAddressVal.Name = "lblAddressVal";
            lblAddressVal.Size = new Size(407, 78);
            lblAddressVal.TabIndex = 19;
            lblAddressVal.Text = "---";
            // 
            // lblHtownCap
            // 
            lblHtownCap.AutoSize = true;
            lblHtownCap.Font = new Font("Segoe UI", 9F);
            lblHtownCap.ForeColor = Color.Gray;
            lblHtownCap.Location = new Point(31, 409);
            lblHtownCap.Margin = new Padding(4, 0, 4, 0);
            lblHtownCap.Name = "lblHtownCap";
            lblHtownCap.Size = new Size(73, 20);
            lblHtownCap.TabIndex = 20;
            lblHtownCap.Text = "Quê quán";
            // 
            // lblHtownVal
            // 
            lblHtownVal.AutoSize = true;
            lblHtownVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblHtownVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblHtownVal.Location = new Point(320, 408);
            lblHtownVal.Margin = new Padding(4, 0, 4, 0);
            lblHtownVal.Name = "lblHtownVal";
            lblHtownVal.Size = new Size(28, 21);
            lblHtownVal.TabIndex = 21;
            lblHtownVal.Text = "---";
            // 
            // panelAvatarCard
            // 
            panelAvatarCard.BackColor = Color.White;
            panelAvatarCard.BorderStyle = BorderStyle.FixedSingle;
            panelAvatarCard.Controls.Add(picAvatar);
            panelAvatarCard.Controls.Add(lblFullName);
            panelAvatarCard.Location = new Point(4, 4);
            panelAvatarCard.Margin = new Padding(4);
            panelAvatarCard.Name = "panelAvatarCard";
            panelAvatarCard.Size = new Size(800, 320);
            panelAvatarCard.TabIndex = 0;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(245, 247, 250);
            picAvatar.Location = new Point(320, 36);
            picAvatar.Margin = new Padding(4);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(150, 150);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            picAvatar.Click += picAvatar_Click;
            picAvatar.Paint += picAvatar_Paint;
            picAvatar.Resize += picAvatar_Resize;
            // 
            // lblFullName
            // 
            lblFullName.Font = new Font("Segoe UI", 13F);
            lblFullName.ForeColor = Color.FromArgb(40, 40, 40);
            lblFullName.Location = new Point(4, 202);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(790, 50);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ và tên";
            lblFullName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.White;
            panelStatus.BorderStyle = BorderStyle.FixedSingle;
            panelStatus.Controls.Add(lblStatusTitle);
            panelStatus.Controls.Add(sepStatus);
            panelStatus.Controls.Add(lblPrintReqCap);
            panelStatus.Controls.Add(lblPrintReqVal);
            panelStatus.Controls.Add(lblPrintReqDateCap);
            panelStatus.Controls.Add(lblPrintReqDateVal);
            panelStatus.Location = new Point(812, 4);
            panelStatus.Margin = new Padding(4);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(778, 320);
            panelStatus.TabIndex = 1;
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatusTitle.ForeColor = Color.FromArgb(24, 54, 92);
            lblStatusTitle.Location = new Point(31, 19);
            lblStatusTitle.Margin = new Padding(4, 0, 4, 0);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(224, 25);
            lblStatusTitle.TabIndex = 0;
            lblStatusTitle.Text = "Trạng thái yêu cầu in ấn";
            // 
            // sepStatus
            // 
            sepStatus.BackColor = Color.FromArgb(225, 228, 232);
            sepStatus.Location = new Point(31, 69);
            sepStatus.Margin = new Padding(4);
            sepStatus.Name = "sepStatus";
            sepStatus.Size = new Size(862, 2);
            sepStatus.TabIndex = 1;
            // 
            // lblPrintReqCap
            // 
            lblPrintReqCap.AutoSize = true;
            lblPrintReqCap.Font = new Font("Segoe UI", 9F);
            lblPrintReqCap.ForeColor = Color.Gray;
            lblPrintReqCap.Location = new Point(31, 110);
            lblPrintReqCap.Margin = new Padding(4, 0, 4, 0);
            lblPrintReqCap.Name = "lblPrintReqCap";
            lblPrintReqCap.Size = new Size(129, 20);
            lblPrintReqCap.TabIndex = 2;
            lblPrintReqCap.Text = "Trạng thái yêu cầu";
            // 
            // lblPrintReqVal
            // 
            lblPrintReqVal.AutoSize = true;
            lblPrintReqVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPrintReqVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblPrintReqVal.Location = new Point(450, 110);
            lblPrintReqVal.Margin = new Padding(4, 0, 4, 0);
            lblPrintReqVal.Name = "lblPrintReqVal";
            lblPrintReqVal.Size = new Size(28, 21);
            lblPrintReqVal.TabIndex = 3;
            lblPrintReqVal.Text = "---";
            // 
            // lblPrintReqDateCap
            // 
            lblPrintReqDateCap.AutoSize = true;
            lblPrintReqDateCap.Font = new Font("Segoe UI", 9F);
            lblPrintReqDateCap.ForeColor = Color.Gray;
            lblPrintReqDateCap.Location = new Point(31, 190);
            lblPrintReqDateCap.Margin = new Padding(4, 0, 4, 0);
            lblPrintReqDateCap.Name = "lblPrintReqDateCap";
            lblPrintReqDateCap.Size = new Size(98, 20);
            lblPrintReqDateCap.TabIndex = 4;
            lblPrintReqDateCap.Text = "Ngày yêu cầu";
            // 
            // lblPrintReqDateVal
            // 
            lblPrintReqDateVal.AutoSize = true;
            lblPrintReqDateVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPrintReqDateVal.ForeColor = Color.FromArgb(40, 40, 40);
            lblPrintReqDateVal.Location = new Point(450, 190);
            lblPrintReqDateVal.Margin = new Padding(4, 0, 4, 0);
            lblPrintReqDateVal.Name = "lblPrintReqDateVal";
            lblPrintReqDateVal.Size = new Size(28, 21);
            lblPrintReqDateVal.TabIndex = 5;
            lblPrintReqDateVal.Text = "---";
            // 
            // panelChart
            // 
            panelChart.BackColor = Color.White;
            panelChart.BorderStyle = BorderStyle.FixedSingle;
            panelChart.Controls.Add(lblChartTitle);
            panelChart.Controls.Add(sepChart);
            panelChart.Controls.Add(chartScores);
            panelChart.Location = new Point(812, 332);
            panelChart.Margin = new Padding(4);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(778, 577);
            panelChart.TabIndex = 3;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(24, 54, 92);
            lblChartTitle.Location = new Point(4, 9);
            lblChartTitle.Margin = new Padding(4, 0, 4, 0);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(236, 25);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Biểu đồ điểm các môn học";
            // 
            // sepChart
            // 
            sepChart.BackColor = Color.FromArgb(225, 228, 232);
            sepChart.Location = new Point(4, 48);
            sepChart.Margin = new Padding(4);
            sepChart.Name = "sepChart";
            sepChart.Size = new Size(862, 2);
            sepChart.TabIndex = 1;
            // 
            // chartScores
            // 
            chartArea1.AxisX.Title = "Môn học";
            chartArea1.AxisY.Interval = 1D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Điểm TK";
            chartArea1.Name = "ChartArea1";
            chartScores.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartScores.Legends.Add(legend1);
            chartScores.Location = new Point(4, 70);
            chartScores.Margin = new Padding(4);
            chartScores.Name = "chartScores";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Điểm tổng kết";
            chartScores.Series.Add(series1);
            chartScores.Size = new Size(768, 501);
            chartScores.TabIndex = 2;
            chartScores.Text = "chartScores";
            chartScores.Click += chartScores_Click;
            // 
            // lblMSSVHeader
            // 
            lblMSSVHeader.AutoSize = true;
            lblMSSVHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMSSVHeader.ForeColor = Color.FromArgb(120, 120, 120);
            lblMSSVHeader.Location = new Point(0, 0);
            lblMSSVHeader.Name = "lblMSSVHeader";
            lblMSSVHeader.Size = new Size(81, 22);
            lblMSSVHeader.TabIndex = 2;
            lblMSSVHeader.Text = "MSSV: ---";
            lblMSSVHeader.Visible = false;
            // 
            // label_Line
            // 
            label_Line.BackColor = Color.FromArgb(22, 110, 191);
            label_Line.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Line.ForeColor = Color.White;
            label_Line.Location = new Point(-2, 90);
            label_Line.Margin = new Padding(4, 0, 4, 0);
            label_Line.Name = "label_Line";
            label_Line.Size = new Size(1623, 2);
            label_Line.TabIndex = 23;
            // 
            // f_StudentInfo
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1620, 1033);
            Controls.Add(label_Line);
            Controls.Add(pnlContent);
            Controls.Add(panelHeaderBadge);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "f_StudentInfo";
            StartPosition = FormStartPosition.Manual;
            Text = "Thông tin sinh viên";
            Load += f_StudentInfo_Load;
            panelHeaderBadge.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelAvatarCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            panelStatus.ResumeLayout(false);
            panelStatus.PerformLayout();
            panelChart.ResumeLayout(false);
            panelChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartScores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Top-left
        private Panel panelAvatarCard;
        private PictureBox picAvatar;
        private Label lblFullName;
        private Label lblMSSVHeader;

        // Top-right
        private Panel panelStatus;
        private Label lblStatusTitle;
        private Panel sepStatus;
        private Label lblPrintReqCap;
        private Label lblPrintReqVal;
        private Label lblPrintReqDateCap;
        private Label lblPrintReqDateVal;

        // Bottom-left (merged personal + contact)
        private Panel panelInfo;
        private Label lblPersonalTitle;
        private Panel sepPersonal;
        private Label lblMSSVCap;
        private Label lblMSSVVal;
        private Label lblDobCap;
        private Label lblDobVal;
        private Label lblGenderCap;
        private Label lblGenderVal;
        private Label lblContactTitle;
        private Panel sepContact;
        private Label lblPhoneCap;
        private Label lblPhoneVal;
        private Label lblEmailCap;
        private Label lblEmailVal;
        private Label lblAddressCap;
        private Label lblAddressVal;
        private Label lblHtownCap;
        private Label lblHtownVal;

        // Bottom-right (score chart)
        private Panel panelChart;
        private Label lblChartTitle;
        private Panel sepChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScores;

        // Content container
        private Panel pnlContent;
        private Label label_Line;
    }
}