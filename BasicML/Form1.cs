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
		public static RichTextBox? _formProgramOutputBox;

		private readonly Bitmap BLANK_IMAGE = new(2, 2);
		private readonly Icon START_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.MediaAudioDVD, 20);
		private readonly Icon BREAK_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.Error, 20);
		private readonly Icon ADD_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Stack, 20);
		private readonly Icon REMOVE_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Delete, 20);

		private static bool fileLoaded = false;
		private static string fileName = "";

		public FormBasicML()
		{
			InitializeComponent();

			_formLoggingBox = loggingBox;
			_formProgramOutputBox = programOutputBox;

			loadFileButton.Visible = false;

			startPointColumn.Image = BLANK_IMAGE;
			breakPointColumn.Image = BLANK_IMAGE;

			memoryAddColumn.Icon = ADD_COULUMN_ICON;
			memoryAddColumn.ValuesAreIcons = true;

			memoryRemoveColumn.Icon = REMOVE_COULUMN_ICON;
			memoryRemoveColumn.ValuesAreIcons = true;

			// Centers the text for the headers
			foreach (DataGridViewColumn column in memoryGrid.Columns) { column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; }

			RefreshMemory();
		}

		private void ChooseFile()
		{
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = fileTextBox.Text = openFileDialog.FileName;
				fileLoaded = true;
				Logging.LogLine("File Loaded");
			}
			else
			{
				fileLoaded = false;
				Logging.LogLine("Error Loading File (" + result.ToString() + ")");
			}
		}

		private void LoadFile()
		{
			try { FileReader.ReadFileToMemory(fileTextBox.Text, false); }
			catch { Logging.Log("Could not read file"); }

			// Resets the value in the accumulator
			Accumulator._registerContent = 0;

			Cpu.MemoryAddress = 0;
		}

		private void ChooseFile_Click(object sender, EventArgs e)
		{
			ChooseFile();
			LoadFile();

			RefreshMemory();
		}

		private void LoadFileButton_Click(object sender, EventArgs e)
		{
			LoadFile();
			RefreshMemory();
		}

		private void RunButton_Click(object sender, EventArgs e)
		{
			Cpu.StartExecution();

			RefreshMemory();
		}

		private void StepButton_Click(object sender, EventArgs e)
		{
			Cpu.StepExecution();

			RefreshMemory();
		}

		private void RefreshMemory(bool repopulateCells = true)
		{
			memoryGrid.ClearSelection();

			if (repopulateCells)
			{
				memoryGrid.Rows.Clear();
				for (int i = 0; i < Memory.Count; i++)
				{
					memoryGrid.Rows.Add();
				}
			}

			for (int i = 0; i < Memory.Count; i++)
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

			if (Memory.Count >= Cpu.MemoryAddress)
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
			lastAddCell.Value = ADD_COULUMN_ICON;

			lastRemoveCell.ValueIsIcon = false;
			lastRemoveCell.Value = BLANK_IMAGE;

			if (Memory.Count > 0)
			{
				runButton.Visible = true;
				stepButton.Visible = true;

				if (Cpu.MemoryAddress != 0) { runFromStartButton.Visible = true; }
				else { runFromStartButton.Visible = false; }

				if ((Cpu.MemoryAddress != 0) || (Accumulator._registerContent != 0)) { resetButton.Visible = true; }
				else { resetButton.Visible = false; }
			}
			else
			{
				runButton.Visible = false;
				stepButton.Visible = false;
				resetButton.Visible = false;
				runFromStartButton.Visible = false;
			}

			if (fileLoaded) { loadFileButton.Visible = true; }
			else { loadFileButton.Visible = false; }

			accumulatorTextBox.Text = Accumulator._registerContent.ToString(true);
		}


		private void MemoryGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }


			if (e.ColumnIndex == 2) { Cpu.MemoryAddress = e.RowIndex; }
			else if (e.ColumnIndex == 3) { Memory.ElementAt(e.RowIndex)._isBreakpoint = !Memory.ElementAt(e.RowIndex)._isBreakpoint; }
			else if (e.ColumnIndex == 4) { Memory.AddAt(e.RowIndex, 0000); }
			else if ((e.ColumnIndex == 5) && (e.RowIndex < memoryGrid.Rows.Count - 1)) { Memory.RemoveAt(e.RowIndex); }

			RefreshMemory();
		}

		private void MemoryGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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
		private void MemoryGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
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

		private void MemoryGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
					if (e.RowIndex >= Memory.MAX_SIZE) { Memory.Add(cellValue); }
					else { Memory.SetElement(e.RowIndex, cellValue); }

					RefreshMemory(false);
				}
			}
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			Cpu.MemoryAddress = 0;
			Accumulator._registerContent = 0;
			programOutputBox.Clear();
			RefreshMemory();
		}

		private void AccumulatorTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Accumulator._registerContent = accumulatorTextBox.Text;
				RefreshMemory();
			}
		}

		private void RunFromStartButton_Click(object sender, EventArgs e)
		{
			Cpu.MemoryAddress = 0;
			Cpu.StartExecution();
		}
	}
}
