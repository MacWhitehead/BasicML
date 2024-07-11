namespace BasicML
{
    partial class ColorSchemePopUp
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
            HexvalueBackground = new Label();
            HexValueBackgroundInput = new TextBox();
            HexValueButtonColor = new Label();
            HexValueButtonInput = new TextBox();
            HexButtonSubmit = new Button();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // HexvalueBackground
            // 
            HexvalueBackground.AutoSize = true;
            HexvalueBackground.Location = new Point(41, 41);
            HexvalueBackground.Name = "HexvalueBackground";
            HexvalueBackground.Size = new Size(175, 15);
            HexvalueBackground.TabIndex = 0;
            HexvalueBackground.Text = "Enter hex value for background:";
            // 
            // HexValueBackgroundInput
            // 
            HexValueBackgroundInput.Location = new Point(41, 73);
            HexValueBackgroundInput.Name = "HexValueBackgroundInput";
            HexValueBackgroundInput.Size = new Size(175, 23);
            HexValueBackgroundInput.TabIndex = 1;
            // 
            // HexValueButtonColor
            // 
            HexValueButtonColor.AutoSize = true;
            HexValueButtonColor.Location = new Point(41, 144);
            HexValueButtonColor.Name = "HexValueButtonColor";
            HexValueButtonColor.Size = new Size(180, 15);
            HexValueButtonColor.TabIndex = 2;
            HexValueButtonColor.Text = "Enter hex value for button color: ";
            // 
            // HexValueButtonInput
            // 
            HexValueButtonInput.Location = new Point(41, 174);
            HexValueButtonInput.Name = "HexValueButtonInput";
            HexValueButtonInput.Size = new Size(175, 23);
            HexValueButtonInput.TabIndex = 3;
            // 
            // HexButtonSubmit
            // 
            HexButtonSubmit.Location = new Point(141, 223);
            HexButtonSubmit.Name = "HexButtonSubmit";
            HexButtonSubmit.Size = new Size(75, 23);
            HexButtonSubmit.TabIndex = 4;
            HexButtonSubmit.Text = "Submit";
            HexButtonSubmit.UseVisualStyleBackColor = true;
            HexButtonSubmit.Click += HexButtonSubmit_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(41, 223);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // ColorSchemePopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 271);
            Controls.Add(CancelBtn);
            Controls.Add(HexButtonSubmit);
            Controls.Add(HexValueButtonInput);
            Controls.Add(HexValueButtonColor);
            Controls.Add(HexValueBackgroundInput);
            Controls.Add(HexvalueBackground);
            Name = "ColorSchemePopUp";
            Text = "ColorSchemePopUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HexvalueBackground;
        private TextBox HexValueBackgroundInput;
        private Label HexValueButtonColor;
        private TextBox HexValueButtonInput;
        private Button HexButtonSubmit;
        private Button CancelBtn;
    }
}