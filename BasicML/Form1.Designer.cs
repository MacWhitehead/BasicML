
namespace BasicML
{
    partial class FormBasicML
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.groupBox1 = new GroupBox();
			this.loggingBox = new RichTextBox();
			this.tabControl = new TabControl();
			this.tabPage1 = new TabPage();
			this.tabPage2 = new TabPage();
			this.openFileDialog = new OpenFileDialog();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new Size(784, 961);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.loggingBox);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 771);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(778, 187);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Log";
			// 
			// loggingBox
			// 
			this.loggingBox.Dock = DockStyle.Fill;
			this.loggingBox.Location = new Point(3, 19);
			this.loggingBox.Name = "loggingBox";
			this.loggingBox.ReadOnly = true;
			this.loggingBox.Size = new Size(772, 165);
			this.loggingBox.TabIndex = 1;
			this.loggingBox.Text = "";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Dock = DockStyle.Fill;
			this.tabControl.Location = new Point(3, 3);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new Size(778, 762);
			this.tabControl.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(770, 734);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new Padding(3);
			this.tabPage2.Size = new Size(770, 734);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// FormBasicML
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 961);
			Controls.Add(this.tableLayoutPanel1);
			Name = "FormBasicML";
			Text = "BasicML";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			ResumeLayout(false);
		}

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
		private OpenFileDialog openFileDialog;
		private RichTextBox loggingBox;
		private TabControl tabControl;
		private TabPage tabPage1;
		private TabPage tabPage2;
	}
}
