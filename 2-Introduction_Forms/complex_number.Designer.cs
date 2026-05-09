namespace Day01

{

    partial class complex_number

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
            RealLabel = new Label();
            ImaginaryLabel = new Label();
            RealTextBox = new TextBox();
            ImaginaryTextBox = new TextBox();
            FirstButton = new Button();
            SecondButton = new Button();
            AddButtion = new Button();
            SubstractButton = new Button();
            MultifyButton = new Button();
            StatusLabel = new Label();
            SuspendLayout();
            // 
            // RealLabel
            // 
            RealLabel.AutoSize = true;
            RealLabel.Location = new Point(106, 87);
            RealLabel.Name = "RealLabel";
            RealLabel.Size = new Size(38, 20);
            RealLabel.TabIndex = 0;
            RealLabel.Text = "Real";
            // 
            // ImaginaryLabel
            // 
            ImaginaryLabel.AutoSize = true;
            ImaginaryLabel.Location = new Point(106, 160);
            ImaginaryLabel.Name = "ImaginaryLabel";
            ImaginaryLabel.Size = new Size(75, 20);
            ImaginaryLabel.TabIndex = 1;
            ImaginaryLabel.Text = "Imaginary";
            ImaginaryLabel.Click += ImaginaryLabel_Click;
            // 
            // RealTextBox
            // 
            RealTextBox.Location = new Point(271, 80);
            RealTextBox.Name = "RealTextBox";
            RealTextBox.Size = new Size(125, 27);
            RealTextBox.TabIndex = 2;
            // 
            // ImaginaryTextBox
            // 
            ImaginaryTextBox.Location = new Point(271, 153);
            ImaginaryTextBox.Name = "ImaginaryTextBox";
            ImaginaryTextBox.Size = new Size(125, 27);
            ImaginaryTextBox.TabIndex = 3;
            // 
            // FirstButton
            // 
            FirstButton.Location = new Point(495, 83);
            FirstButton.Name = "FirstButton";
            FirstButton.Size = new Size(94, 29);
            FirstButton.TabIndex = 4;
            FirstButton.Text = "Set No 1";
            FirstButton.UseVisualStyleBackColor = true;
            // 
            // SecondButton
            // 
            SecondButton.Location = new Point(495, 151);
            SecondButton.Name = "SecondButton";
            SecondButton.Size = new Size(94, 29);
            SecondButton.TabIndex = 5;
            SecondButton.Text = "Set No 2";
            SecondButton.UseVisualStyleBackColor = true;
            // 
            // AddButtion
            // 
            AddButtion.Location = new Point(106, 254);
            AddButtion.Name = "AddButtion";
            AddButtion.Size = new Size(94, 29);
            AddButtion.TabIndex = 6;
            AddButtion.Text = "Add";
            AddButtion.UseVisualStyleBackColor = true;
            // 
            // SubstractButton
            // 
            SubstractButton.Location = new Point(291, 254);
            SubstractButton.Name = "SubstractButton";
            SubstractButton.Size = new Size(94, 29);
            SubstractButton.TabIndex = 7;
            SubstractButton.Text = "Substract";
            SubstractButton.UseVisualStyleBackColor = true;
            // 
            // MultifyButton
            // 
            MultifyButton.Location = new Point(485, 254);
            MultifyButton.Name = "MultifyButton";
            MultifyButton.Size = new Size(94, 29);
            MultifyButton.TabIndex = 8;
            MultifyButton.Text = "Multify";
            MultifyButton.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(106, 349);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(56, 20);
            StatusLabel.TabIndex = 9;
            StatusLabel.Text = "Notice:";
            StatusLabel.Click += label3_Click;
            // 
            // complex_number
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StatusLabel);
            Controls.Add(MultifyButton);
            Controls.Add(SubstractButton);
            Controls.Add(AddButtion);
            Controls.Add(SecondButton);
            Controls.Add(FirstButton);
            Controls.Add(ImaginaryTextBox);
            Controls.Add(RealTextBox);
            Controls.Add(ImaginaryLabel);
            Controls.Add(RealLabel);
            Name = "complex_number";
            Text = "Complex_number";
            Load += complex_number_Load;
            ResumeLayout(false);
            PerformLayout();

        }



        #endregion



        private Label RealLabel;

        private Label ImaginaryLabel;

        private TextBox RealTextBox;

        private TextBox ImaginaryTextBox;

        private Button FirstButton;

        private Button SecondButton;

        private Button AddButtion;

        private Button SubstractButton;

        private Button MultifyButton;

        private Label StatusLabel;

    }

}

