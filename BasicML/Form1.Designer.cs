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
			this.groupBox2 = new GroupBox();
			this.memoryGrid = new DataGridView();
			this.memoryIndexColumn = new DataGridViewTextBoxColumn();
			this.memoryContentsColumn = new DataGridViewTextBoxColumn();
			this.startPointColumn = new DataGridViewImageColumn();
			this.breakPointColumn = new DataGridViewImageColumn();
			this.memoryAddColumn = new DataGridViewImageColumn();
			this.memoryRemoveColumn = new DataGridViewImageColumn();
			this.groupBox3 = new GroupBox();
			this.stepButton = new Button();
			this.runButton = new Button();
			this.loadFileButton = new Button();
			this.fileTextBox = new TextBox();
			this.chooseFile = new Button();
			this.openFileDialog = new OpenFileDialog();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.memoryGrid).BeginInit();
			this.groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
			this.tableLayoutPanel1.Size = new Size(792, 681);
			this.tableLayoutPanel1.TabIndex = 0;
			this.tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.loggingBox);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 411);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(786, 267);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Log";
			// 
			// loggingBox
			// 
			this.loggingBox.Dock = DockStyle.Fill;
			this.loggingBox.Location = new Point(3, 19);
			this.loggingBox.Name = "loggingBox";
			this.loggingBox.Size = new Size(780, 245);
			this.loggingBox.TabIndex = 1;
			this.loggingBox.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.memoryGrid);
			this.groupBox2.Dock = DockStyle.Fill;
			this.groupBox2.Location = new Point(3, 139);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(786, 266);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Memory";
			// 
			// memoryGrid
			// 
			this.memoryGrid.AllowUserToDeleteRows = false;
			this.memoryGrid.AllowUserToResizeColumns = false;
			this.memoryGrid.AllowUserToResizeRows = false;
			this.memoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.memoryGrid.Columns.AddRange(new DataGridViewColumn[] { this.memoryIndexColumn, this.memoryContentsColumn, this.startPointColumn, this.breakPointColumn, this.memoryAddColumn, this.memoryRemoveColumn });
			this.memoryGrid.Dock = DockStyle.Fill;
			this.memoryGrid.Location = new Point(3, 19);
			this.memoryGrid.Margin = new Padding(2);
			this.memoryGrid.MultiSelect = false;
			this.memoryGrid.Name = "memoryGrid";
			this.memoryGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.memoryGrid.RowHeadersVisible = false;
			this.memoryGrid.RowHeadersWidth = 62;
			this.memoryGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.memoryGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.memoryGrid.Size = new Size(780, 244);
			this.memoryGrid.TabIndex = 9;
			this.memoryGrid.CellContentClick += memoryGrid_CellContentClick;
			this.memoryGrid.CellEndEdit += memoryGrid_CellEndEdit;
			this.memoryGrid.CellMouseEnter += memoryGrid_CellMouseEnter;
			this.memoryGrid.CellMouseLeave += memoryGrid_CellMouseLeave;

			// 
			// memoryIndexColumn
			// 
			this.memoryIndexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.memoryIndexColumn.HeaderText = "Index";
			this.memoryIndexColumn.MinimumWidth = 8;
			this.memoryIndexColumn.Name = "memoryIndexColumn";
			this.memoryIndexColumn.ReadOnly = true;
			this.memoryIndexColumn.Width = 50;
			// 
			// memoryContentsColumn
			// 
			this.memoryContentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.memoryContentsColumn.HeaderText = "Memory Contents";
			this.memoryContentsColumn.MinimumWidth = 8;
			this.memoryContentsColumn.Name = "memoryContentsColumn";
			// 
			// startPointColumn
			// 
			this.startPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.startPointColumn.HeaderText = "CPU";
			this.startPointColumn.MinimumWidth = 8;
			this.startPointColumn.Name = "startPointColumn";
			this.startPointColumn.ReadOnly = true;
			this.startPointColumn.Resizable = DataGridViewTriState.True;
			this.startPointColumn.SortMode = DataGridViewColumnSortMode.Automatic;
			this.startPointColumn.ToolTipText = "The location in memory that the CPU is at";
			this.startPointColumn.Width = 50;
			// 
			// breakPointColumn
			// 
			this.breakPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.breakPointColumn.HeaderText = "Break";
			this.breakPointColumn.MinimumWidth = 8;
			this.breakPointColumn.Name = "breakPointColumn";
			this.breakPointColumn.ReadOnly = true;
			this.breakPointColumn.Resizable = DataGridViewTriState.True;
			this.breakPointColumn.SortMode = DataGridViewColumnSortMode.Automatic;
			this.breakPointColumn.ToolTipText = "Breakpoints";
			this.breakPointColumn.Width = 50;
			// 
			// memoryAddColumn
			// 
			this.memoryAddColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.memoryAddColumn.HeaderText = "Add";
			this.memoryAddColumn.MinimumWidth = 8;
			this.memoryAddColumn.Name = "memoryAddColumn";
			this.memoryAddColumn.ReadOnly = true;
			this.memoryAddColumn.Resizable = DataGridViewTriState.True;
			this.memoryAddColumn.SortMode = DataGridViewColumnSortMode.Automatic;
			this.memoryAddColumn.ToolTipText = "Adds a new element to memory";
			this.memoryAddColumn.Width = 50;
			// 
			// memoryRemoveColumn
			// 
			this.memoryRemoveColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			this.memoryRemoveColumn.HeaderText = "Delete";
			this.memoryRemoveColumn.MinimumWidth = 8;
			this.memoryRemoveColumn.Name = "memoryRemoveColumn";
			this.memoryRemoveColumn.ReadOnly = true;
			this.memoryRemoveColumn.Resizable = DataGridViewTriState.True;
			this.memoryRemoveColumn.SortMode = DataGridViewColumnSortMode.Automatic;
			this.memoryRemoveColumn.ToolTipText = "Deletes an element from memory";
			this.memoryRemoveColumn.Width = 50;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.stepButton);
			this.groupBox3.Controls.Add(this.runButton);
			this.groupBox3.Controls.Add(this.loadFileButton);
			this.groupBox3.Controls.Add(this.fileTextBox);
			this.groupBox3.Controls.Add(this.chooseFile);
			this.groupBox3.Dock = DockStyle.Fill;
			this.groupBox3.Location = new Point(2, 2);
			this.groupBox3.Margin = new Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new Padding(2);
			this.groupBox3.Size = new Size(788, 132);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Controls";
			this.groupBox3.Enter += groupBox3_Enter;
			// 
			// stepButton
			// 
			this.stepButton.Location = new Point(86, 100);
			this.stepButton.Margin = new Padding(2);
			this.stepButton.Name = "stepButton";
			this.stepButton.Size = new Size(78, 23);
			this.stepButton.TabIndex = 6;
			this.stepButton.Text = "Step";
			this.stepButton.UseVisualStyleBackColor = true;
			this.stepButton.Click += stepButton_Click;
			// 
			// runButton
			// 
			this.runButton.Location = new Point(4, 100);
			this.runButton.Margin = new Padding(2);
			this.runButton.Name = "runButton";
			this.runButton.Size = new Size(78, 23);
			this.runButton.TabIndex = 5;
			this.runButton.Text = "Run";
			this.runButton.UseVisualStyleBackColor = true;
			this.runButton.Click += runButton_Click;
			// 
			// loadFileButton
			// 
			this.loadFileButton.Location = new Point(285, 36);
			this.loadFileButton.Margin = new Padding(2);
			this.loadFileButton.Name = "loadFileButton";
			this.loadFileButton.Size = new Size(78, 23);
			this.loadFileButton.TabIndex = 4;
			this.loadFileButton.Text = "Load";
			this.loadFileButton.UseVisualStyleBackColor = true;
			this.loadFileButton.Click += loadFileButton_Click;
			// 
			// fileTextBox
			// 
			this.fileTextBox.Location = new Point(4, 36);
			this.fileTextBox.Margin = new Padding(2);
			this.fileTextBox.Name = "fileTextBox";
			this.fileTextBox.Size = new Size(195, 23);
			this.fileTextBox.TabIndex = 2;
			this.fileTextBox.Text = "Please Choose A FIle";
			// 
			// chooseFile
			// 
			this.chooseFile.Location = new Point(203, 36);
			this.chooseFile.Margin = new Padding(2);
			this.chooseFile.Name = "chooseFile";
			this.chooseFile.Size = new Size(78, 23);
			this.chooseFile.TabIndex = 3;
			this.chooseFile.Text = "Choose File";
			this.chooseFile.UseVisualStyleBackColor = true;
			this.chooseFile.Click += chooseFile_Click;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// FormBasicML
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(792, 681);
			Controls.Add(this.tableLayoutPanel1);
			Name = "FormBasicML";
			Text = "BasicML";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.memoryGrid).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
		private GroupBox groupBox3;
		private TextBox fileTextBox;
		private Button chooseFile;
		private OpenFileDialog openFileDialog;
		private Button stepButton;
		private Button runButton;
		private Button loadFileButton;
		private DataGridView memoryGrid;
		private RichTextBox loggingBox;
		private DataGridViewTextBoxColumn memoryIndexColumn;
		private DataGridViewTextBoxColumn memoryContentsColumn;
		private DataGridViewImageColumn startPointColumn;
		private DataGridViewImageColumn breakPointColumn;
		private DataGridViewImageColumn memoryAddColumn;
		private DataGridViewImageColumn memoryRemoveColumn;
	}
}
