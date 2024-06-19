using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace BasicML
{
	public partial class FormBasicML : Form
	{
		public static RichTextBox? _formLoggingBox;

		private Bitmap BLANK_IMAGE = new(2, 2);

		private Icon START_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.DeviceAudioPlayer, 20);
		private Icon BREAK_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.Delete, 20);
		private Icon ADD_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Users, 20);
		private Icon REMOVE_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Info, 20);

		public FormBasicML()
		{
			InitializeComponent();

			_formLoggingBox = loggingBox;

			loadFileButton.Visible = false;

			startPointColumn.Image = BLANK_IMAGE;
			breakPointColumn.Image = BLANK_IMAGE;

			memoryAddColumn.Icon = ADD_COULUMN_ICON;
			memoryAddColumn.ValuesAreIcons = true;

			memoryRemoveColumn.Icon = REMOVE_COULUMN_ICON;
			memoryRemoveColumn.ValuesAreIcons = true;

			refreshMemory();
		}

		// Open the test input text
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Initialize memory and loading Test file
			Memory.InitMemory("Test2.txt");

			// Output memory as a memory map
			for (int i = 0; i < Memory.TotalSize; i++)
			{
				// In case of operand is smaller than 10 because operand is int
				var operand = "";
				if (Memory.ElementAt(i).Operand < 10)
				{
					operand = "0" + Memory.ElementAt(i).Operand.ToString();
				}
				else
				{
					operand = Memory.ElementAt(i).Operand.ToString();
				}
			}
		}

		// Run the test program
		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Starts the cpu exececuting
			Cpu.StartExecution();

			refreshMemory();
		}

		private void chooseFile_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileTextBox.Text = openFileDialog.FileName;
				Logging.LogLine("File Loaded");
				loadFileButton.Visible = true;
			}
			else
			{
				Logging.LogLine("Error Loading File (" + result.ToString() + ")");
			}

			refreshMemory();
		}

		private void loadFileButton_Click(object sender, EventArgs e)
		{
			try { FileReader.ReadFileToMemory(fileTextBox.Text); }
			catch { Logging.Log("Could not read file"); }

			Cpu.MemoryAddress = 0;

			refreshMemory();

		}

		private void runButton_Click(object sender, EventArgs e)
		{
			Cpu.StartExecution();

			refreshMemory();
		}

		private void stepButton_Click(object sender, EventArgs e)
		{
			Cpu.StepExecution();
		}

		private void refreshMemory(bool repopulateCells = true)
		{
			memoryGrid.ClearSelection();

			if (repopulateCells)
			{
				memoryGrid.Rows.Clear();
				for (int i = 0; i < Memory.TotalSize; i++)
				{
					memoryGrid.Rows.Add();
				}
			}

			for (int i = 0; i < Memory.TotalSize; i++)
			{
				memoryGrid.Rows[i].Cells[0].Value = i.ToString();
				memoryGrid.Rows[i].Cells[1].Value = Memory.ElementAt(i).ToString(true);
				if (Memory.ElementAt(i)._isBreakpoint)
				{
					DataGridViewImageCell cell = (DataGridViewImageCell)memoryGrid.Rows[i].Cells[3];
					cell.ValueIsIcon = true;
					cell.Value = BREAK_POINT_ICON;
				}
			}

			if (Memory.TotalSize >= Cpu.MemoryAddress)
			{
				DataGridViewImageCell selectedStartPointCell = (DataGridViewImageCell)memoryGrid.Rows[Cpu.MemoryAddress].Cells[2];

				selectedStartPointCell.ValueIsIcon = true;
				selectedStartPointCell.Value = START_POINT_ICON;
			}

			DataGridViewImageCell lastStartPointCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[2];
			DataGridViewImageCell lastBreakPointCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[3];
			DataGridViewImageCell lastAddCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[4];
			DataGridViewImageCell lastRemoveCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[5];

			lastStartPointCell.ValueIsIcon = false;
			lastStartPointCell.Value = BLANK_IMAGE;

			lastBreakPointCell.ValueIsIcon = false;
			lastBreakPointCell.Value = BLANK_IMAGE;

			lastAddCell.ValueIsIcon = true;
			lastAddCell.Value = SystemIcons.GetStockIcon(StockIconId.Users, 20);

			lastRemoveCell.ValueIsIcon = false;
			lastRemoveCell.Value = BLANK_IMAGE;

			if (Memory.TotalSize > 0)
			{
				runButton.Visible = true;
				stepButton.Visible = true;
			}
			else
			{
				runButton.Visible = false;
				stepButton.Visible = false;
			}
		}



		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void memoryGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }


			if (e.ColumnIndex == 2) { Cpu.MemoryAddress = e.RowIndex; }
			else if (e.ColumnIndex == 3) { Memory.ElementAt(e.RowIndex)._isBreakpoint = !Memory.ElementAt(e.RowIndex)._isBreakpoint; }
			else if (e.ColumnIndex == 4) { Memory.AddAt(e.RowIndex, 0000); }
			else if ((e.ColumnIndex == 5) && (e.RowIndex < memoryGrid.Rows.Count - 1)) { Memory.RemoveAt(e.RowIndex); }

			refreshMemory();
		}

		private void memoryGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }


			if (e.RowIndex < memoryGrid.Rows.Count - 1)
			{
				if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
				{
					DataGridViewImageCell cell = (DataGridViewImageCell)memoryGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
					if (cell != null)
					{
						cell.ValueIsIcon = true;
						if (e.ColumnIndex == 2) { cell.Value = START_POINT_ICON; }
						else if (e.ColumnIndex == 3) { cell.Value = BREAK_POINT_ICON; }
					}
				}

			}
		}

		// Runs when the mouse leaves a cell in the memoryGrid
		private void memoryGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }

			// Returns early if the cell contents should not be changed on leave
			if ((e.ColumnIndex == 2) && (e.RowIndex == Cpu.MemoryAddress)) { return; }
			if ((e.ColumnIndex == 3) && (Memory.ElementAt(e.RowIndex)._isBreakpoint)) { return; }

			// Clears the icon from the startPoint and breakPoint cells on mouse leave
			if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
			{
				DataGridViewImageCell cell = (DataGridViewImageCell)memoryGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
				if (cell != null)
				{
					cell.ValueIsIcon = false;
					cell.Value = BLANK_IMAGE;
				}
			}
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void memoryGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }

			if (e.ColumnIndex == 1)
			{
				DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)memoryGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

				if (cell != null)
				{
					string? cellValue = null;

					if (cell.Value != null) { cellValue = cell.Value.ToString(); }

					if ((cellValue == null) || (cellValue == string.Empty)) { cellValue = "0000"; }
					

					// Sets the value of the corresponding memory element to the value of the cell
					if (e.RowIndex >= Memory.TotalSize) { Memory.Add(cellValue); }
					else { Memory.SetElement(e.RowIndex, cellValue); }

					// Updates the value of the cell to the value of the corresponding memory element
					//cell.Value = Memory.ElementAt(e.RowIndex).ToString(true);

					refreshMemory(false);
				}
			}
		}

	}
}
