
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
			this.runFromStartButton = new Button();
			this.resetButton = new Button();
			this.label1 = new Label();
			this.accumulatorTextBox = new TextBox();
			this.stepButton = new Button();
			this.runButton = new Button();
			this.reloadFileButton = new Button();
			this.fileTextBox = new TextBox();
			this.chooseFileButton = new Button();
			this.groupBox4 = new GroupBox();
			this.programOutputBox = new RichTextBox();
			this.openFileDialog = new OpenFileDialog();
			this.colorSchemeButton = new Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.memoryGrid).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 2);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
			this.tableLayoutPanel1.Size = new Size(792, 681);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.loggingBox);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 567);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(786, 111);
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
			this.loggingBox.Size = new Size(780, 89);
			this.loggingBox.TabIndex = 1;
			this.loggingBox.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.memoryGrid);
			this.groupBox2.Dock = DockStyle.Fill;
			this.groupBox2.Location = new Point(3, 118);
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
			this.memoryGrid.RightToLeft = RightToLeft.No;
			this.memoryGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.memoryGrid.RowHeadersVisible = false;
			this.memoryGrid.RowHeadersWidth = 62;
			this.memoryGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.memoryGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.memoryGrid.Size = new Size(780, 244);
			this.memoryGrid.TabIndex = 9;
			this.memoryGrid.CellContentClick += MemoryGrid_CellContentClick;
			this.memoryGrid.CellEndEdit += MemoryGrid_CellEndEdit;
			this.memoryGrid.CellMouseEnter += MemoryGrid_CellMouseEnter;
			this.memoryGrid.CellMouseLeave += MemoryGrid_CellMouseLeave;
			// 
			// memoryIndexColumn
			// 
			this.memoryIndexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.memoryIndexColumn.HeaderText = "Index";
			this.memoryIndexColumn.MinimumWidth = 8;
			this.memoryIndexColumn.Name = "memoryIndexColumn";
			this.memoryIndexColumn.ReadOnly = true;
			this.memoryIndexColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.memoryIndexColumn.Width = 42;
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
			this.startPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.startPointColumn.HeaderText = "CPU";
			this.startPointColumn.MinimumWidth = 8;
			this.startPointColumn.Name = "startPointColumn";
			this.startPointColumn.ReadOnly = true;
			this.startPointColumn.Resizable = DataGridViewTriState.True;
			this.startPointColumn.ToolTipText = "The location in memory that the CPU is at";
			this.startPointColumn.Width = 36;
			// 
			// breakPointColumn
			// 
			this.breakPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.breakPointColumn.HeaderText = "Break";
			this.breakPointColumn.MinimumWidth = 8;
			this.breakPointColumn.Name = "breakPointColumn";
			this.breakPointColumn.ReadOnly = true;
			this.breakPointColumn.Resizable = DataGridViewTriState.True;
			this.breakPointColumn.ToolTipText = "Breakpoints";
			this.breakPointColumn.Width = 42;
			// 
			// memoryAddColumn
			// 
			this.memoryAddColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.memoryAddColumn.HeaderText = "Add";
			this.memoryAddColumn.MinimumWidth = 8;
			this.memoryAddColumn.Name = "memoryAddColumn";
			this.memoryAddColumn.ReadOnly = true;
			this.memoryAddColumn.Resizable = DataGridViewTriState.True;
			this.memoryAddColumn.ToolTipText = "Adds a new element to memory";
			this.memoryAddColumn.Width = 35;
			// 
			// memoryRemoveColumn
			// 
			this.memoryRemoveColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.memoryRemoveColumn.HeaderText = "Delete";
			this.memoryRemoveColumn.MinimumWidth = 8;
			this.memoryRemoveColumn.Name = "memoryRemoveColumn";
			this.memoryRemoveColumn.ReadOnly = true;
			this.memoryRemoveColumn.Resizable = DataGridViewTriState.True;
			this.memoryRemoveColumn.ToolTipText = "Deletes an element from memory";
			this.memoryRemoveColumn.Width = 46;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.colorSchemeButton);
			this.groupBox3.Controls.Add(this.runFromStartButton);
			this.groupBox3.Controls.Add(this.resetButton);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.accumulatorTextBox);
			this.groupBox3.Controls.Add(this.stepButton);
			this.groupBox3.Controls.Add(this.runButton);
			this.groupBox3.Controls.Add(this.reloadFileButton);
			this.groupBox3.Controls.Add(this.fileTextBox);
			this.groupBox3.Controls.Add(this.chooseFileButton);
			this.groupBox3.Dock = DockStyle.Fill;
			this.groupBox3.Location = new Point(2, 2);
			this.groupBox3.Margin = new Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new Padding(2);
			this.groupBox3.Size = new Size(788, 111);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Controls";
			// 
			// runFromStartButton
			// 
			this.runFromStartButton.Location = new Point(5, 48);
			this.runFromStartButton.Name = "runFromStartButton";
			this.runFromStartButton.Size = new Size(159, 23);
			this.runFromStartButton.TabIndex = 10;
			this.runFromStartButton.Text = "Run From Start";
			this.runFromStartButton.UseVisualStyleBackColor = true;
			this.runFromStartButton.Click += RunFromStartButton_Click;
			// 
			// resetButton
			// 
			this.resetButton.Location = new Point(169, 76);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new Size(75, 23);
			this.resetButton.TabIndex = 9;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += ResetButton_Click;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI", 12F);
			this.label1.Location = new Point(638, 53);
			this.label1.Name = "label1";
			this.label1.Size = new Size(140, 21);
			this.label1.TabIndex = 8;
			this.label1.Text = "Accumulator Value";
			// 
			// accumulatorTextBox
			// 
			this.accumulatorTextBox.Location = new Point(628, 77);
			this.accumulatorTextBox.Name = "accumulatorTextBox";
			this.accumulatorTextBox.Size = new Size(156, 23);
			this.accumulatorTextBox.TabIndex = 7;
			this.accumulatorTextBox.KeyDown += AccumulatorTextBox_KeyDown;
			// 
			// stepButton
			// 
			this.stepButton.Location = new Point(86, 76);
			this.stepButton.Margin = new Padding(2);
			this.stepButton.Name = "stepButton";
			this.stepButton.Size = new Size(78, 23);
			this.stepButton.TabIndex = 6;
			this.stepButton.Text = "Step";
			this.stepButton.UseVisualStyleBackColor = true;
			this.stepButton.Click += StepButton_Click;
			// 
			// runButton
			// 
			this.runButton.Location = new Point(5, 77);
			this.runButton.Margin = new Padding(2);
			this.runButton.Name = "runButton";
			this.runButton.Size = new Size(78, 23);
			this.runButton.TabIndex = 5;
			this.runButton.Text = "Run";
			this.runButton.UseVisualStyleBackColor = true;
			this.runButton.Click += RunButton_Click;
			// 
			// reloadFileButton
			// 
			this.reloadFileButton.Location = new Point(286, 20);
			this.reloadFileButton.Margin = new Padding(2);
			this.reloadFileButton.Name = "reloadFileButton";
			this.reloadFileButton.Size = new Size(78, 23);
			this.reloadFileButton.TabIndex = 4;
			this.reloadFileButton.Text = "Reload";
			this.reloadFileButton.UseVisualStyleBackColor = true;
			this.reloadFileButton.Click += LoadFileButton_Click;
			// 
			// fileTextBox
			// 
			this.fileTextBox.Location = new Point(5, 20);
			this.fileTextBox.Margin = new Padding(2);
			this.fileTextBox.Name = "fileTextBox";
			this.fileTextBox.Size = new Size(195, 23);
			this.fileTextBox.TabIndex = 2;
			this.fileTextBox.Text = "Please Choose A FIle";
			// 
			// chooseFileButton
			// 
			this.chooseFileButton.Location = new Point(204, 20);
			this.chooseFileButton.Margin = new Padding(2);
			this.chooseFileButton.Name = "chooseFileButton";
			this.chooseFileButton.Size = new Size(78, 23);
			this.chooseFileButton.TabIndex = 3;
			this.chooseFileButton.Text = "Choose File";
			this.chooseFileButton.UseVisualStyleBackColor = true;
			this.chooseFileButton.Click += ChooseFile_Click;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.programOutputBox);
			this.groupBox4.Dock = DockStyle.Fill;
			this.groupBox4.Location = new Point(3, 390);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(786, 171);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Program Output";
			// 
			// programOutputBox
			// 
			this.programOutputBox.Dock = DockStyle.Fill;
			this.programOutputBox.Location = new Point(3, 19);
			this.programOutputBox.Name = "programOutputBox";
			this.programOutputBox.ReadOnly = true;
			this.programOutputBox.Size = new Size(780, 149);
			this.programOutputBox.TabIndex = 0;
			this.programOutputBox.Text = "";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// colorSchemeButton
			// 
			this.colorSchemeButton.Location = new Point(672, 19);
			this.colorSchemeButton.Name = "colorSchemeButton";
			this.colorSchemeButton.Size = new Size(111, 23);
			this.colorSchemeButton.TabIndex = 11;
			this.colorSchemeButton.Text = "Color Scheme";
			this.colorSchemeButton.UseVisualStyleBackColor = true;
			this.colorSchemeButton.Click += ColorSchemeButton_Click;
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
			this.groupBox4.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
		private GroupBox groupBox3;
		private TextBox fileTextBox;
		private Button chooseFileButton;
		private OpenFileDialog openFileDialog;
		private Button stepButton;
		private Button runButton;
		private Button reloadFileButton;
		private DataGridView memoryGrid;
		private RichTextBox loggingBox;
		private DataGridViewTextBoxColumn memoryIndexColumn;
		private DataGridViewTextBoxColumn memoryContentsColumn;
		private DataGridViewImageColumn startPointColumn;
		private DataGridViewImageColumn breakPointColumn;
		private DataGridViewImageColumn memoryAddColumn;
		private DataGridViewImageColumn memoryRemoveColumn;
		private Label label1;
		private TextBox accumulatorTextBox;
		private Button resetButton;
		private Button runFromStartButton;
		private GroupBox groupBox4;
		private RichTextBox programOutputBox;
		private Button colorSchemeButton;
	}
}
