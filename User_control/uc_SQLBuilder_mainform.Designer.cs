namespace ProjectMonHoc.User_control
{
    partial class uc_SQLBuilder_mainform
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Prompt = new Label();
            txt_SQLResult = new TextBox();
            btn_RunSQL = new Button();
            SuspendLayout();
            // 
            // lbl_Prompt
            // 
            lbl_Prompt.AutoSize = true;
            lbl_Prompt.BackColor = SystemColors.Info;
            lbl_Prompt.Location = new Point(137, 47);
            lbl_Prompt.MinimumSize = new Size(700, 40);
            lbl_Prompt.Name = "lbl_Prompt";
            lbl_Prompt.Size = new Size(700, 40);
            lbl_Prompt.TabIndex = 0;
            // 
            // txt_SQLResult
            // 
            txt_SQLResult.Location = new Point(137, 144);
            txt_SQLResult.Multiline = true;
            txt_SQLResult.Name = "txt_SQLResult";
            txt_SQLResult.ReadOnly = true;
            txt_SQLResult.Size = new Size(700, 191);
            txt_SQLResult.TabIndex = 1;
            // 
            // btn_RunSQL
            // 
            btn_RunSQL.Location = new Point(743, 341);
            btn_RunSQL.Name = "btn_RunSQL";
            btn_RunSQL.Size = new Size(94, 42);
            btn_RunSQL.TabIndex = 2;
            btn_RunSQL.Text = "Thực thi ";
            btn_RunSQL.UseVisualStyleBackColor = true;
            btn_RunSQL.Click += btn_RunSQL_Click;
            // 
            // uc_SQLBuilder_mainform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_RunSQL);
            Controls.Add(txt_SQLResult);
            Controls.Add(lbl_Prompt);
            Name = "uc_SQLBuilder_mainform";
            Size = new Size(950, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Prompt;
        private TextBox txt_SQLResult;
        private Button btn_RunSQL;
    }
}
