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
            ColorScheme = new Button();
            stepButton = new Button();
            runButton = new Button();
            loadFileButton = new Button();
            fileTextBox = new TextBox();
            chooseFile = new Button();
            openFileDialog = new OpenFileDialog();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoryGrid).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Size = new Size(792, 637);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(loggingBox);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 384);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(786, 250);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Log";
            // 
            // loggingBox
            // 
            loggingBox.Dock = DockStyle.Fill;
            loggingBox.Location = new Point(3, 19);
            loggingBox.Name = "loggingBox";
            loggingBox.Size = new Size(780, 228);
            loggingBox.TabIndex = 1;
            loggingBox.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(memoryGrid);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 130);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(786, 248);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Memory";
            // 
            // memoryGrid
            // 
            memoryGrid.AllowUserToDeleteRows = false;
            memoryGrid.AllowUserToResizeColumns = false;
            memoryGrid.AllowUserToResizeRows = false;
            memoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            memoryGrid.Columns.AddRange(new DataGridViewColumn[] { memoryIndexColumn, memoryContentsColumn, startPointColumn, breakPointColumn, memoryAddColumn, memoryRemoveColumn });
            memoryGrid.Dock = DockStyle.Fill;
            memoryGrid.Location = new Point(3, 19);
            memoryGrid.Margin = new Padding(2);
            memoryGrid.MultiSelect = false;
            memoryGrid.Name = "memoryGrid";
            memoryGrid.RightToLeft = RightToLeft.No;
            memoryGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            memoryGrid.RowHeadersVisible = false;
            memoryGrid.RowHeadersWidth = 62;
            memoryGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            memoryGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            memoryGrid.Size = new Size(780, 226);
            memoryGrid.TabIndex = 9;
            memoryGrid.CellContentClick += memoryGrid_CellContentClick;
            memoryGrid.CellEndEdit += memoryGrid_CellEndEdit;
            memoryGrid.CellMouseEnter += memoryGrid_CellMouseEnter;
            memoryGrid.CellMouseLeave += memoryGrid_CellMouseLeave;
            // 
            // memoryIndexColumn
            // 
            memoryIndexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            memoryIndexColumn.HeaderText = "Index";
            memoryIndexColumn.MinimumWidth = 8;
            memoryIndexColumn.Name = "memoryIndexColumn";
            memoryIndexColumn.ReadOnly = true;
            memoryIndexColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            memoryIndexColumn.Width = 42;
            // 
            // memoryContentsColumn
            // 
            memoryContentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            memoryContentsColumn.HeaderText = "Memory Contents";
            memoryContentsColumn.MinimumWidth = 8;
            memoryContentsColumn.Name = "memoryContentsColumn";
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
            startPointColumn.Width = 36;
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
            breakPointColumn.Width = 42;
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
            memoryAddColumn.Width = 35;
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
            memoryRemoveColumn.Width = 46;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ColorScheme);
            groupBox3.Controls.Add(stepButton);
            groupBox3.Controls.Add(runButton);
            groupBox3.Controls.Add(loadFileButton);
            groupBox3.Controls.Add(fileTextBox);
            groupBox3.Controls.Add(chooseFile);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(2, 2);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(788, 123);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Controls";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // ColorScheme
            // 
            ColorScheme.Location = new Point(4, 72);
            ColorScheme.Name = "ColorScheme";
            ColorScheme.Size = new Size(160, 23);
            ColorScheme.TabIndex = 7;
            ColorScheme.Text = "Color Scheme";
            ColorScheme.UseVisualStyleBackColor = true;
            ColorScheme.Click += button1_Click;
            // 
            // stepButton
            // 
            stepButton.Location = new Point(86, 100);
            stepButton.Margin = new Padding(2);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(78, 23);
            stepButton.TabIndex = 6;
            stepButton.Text = "Step";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += stepButton_Click;
            // 
            // runButton
            // 
            runButton.Location = new Point(4, 100);
            runButton.Margin = new Padding(2);
            runButton.Name = "runButton";
            runButton.Size = new Size(78, 23);
            runButton.TabIndex = 5;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(285, 36);
            loadFileButton.Margin = new Padding(2);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(78, 23);
            loadFileButton.TabIndex = 4;
            loadFileButton.Text = "Load";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += loadFileButton_Click;
            // 
            // fileTextBox
            // 
            fileTextBox.Location = new Point(4, 36);
            fileTextBox.Margin = new Padding(2);
            fileTextBox.Name = "fileTextBox";
            fileTextBox.Size = new Size(195, 23);
            fileTextBox.TabIndex = 2;
            fileTextBox.Text = "Please Choose A FIle";
            // 
            // chooseFile
            // 
            chooseFile.Location = new Point(203, 36);
            chooseFile.Margin = new Padding(2);
            chooseFile.Name = "chooseFile";
            chooseFile.Size = new Size(78, 23);
            chooseFile.TabIndex = 3;
            chooseFile.Text = "Choose File";
            chooseFile.UseVisualStyleBackColor = true;
            chooseFile.Click += chooseFile_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // FormBasicML
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 637);
            Controls.Add(tableLayoutPanel1);
            Name = "FormBasicML";
            Text = "BasicML";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)memoryGrid).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private Button ColorScheme;
    }
}
