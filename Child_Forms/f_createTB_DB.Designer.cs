namespace ProjectMonHoc.Child_Forms
{
    partial class f_createTB_DB
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


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flp_ChatHistory = new FlowLayoutPanel();
            txt_Prompt = new TextBox();
            btn_Send = new Button();
            SuspendLayout();
            // 
            // flp_ChatHistory
            // 
            flp_ChatHistory.AutoScroll = true;
            flp_ChatHistory.FlowDirection = FlowDirection.TopDown;
            flp_ChatHistory.Location = new Point(12, 4);
            flp_ChatHistory.Name = "flp_ChatHistory";
            flp_ChatHistory.Size = new Size(1003, 476);
            flp_ChatHistory.TabIndex = 0;
            // 
            // txt_Prompt
            // 
            txt_Prompt.Location = new Point(12, 501);
            txt_Prompt.Multiline = true;
            txt_Prompt.Name = "txt_Prompt";
            txt_Prompt.Size = new Size(831, 94);
            txt_Prompt.TabIndex = 1;
            // 
            // btn_Send
            // 
            btn_Send.Location = new Point(874, 513);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(125, 67);
            btn_Send.TabIndex = 2;
            btn_Send.Text = "Gửi yêu cầu";
            btn_Send.UseVisualStyleBackColor = true;
            btn_Send.Click += btn_Send_Click;
            // 
            // f_createTB_DB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(1027, 628);
            Controls.Add(btn_Send);
            Controls.Add(txt_Prompt);
            Controls.Add(flp_ChatHistory);
            Name = "f_createTB_DB";
            Text = "f_createTB_DB";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flp_ChatHistory;
        private TextBox txt_Prompt;
        private Button btn_Send;
    }
}