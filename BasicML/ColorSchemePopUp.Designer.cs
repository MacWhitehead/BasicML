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
            colorPreviewButton = new Button();
            previewBackground = new Label();
            previewButton = new Label();
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
            // colorPreviewButton
            // 
            colorPreviewButton.Location = new Point(235, 223);
            colorPreviewButton.Name = "colorPreviewButton";
            colorPreviewButton.Size = new Size(95, 23);
            colorPreviewButton.TabIndex = 6;
            colorPreviewButton.Text = "Preview Colors";
            colorPreviewButton.UseVisualStyleBackColor = true;
            colorPreviewButton.Click += colorPreviewButton_Click;
            // 
            // previewBackground
            // 
            previewBackground.AutoSize = true;
            previewBackground.Location = new Point(222, 73);
            previewBackground.Name = "previewBackground";
            previewBackground.Size = new Size(123, 15);
            previewBackground.TabIndex = 7;
            previewBackground.Text = "(Preview Background)";
            // 
            // previewButton
            // 
            previewButton.AutoSize = true;
            previewButton.Location = new Point(235, 174);
            previewButton.Name = "previewButton";
            previewButton.Size = new Size(95, 15);
            previewButton.TabIndex = 8;
            previewButton.Text = "(Preview Button)";
            // 
            // ColorSchemePopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 271);
            Controls.Add(previewButton);
            Controls.Add(previewBackground);
            Controls.Add(colorPreviewButton);
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
        private Button colorPreviewButton;
        private Label previewBackground;
        private Label previewButton;
    }
}