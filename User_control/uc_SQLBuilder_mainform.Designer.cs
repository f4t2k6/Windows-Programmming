namespace ProjectMonHoc.User_control
{
    partial class uc_SQLBuilder_mainform
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlContainer  = new System.Windows.Forms.Panel();
            lbl_Prompt    = new System.Windows.Forms.Label();
            pnlSqlBox     = new System.Windows.Forms.Panel();
            txt_SQL       = new System.Windows.Forms.RichTextBox();
            pnlButtons    = new System.Windows.Forms.Panel();
            btn_RunSQL    = new System.Windows.Forms.Button();
            btn_Copy      = new System.Windows.Forms.Button();

            pnlContainer.SuspendLayout();
            pnlSqlBox.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // ──────────────────────────────────────────
            // pnlContainer  (card tổng thể)
            // ──────────────────────────────────────────
            pnlContainer.BackColor    = System.Drawing.Color.FromArgb(30, 35, 50);
            pnlContainer.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlContainer.Controls.Add(lbl_Prompt);
            pnlContainer.Controls.Add(pnlSqlBox);
            pnlContainer.Controls.Add(pnlButtons);
            pnlContainer.Dock         = System.Windows.Forms.DockStyle.Fill;
            pnlContainer.Padding      = new System.Windows.Forms.Padding(12, 10, 12, 10);
            pnlContainer.Name         = "pnlContainer";
            pnlContainer.TabIndex     = 0;

            // ──────────────────────────────────────────
            // lbl_Prompt  (câu hỏi người dùng)
            // ──────────────────────────────────────────
            lbl_Prompt.AutoSize    = false;
            lbl_Prompt.Dock        = System.Windows.Forms.DockStyle.Top;
            lbl_Prompt.Font        = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lbl_Prompt.ForeColor   = System.Drawing.Color.FromArgb(180, 210, 255);
            lbl_Prompt.Height      = 36;
            lbl_Prompt.Name        = "lbl_Prompt";
            lbl_Prompt.Padding     = new System.Windows.Forms.Padding(2, 6, 0, 0);
            lbl_Prompt.TabIndex    = 0;
            lbl_Prompt.Text        = "🧑 (prompt)";

            // ──────────────────────────────────────────
            // pnlSqlBox  (wrapper cho RichTextBox)
            // ──────────────────────────────────────────
            pnlSqlBox.Controls.Add(txt_SQL);
            pnlSqlBox.Dock         = System.Windows.Forms.DockStyle.Top;
            pnlSqlBox.Height       = 180;
            pnlSqlBox.Name         = "pnlSqlBox";
            pnlSqlBox.Padding      = new System.Windows.Forms.Padding(0, 4, 0, 4);
            pnlSqlBox.TabIndex     = 1;

            // ──────────────────────────────────────────
            // txt_SQL  (hiển thị SQL code)
            // ──────────────────────────────────────────
            txt_SQL.BackColor      = System.Drawing.Color.FromArgb(20, 22, 34);
            txt_SQL.BorderStyle    = System.Windows.Forms.BorderStyle.None;
            txt_SQL.Dock           = System.Windows.Forms.DockStyle.Fill;
            txt_SQL.Font           = new System.Drawing.Font("Consolas", 9.5F);
            txt_SQL.ForeColor      = System.Drawing.Color.FromArgb(100, 220, 140);
            txt_SQL.Name           = "txt_SQL";
            txt_SQL.ReadOnly       = false;
            txt_SQL.ScrollBars     = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            txt_SQL.TabIndex       = 0;
            txt_SQL.WordWrap       = false;

            // ──────────────────────────────────────────
            // pnlButtons  (hàng nút bên dưới)
            // ──────────────────────────────────────────
            pnlButtons.Controls.Add(btn_RunSQL);
            pnlButtons.Controls.Add(btn_Copy);
            pnlButtons.Dock        = System.Windows.Forms.DockStyle.Top;
            pnlButtons.Height      = 44;
            pnlButtons.Name        = "pnlButtons";
            pnlButtons.TabIndex    = 2;

            // ──────────────────────────────────────────
            // btn_RunSQL
            // ──────────────────────────────────────────
            btn_RunSQL.BackColor                   = System.Drawing.Color.FromArgb(34, 130, 70);
            btn_RunSQL.Cursor                      = System.Windows.Forms.Cursors.Hand;
            btn_RunSQL.FlatAppearance.BorderSize   = 0;
            btn_RunSQL.FlatStyle                   = System.Windows.Forms.FlatStyle.Flat;
            btn_RunSQL.Font                        = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn_RunSQL.ForeColor                   = System.Drawing.Color.White;
            btn_RunSQL.Location                    = new System.Drawing.Point(0, 4);
            btn_RunSQL.Name                        = "btn_RunSQL";
            btn_RunSQL.Size                        = new System.Drawing.Size(150, 34);
            btn_RunSQL.TabIndex                    = 0;
            btn_RunSQL.Text                        = "▶ Tạo bảng";
            btn_RunSQL.UseVisualStyleBackColor      = false;
            btn_RunSQL.Click                       += btn_RunSQL_Click;

            // ──────────────────────────────────────────
            // btn_Copy
            // ──────────────────────────────────────────
            btn_Copy.BackColor                     = System.Drawing.Color.FromArgb(60, 70, 100);
            btn_Copy.Cursor                        = System.Windows.Forms.Cursors.Hand;
            btn_Copy.FlatAppearance.BorderSize     = 0;
            btn_Copy.FlatStyle                     = System.Windows.Forms.FlatStyle.Flat;
            btn_Copy.Font                          = new System.Drawing.Font("Segoe UI", 9F);
            btn_Copy.ForeColor                     = System.Drawing.Color.White;
            btn_Copy.Location                      = new System.Drawing.Point(158, 4);
            btn_Copy.Name                          = "btn_Copy";
            btn_Copy.Size                          = new System.Drawing.Size(130, 34);
            btn_Copy.TabIndex                      = 1;
            btn_Copy.Text                          = "📋 Sao chép";
            btn_Copy.UseVisualStyleBackColor        = false;
            btn_Copy.Click                         += btn_Copy_Click;

            // ──────────────────────────────────────────
            // uc_SQLBuilder_mainform  (UserControl)
            // ──────────────────────────────────────────
            AutoScaleDimensions   = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode         = System.Windows.Forms.AutoScaleMode.Font;
            BackColor             = System.Drawing.Color.FromArgb(30, 35, 50);
            Controls.Add(pnlContainer);
            Font                  = new System.Drawing.Font("Segoe UI", 10F);
            // Chiều rộng = Fill theo FlowLayoutPanel cha; chiều cao cố định
            Size                  = new System.Drawing.Size(990, 278);
            Margin                = new System.Windows.Forms.Padding(0, 0, 0, 10);
            Name                  = "uc_SQLBuilder_mainform";

            pnlContainer.ResumeLayout(false);
            pnlSqlBox.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel        pnlContainer;
        private System.Windows.Forms.Label        lbl_Prompt;
        private System.Windows.Forms.Panel        pnlSqlBox;
        private System.Windows.Forms.RichTextBox  txt_SQL;
        private System.Windows.Forms.Panel        pnlButtons;
        private System.Windows.Forms.Button       btn_RunSQL;
        private System.Windows.Forms.Button       btn_Copy;
    }
}
