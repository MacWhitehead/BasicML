
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
			tableLayoutPanel1 = new TableLayoutPanel();
			groupBox1 = new GroupBox();
			loggingBox = new RichTextBox();
			groupBox2 = new GroupBox();
			memoryGrid = new DataGridView();
			memoryIndexColumn = new DataGridViewTextBoxColumn();
			memoryContentsColumn = new DataGridViewTextBoxColumn();
			startPointColumn = new DataGridViewImageColumn();
			breakPointColumn = new DataGridViewImageColumn();
			memoryAddColumn = new DataGridViewImageColumn();
			memoryRemoveColumn = new DataGridViewImageColumn();
			groupBox3 = new GroupBox();
			colorSchemeButton = new Button();
			runFromStartButton = new Button();
			resetButton = new Button();
			label1 = new Label();
			accumulatorTextBox = new TextBox();
			stepButton = new Button();
			runButton = new Button();
			reloadFileButton = new Button();
			fileTextBox = new TextBox();
			chooseFileButton = new Button();
			groupBox4 = new GroupBox();
			programOutputBox = new RichTextBox();
			openFileDialog = new OpenFileDialog();
			tableLayoutPanel1.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)memoryGrid).BeginInit();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(groupBox1, 0, 3);
			tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
			tableLayoutPanel1.Controls.Add(groupBox3, 0, 0);
			tableLayoutPanel1.Controls.Add(groupBox4, 0, 2);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 4;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
			tableLayoutPanel1.Size = new Size(1131, 1135);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(loggingBox);
			groupBox1.Dock = DockStyle.Fill;
			groupBox1.Location = new Point(4, 946);
			groupBox1.Margin = new Padding(4, 5, 4, 5);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 5, 4, 5);
			groupBox1.Size = new Size(1123, 184);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Log";
			// 
			// loggingBox
			// 
			loggingBox.Dock = DockStyle.Fill;
			loggingBox.Location = new Point(4, 29);
			loggingBox.Margin = new Padding(4, 5, 4, 5);
			loggingBox.Name = "loggingBox";
			loggingBox.ReadOnly = true;
			loggingBox.Size = new Size(1115, 150);
			loggingBox.TabIndex = 1;
			loggingBox.Text = "";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(memoryGrid);
			groupBox2.Dock = DockStyle.Fill;
			groupBox2.Location = new Point(4, 197);
			groupBox2.Margin = new Padding(4, 5, 4, 5);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(4, 5, 4, 5);
			groupBox2.Size = new Size(1123, 444);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Memory";
			// 
			// memoryGrid
			// 
			memoryGrid.AllowDrop = true;
			memoryGrid.AllowUserToDeleteRows = false;
			memoryGrid.AllowUserToResizeColumns = false;
			memoryGrid.AllowUserToResizeRows = false;
			memoryGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			memoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			memoryGrid.Columns.AddRange(new DataGridViewColumn[] { memoryIndexColumn, memoryContentsColumn, startPointColumn, breakPointColumn, memoryAddColumn, memoryRemoveColumn });
			memoryGrid.Dock = DockStyle.Fill;
			memoryGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
			memoryGrid.Location = new Point(4, 29);
			memoryGrid.Name = "memoryGrid";
			memoryGrid.RightToLeft = RightToLeft.No;
			memoryGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			memoryGrid.RowHeadersVisible = false;
			memoryGrid.RowHeadersWidth = 62;
			memoryGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			memoryGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			memoryGrid.Size = new Size(1115, 410);
			memoryGrid.TabIndex = 9;
			memoryGrid.CellClick += MemoryGrid_CellClick;
			memoryGrid.CellDoubleClick += MemoryGrid_CellDoubleClick;
			memoryGrid.CellEndEdit += MemoryGrid_CellEndEdit;
			memoryGrid.CellMouseEnter += MemoryGrid_CellMouseEnter;
			memoryGrid.CellMouseLeave += MemoryGrid_CellMouseLeave;
			memoryGrid.DragDrop += MemoryGrid_DragDrop;
			memoryGrid.DragOver += MemoryGrid_DragOver;
			memoryGrid.MouseMove += MemoryGrid_MouseMove;
			memoryGrid.KeyDown += MemoryGrid_KeyDown;
			// 
			// memoryIndexColumn
			// 
			memoryIndexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			memoryIndexColumn.HeaderText = "Index";
			memoryIndexColumn.MinimumWidth = 8;
			memoryIndexColumn.Name = "memoryIndexColumn";
			memoryIndexColumn.ReadOnly = true;
			memoryIndexColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			memoryIndexColumn.Width = 61;
			// 
			// memoryContentsColumn
			// 
			memoryContentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			memoryContentsColumn.HeaderText = "Memory Contents";
			memoryContentsColumn.MinimumWidth = 8;
			memoryContentsColumn.Name = "memoryContentsColumn";
			memoryContentsColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// startPointColumn
			// 
			startPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			startPointColumn.HeaderText = "CPU";
			startPointColumn.MinimumWidth = 8;
			startPointColumn.Name = "startPointColumn";
			startPointColumn.ReadOnly = true;
			startPointColumn.Resizable = DataGridViewTriState.True;
			startPointColumn.ToolTipText = "The location in memory that the CPU is at";
			startPointColumn.Width = 51;
			// 
			// breakPointColumn
			// 
			breakPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			breakPointColumn.HeaderText = "Break";
			breakPointColumn.MinimumWidth = 8;
			breakPointColumn.Name = "breakPointColumn";
			breakPointColumn.ReadOnly = true;
			breakPointColumn.Resizable = DataGridViewTriState.True;
			breakPointColumn.ToolTipText = "Breakpoints";
			breakPointColumn.Width = 61;
			// 
			// memoryAddColumn
			// 
			memoryAddColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			memoryAddColumn.HeaderText = "Add";
			memoryAddColumn.MinimumWidth = 8;
			memoryAddColumn.Name = "memoryAddColumn";
			memoryAddColumn.ReadOnly = true;
			memoryAddColumn.Resizable = DataGridViewTriState.True;
			memoryAddColumn.ToolTipText = "Adds a new element to memory";
			memoryAddColumn.Width = 52;
			// 
			// memoryRemoveColumn
			// 
			memoryRemoveColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			memoryRemoveColumn.HeaderText = "Delete";
			memoryRemoveColumn.MinimumWidth = 8;
			memoryRemoveColumn.Name = "memoryRemoveColumn";
			memoryRemoveColumn.ReadOnly = true;
			memoryRemoveColumn.Resizable = DataGridViewTriState.True;
			memoryRemoveColumn.ToolTipText = "Deletes an element from memory";
			memoryRemoveColumn.Width = 68;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(colorSchemeButton);
			groupBox3.Controls.Add(runFromStartButton);
			groupBox3.Controls.Add(resetButton);
			groupBox3.Controls.Add(label1);
			groupBox3.Controls.Add(accumulatorTextBox);
			groupBox3.Controls.Add(stepButton);
			groupBox3.Controls.Add(runButton);
			groupBox3.Controls.Add(reloadFileButton);
			groupBox3.Controls.Add(fileTextBox);
			groupBox3.Controls.Add(chooseFileButton);
			groupBox3.Dock = DockStyle.Fill;
			groupBox3.Location = new Point(3, 3);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(1125, 186);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "Controls";
			// 
			// colorSchemeButton
			// 
			colorSchemeButton.Location = new Point(960, 32);
			colorSchemeButton.Margin = new Padding(4, 5, 4, 5);
			colorSchemeButton.Name = "colorSchemeButton";
			colorSchemeButton.Size = new Size(159, 38);
			colorSchemeButton.TabIndex = 11;
			colorSchemeButton.Text = "Color Scheme";
			colorSchemeButton.UseVisualStyleBackColor = true;
			colorSchemeButton.Click += ColorSchemeButton_Click;
			// 
			// runFromStartButton
			// 
			runFromStartButton.Location = new Point(7, 80);
			runFromStartButton.Margin = new Padding(4, 5, 4, 5);
			runFromStartButton.Name = "runFromStartButton";
			runFromStartButton.Size = new Size(227, 38);
			runFromStartButton.TabIndex = 10;
			runFromStartButton.Text = "Run From Start";
			runFromStartButton.UseVisualStyleBackColor = true;
			runFromStartButton.Click += RunFromStartButton_Click;
			// 
			// resetButton
			// 
			resetButton.Location = new Point(241, 127);
			resetButton.Margin = new Padding(4, 5, 4, 5);
			resetButton.Name = "resetButton";
			resetButton.Size = new Size(107, 38);
			resetButton.TabIndex = 9;
			resetButton.Text = "Reset";
			resetButton.UseVisualStyleBackColor = true;
			resetButton.Click += ResetButton_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(911, 88);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(213, 32);
			label1.TabIndex = 8;
			label1.Text = "Accumulator Value";
			// 
			// accumulatorTextBox
			// 
			accumulatorTextBox.Location = new Point(897, 128);
			accumulatorTextBox.Margin = new Padding(4, 5, 4, 5);
			accumulatorTextBox.Name = "accumulatorTextBox";
			accumulatorTextBox.Size = new Size(221, 31);
			accumulatorTextBox.TabIndex = 7;
			accumulatorTextBox.KeyDown += AccumulatorTextBox_KeyDown;
			// 
			// stepButton
			// 
			stepButton.Location = new Point(123, 127);
			stepButton.Name = "stepButton";
			stepButton.Size = new Size(111, 38);
			stepButton.TabIndex = 6;
			stepButton.Text = "Step";
			stepButton.UseVisualStyleBackColor = true;
			stepButton.Click += StepButton_Click;
			// 
			// runButton
			// 
			runButton.Location = new Point(7, 128);
			runButton.Name = "runButton";
			runButton.Size = new Size(111, 38);
			runButton.TabIndex = 5;
			runButton.Text = "Run";
			runButton.UseVisualStyleBackColor = true;
			runButton.Click += RunButton_Click;
			// 
			// reloadFileButton
			// 
			reloadFileButton.Location = new Point(409, 33);
			reloadFileButton.Name = "reloadFileButton";
			reloadFileButton.Size = new Size(111, 38);
			reloadFileButton.TabIndex = 4;
			reloadFileButton.Text = "Reload";
			reloadFileButton.UseVisualStyleBackColor = true;
			reloadFileButton.Click += LoadFileButton_Click;
			// 
			// fileTextBox
			// 
			fileTextBox.Location = new Point(7, 33);
			fileTextBox.Name = "fileTextBox";
			fileTextBox.Size = new Size(277, 31);
			fileTextBox.TabIndex = 2;
			fileTextBox.Text = "Please Choose A FIle";
			// 
			// chooseFileButton
			// 
			chooseFileButton.Location = new Point(291, 33);
			chooseFileButton.Name = "chooseFileButton";
			chooseFileButton.Size = new Size(111, 38);
			chooseFileButton.TabIndex = 3;
			chooseFileButton.Text = "Choose File";
			chooseFileButton.UseVisualStyleBackColor = true;
			chooseFileButton.Click += ChooseFile_Click;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(programOutputBox);
			groupBox4.Dock = DockStyle.Fill;
			groupBox4.Location = new Point(4, 651);
			groupBox4.Margin = new Padding(4, 5, 4, 5);
			groupBox4.Name = "groupBox4";
			groupBox4.Padding = new Padding(4, 5, 4, 5);
			groupBox4.Size = new Size(1123, 285);
			groupBox4.TabIndex = 5;
			groupBox4.TabStop = false;
			groupBox4.Text = "Program Output";
			// 
			// programOutputBox
			// 
			programOutputBox.Dock = DockStyle.Fill;
			programOutputBox.Location = new Point(4, 29);
			programOutputBox.Margin = new Padding(4, 5, 4, 5);
			programOutputBox.Name = "programOutputBox";
			programOutputBox.ReadOnly = true;
			programOutputBox.Size = new Size(1115, 251);
			programOutputBox.TabIndex = 0;
			programOutputBox.Text = "";
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "openFileDialog";
			// 
			// FormBasicML
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1131, 1135);
			Controls.Add(tableLayoutPanel1);
			Margin = new Padding(4, 5, 4, 5);
			Name = "FormBasicML";
			Text = "BasicML";
			tableLayoutPanel1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)memoryGrid).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			ResumeLayout(false);
            // 
            // saveAsButton
            // 
            saveAsButton.Location = new Point(368, 20);
            saveAsButton.Margin = new Padding(2);
            saveAsButton.Name = "saveAsButton";
            saveAsButton.Size = new Size(78, 23);
            saveAsButton.TabIndex = 13;
            saveAsButton.Text = "Save As...";
            saveAsButton.Click += SaveAsButton_Click;
            saveAsButton.UseVisualStyleBackColor = true;
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
		private Label label1;
		private TextBox accumulatorTextBox;
		private Button resetButton;
		private Button runFromStartButton;
		private GroupBox groupBox4;
		private RichTextBox programOutputBox;
		private Button colorSchemeButton;
		private DataGridViewTextBoxColumn memoryIndexColumn;
		private DataGridViewTextBoxColumn memoryContentsColumn;
		private DataGridViewImageColumn startPointColumn;
		private DataGridViewImageColumn breakPointColumn;
		private DataGridViewImageColumn memoryAddColumn;
		private DataGridViewImageColumn memoryRemoveColumn;
        private Button saveAsButton;
    }
}
