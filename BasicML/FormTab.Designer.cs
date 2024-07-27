namespace BasicML
{
	partial class FormTab
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
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.memoryGroupBox = new GroupBox();
			this.memoryGrid = new DataGridView();
			this.memoryIndexColumn = new DataGridViewTextBoxColumn();
			this.memoryContentsColumn = new DataGridViewTextBoxColumn();
			this.startPointColumn = new DataGridViewImageColumn();
			this.breakPointColumn = new DataGridViewImageColumn();
			this.memoryAddColumn = new DataGridViewImageColumn();
			this.memoryRemoveColumn = new DataGridViewImageColumn();
			this.groupBoxOfCoolness = new GroupBox();
			this.removeTabButton = new Button();
			this.addTabButton = new Button();
			this.chooseFile6Button = new Button();
			this.saveAsButton = new Button();
			this.colorSchemeButton = new Button();
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
			this.tableLayoutPanel1.SuspendLayout();
			this.memoryGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.memoryGrid).BeginInit();
			this.groupBoxOfCoolness.SuspendLayout();
			this.groupBox4.SuspendLayout();
			SuspendLayout();
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.memoryGroupBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBoxOfCoolness, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 2);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.60606F));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 39.39394F));
			this.tableLayoutPanel1.Size = new Size(1143, 1250);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// memoryGroupBox
			// 
			this.memoryGroupBox.Controls.Add(this.memoryGrid);
			this.memoryGroupBox.Dock = DockStyle.Fill;
			this.memoryGroupBox.Location = new Point(4, 255);
			this.memoryGroupBox.Margin = new Padding(4, 5, 4, 5);
			this.memoryGroupBox.Name = "memoryGroupBox";
			this.memoryGroupBox.Padding = new Padding(4, 5, 4, 5);
			this.memoryGroupBox.Size = new Size(1135, 596);
			this.memoryGroupBox.TabIndex = 1;
			this.memoryGroupBox.TabStop = false;
			this.memoryGroupBox.Text = "Memory";
			// 
			// memoryGrid
			// 
			this.memoryGrid.AllowDrop = true;
			this.memoryGrid.AllowUserToDeleteRows = false;
			this.memoryGrid.AllowUserToResizeColumns = false;
			this.memoryGrid.AllowUserToResizeRows = false;
			this.memoryGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.memoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.memoryGrid.Columns.AddRange(new DataGridViewColumn[] { this.memoryIndexColumn, this.memoryContentsColumn, this.startPointColumn, this.breakPointColumn, this.memoryAddColumn, this.memoryRemoveColumn });
			this.memoryGrid.Dock = DockStyle.Fill;
			this.memoryGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.memoryGrid.Location = new Point(4, 29);
			this.memoryGrid.Margin = new Padding(4, 5, 4, 5);
			this.memoryGrid.Name = "memoryGrid";
			this.memoryGrid.RightToLeft = RightToLeft.No;
			this.memoryGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.memoryGrid.RowHeadersVisible = false;
			this.memoryGrid.RowHeadersWidth = 62;
			this.memoryGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.memoryGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.memoryGrid.Size = new Size(1127, 562);
			this.memoryGrid.TabIndex = 9;
			this.memoryGrid.CellClick += MemoryGrid_CellClick;
			this.memoryGrid.CellDoubleClick += MemoryGrid_CellDoubleClick;
			this.memoryGrid.CellEndEdit += MemoryGrid_CellEndEdit;
			this.memoryGrid.CellMouseEnter += MemoryGrid_CellMouseEnter;
			this.memoryGrid.CellMouseLeave += MemoryGrid_CellMouseLeave;
			this.memoryGrid.DragDrop += MemoryGrid_DragDrop;
			this.memoryGrid.DragOver += MemoryGrid_DragOver;
			this.memoryGrid.KeyDown += MemoryGrid_KeyDown;
			this.memoryGrid.MouseMove += MemoryGrid_MouseMove;
			// 
			// memoryIndexColumn
			// 
			this.memoryIndexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.memoryIndexColumn.HeaderText = "Index";
			this.memoryIndexColumn.MinimumWidth = 8;
			this.memoryIndexColumn.Name = "memoryIndexColumn";
			this.memoryIndexColumn.ReadOnly = true;
			this.memoryIndexColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.memoryIndexColumn.Width = 61;
			// 
			// memoryContentsColumn
			// 
			this.memoryContentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.memoryContentsColumn.HeaderText = "Memory Contents";
			this.memoryContentsColumn.MinimumWidth = 8;
			this.memoryContentsColumn.Name = "memoryContentsColumn";
			this.memoryContentsColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
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
			this.startPointColumn.Width = 51;
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
			this.breakPointColumn.Width = 61;
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
			this.memoryAddColumn.Width = 52;
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
			this.memoryRemoveColumn.Width = 68;
			// 
			// groupBoxOfCoolness
			// 
			this.groupBoxOfCoolness.Controls.Add(this.removeTabButton);
			this.groupBoxOfCoolness.Controls.Add(this.addTabButton);
			this.groupBoxOfCoolness.Controls.Add(this.chooseFile6Button);
			this.groupBoxOfCoolness.Controls.Add(this.saveAsButton);
			this.groupBoxOfCoolness.Controls.Add(this.colorSchemeButton);
			this.groupBoxOfCoolness.Controls.Add(this.runFromStartButton);
			this.groupBoxOfCoolness.Controls.Add(this.resetButton);
			this.groupBoxOfCoolness.Controls.Add(this.label1);
			this.groupBoxOfCoolness.Controls.Add(this.accumulatorTextBox);
			this.groupBoxOfCoolness.Controls.Add(this.stepButton);
			this.groupBoxOfCoolness.Controls.Add(this.runButton);
			this.groupBoxOfCoolness.Controls.Add(this.reloadFileButton);
			this.groupBoxOfCoolness.Controls.Add(this.fileTextBox);
			this.groupBoxOfCoolness.Controls.Add(this.chooseFileButton);
			this.groupBoxOfCoolness.Dock = DockStyle.Fill;
			this.groupBoxOfCoolness.Location = new Point(3, 3);
			this.groupBoxOfCoolness.MinimumSize = new Size(1000, 250);
			this.groupBoxOfCoolness.Name = "groupBoxOfCoolness";
			this.groupBoxOfCoolness.Size = new Size(1137, 250);
			this.groupBoxOfCoolness.TabIndex = 4;
			this.groupBoxOfCoolness.TabStop = false;
			this.groupBoxOfCoolness.Text = "Controls";
			// 
			// removeTabButton
			// 
			this.removeTabButton.Location = new Point(175, 32);
			this.removeTabButton.Margin = new Padding(4, 5, 4, 5);
			this.removeTabButton.Name = "removeTabButton";
			this.removeTabButton.Size = new Size(159, 38);
			this.removeTabButton.TabIndex = 15;
			this.removeTabButton.Text = "Remove Tab";
			this.removeTabButton.UseVisualStyleBackColor = true;
			this.removeTabButton.Click += RemoveTab_Click;
			// 
			// addTabButton
			// 
			this.addTabButton.Location = new Point(8, 32);
			this.addTabButton.Margin = new Padding(4, 5, 4, 5);
			this.addTabButton.Name = "addTabButton";
			this.addTabButton.Size = new Size(159, 38);
			this.addTabButton.TabIndex = 14;
			this.addTabButton.Text = "Add Tab";
			this.addTabButton.UseVisualStyleBackColor = true;
			this.addTabButton.Click += AddTab_Click;
			// 
			// chooseFile6Button
			// 
			this.chooseFile6Button.Location = new Point(497, 90);
			this.chooseFile6Button.Name = "chooseFile6Button";
			this.chooseFile6Button.Size = new Size(200, 38);
			this.chooseFile6Button.TabIndex = 13;
			this.chooseFile6Button.Text = "Choose File (6 Digit)";
			this.chooseFile6Button.UseVisualStyleBackColor = true;
			this.chooseFile6Button.Click += chooseFile6Button_Click;
			// 
			// saveAsButton
			// 
			this.saveAsButton.Location = new Point(703, 90);
			this.saveAsButton.Name = "saveAsButton";
			this.saveAsButton.Size = new Size(159, 38);
			this.saveAsButton.TabIndex = 12;
			this.saveAsButton.Text = "Save As";
			this.saveAsButton.UseVisualStyleBackColor = true;
			this.saveAsButton.Click += SaveAsButton_Click;
			// 
			// colorSchemeButton
			// 
			this.colorSchemeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.colorSchemeButton.Location = new Point(958, 17);
			this.colorSchemeButton.Margin = new Padding(4, 5, 4, 5);
			this.colorSchemeButton.Name = "colorSchemeButton";
			this.colorSchemeButton.Size = new Size(159, 38);
			this.colorSchemeButton.TabIndex = 11;
			this.colorSchemeButton.Text = "Color Scheme";
			this.colorSchemeButton.UseVisualStyleBackColor = true;
			this.colorSchemeButton.Click += ColorSchemeButton_Click;
			// 
			// runFromStartButton
			// 
			this.runFromStartButton.Location = new Point(8, 136);
			this.runFromStartButton.Margin = new Padding(4, 5, 4, 5);
			this.runFromStartButton.Name = "runFromStartButton";
			this.runFromStartButton.Size = new Size(227, 38);
			this.runFromStartButton.TabIndex = 10;
			this.runFromStartButton.Text = "Run From Start";
			this.runFromStartButton.UseVisualStyleBackColor = true;
			this.runFromStartButton.Click += RunFromStartButton_Click;
			// 
			// resetButton
			// 
			this.resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.resetButton.Location = new Point(243, 182);
			this.resetButton.Margin = new Padding(4, 5, 4, 5);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new Size(107, 38);
			this.resetButton.TabIndex = 9;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += ResetButton_Click;
			// 
			// label1
			// 
			this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI", 12F);
			this.label1.Location = new Point(896, 142);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(213, 32);
			this.label1.TabIndex = 8;
			this.label1.Text = "Accumulator Value";
			// 
			// accumulatorTextBox
			// 
			this.accumulatorTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.accumulatorTextBox.Location = new Point(896, 182);
			this.accumulatorTextBox.Margin = new Padding(4, 5, 4, 5);
			this.accumulatorTextBox.Name = "accumulatorTextBox";
			this.accumulatorTextBox.Size = new Size(221, 31);
			this.accumulatorTextBox.TabIndex = 7;
			this.accumulatorTextBox.KeyDown += AccumulatorTextBox_KeyDown;
			// 
			// stepButton
			// 
			this.stepButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.stepButton.Location = new Point(124, 182);
			this.stepButton.Name = "stepButton";
			this.stepButton.Size = new Size(111, 38);
			this.stepButton.TabIndex = 6;
			this.stepButton.Text = "Step";
			this.stepButton.UseVisualStyleBackColor = true;
			this.stepButton.Click += StepButton_Click;
			// 
			// runButton
			// 
			this.runButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.runButton.Location = new Point(7, 182);
			this.runButton.Name = "runButton";
			this.runButton.Size = new Size(111, 38);
			this.runButton.TabIndex = 5;
			this.runButton.Text = "Run";
			this.runButton.UseVisualStyleBackColor = true;
			this.runButton.Click += RunButton_Click;
			// 
			// reloadFileButton
			// 
			this.reloadFileButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.reloadFileButton.Location = new Point(243, 136);
			this.reloadFileButton.Name = "reloadFileButton";
			this.reloadFileButton.Size = new Size(111, 38);
			this.reloadFileButton.TabIndex = 4;
			this.reloadFileButton.Text = "Reload";
			this.reloadFileButton.UseVisualStyleBackColor = true;
			this.reloadFileButton.Click += LoadFileButton_Click;
			// 
			// fileTextBox
			// 
			this.fileTextBox.Location = new Point(8, 97);
			this.fileTextBox.Name = "fileTextBox";
			this.fileTextBox.Size = new Size(277, 31);
			this.fileTextBox.TabIndex = 2;
			this.fileTextBox.Text = "Please Choose A FIle";
			// 
			// chooseFileButton
			// 
			this.chooseFileButton.Location = new Point(291, 90);
			this.chooseFileButton.Name = "chooseFileButton";
			this.chooseFileButton.Size = new Size(200, 38);
			this.chooseFileButton.TabIndex = 3;
			this.chooseFileButton.Text = "Choose File (4 Digit)";
			this.chooseFileButton.UseVisualStyleBackColor = true;
			this.chooseFileButton.Click += ChooseFile_Click;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.programOutputBox);
			this.groupBox4.Dock = DockStyle.Fill;
			this.groupBox4.Location = new Point(4, 861);
			this.groupBox4.Margin = new Padding(4, 5, 4, 5);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new Padding(4, 5, 4, 5);
			this.groupBox4.Size = new Size(1135, 384);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Program Output";
			// 
			// programOutputBox
			// 
			this.programOutputBox.Dock = DockStyle.Fill;
			this.programOutputBox.Location = new Point(4, 29);
			this.programOutputBox.Margin = new Padding(4, 5, 4, 5);
			this.programOutputBox.Name = "programOutputBox";
			this.programOutputBox.ReadOnly = true;
			this.programOutputBox.Size = new Size(1127, 350);
			this.programOutputBox.TabIndex = 0;
			this.programOutputBox.Text = "";
			// 
			// FormTab
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			Controls.Add(this.tableLayoutPanel1);
			Margin = new Padding(4, 5, 4, 5);
			Name = "FormTab";
			Size = new Size(1143, 1250);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.memoryGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.memoryGrid).EndInit();
			this.groupBoxOfCoolness.ResumeLayout(false);
			this.groupBoxOfCoolness.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			ResumeLayout(false);
		}


		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private TableLayoutPanel tableLayoutPanel1;
		private GroupBox memoryGroupBox;
		private GroupBox groupBoxOfCoolness;
		private Button saveAsButton;
		private Button colorSchemeButton;
		private Button runFromStartButton;
		private Button resetButton;
		private Label label1;
		private TextBox accumulatorTextBox;
		private Button stepButton;
		private Button runButton;
		private Button reloadFileButton;
		private TextBox fileTextBox;
		private Button chooseFileButton;
		private GroupBox groupBox4;
		private RichTextBox programOutputBox;
		private DataGridView memoryGrid;
		private DataGridViewTextBoxColumn memoryIndexColumn;
		private DataGridViewTextBoxColumn memoryContentsColumn;
		private DataGridViewImageColumn startPointColumn;
		private DataGridViewImageColumn breakPointColumn;
		private DataGridViewImageColumn memoryAddColumn;
		private DataGridViewImageColumn memoryRemoveColumn;
		private Button chooseFile6Button;
		private Button removeTabButton;
		private Button addTabButton;
	}
}
