using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicML
{
	// This file contains the functions that are used to control the data grid that displays the memory
	public partial class FormTab : UserControl
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		private readonly Bitmap BLANK_IMAGE = new(2, 2);														// This is the image that is used when no icon is needed
		private readonly Icon START_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.MediaAudioDVD, 20);		// This is the icon that is used to show the current memory address
		private readonly Icon BREAK_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.Error, 20);				// This is the icon that is used to show a break point
		private readonly Icon ADD_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Stack, 20);				// This is the icon that is used to add a row to the memory grid
		private readonly Icon REMOVE_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Delete, 20);           // This is the icon that is used to remove a row from the memory grid

		public Cpu cpu = new();



		/* - - - - - - - - - - General Functions - - - - - - - - - - */

		// Preforms setup the memory grid
		private void MemoryGrid_Initialize()
		{
			// Sets the default icons for the memory grid
			startPointColumn.Image = BLANK_IMAGE;
			breakPointColumn.Image = BLANK_IMAGE;

			memoryAddColumn.Icon = ADD_COULUMN_ICON;
			memoryAddColumn.ValuesAreIcons = true;

			memoryRemoveColumn.Icon = REMOVE_COULUMN_ICON;
			memoryRemoveColumn.ValuesAreIcons = true;

			// Centers the text for the headers
			foreach (DataGridViewColumn column in memoryGrid.Columns) { column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; }
		}


		// Updates the memory grid's display so it shows the current state of the memory
		public void MemoryGrid_Refresh()
		{
			// Deselects any selected cells
			memoryGrid.ClearSelection();

			// Repopulates the memory grid if needed
			if (memoryGrid.Rows.Count > cpu.memory.Count + 1) { memoryGrid.Rows.Clear(); }
			while (memoryGrid.Rows.Count <= cpu.memory.Count) { memoryGrid.Rows.Add(); }

			// Updates the values of the memory grid
			RefreshValues();

			// Sets the icons that are displayed
			SetIcons();
		}


		// Refreshes the word values that are displayed
		private void RefreshValues()
		{
			// Updates the values of the memory grid
			for (int i = 0; i < cpu.memory.Count; i++)
			{
				memoryGrid.Rows[i].Cells[0].Value = i.ToString();
				memoryGrid.Rows[i].Cells[1].Value = cpu.memory.ElementAt(i).ToString(true);
			}
		}


		// Sets the icons that should be displayed in the memory grid
		private void SetIcons()
		{

			// Updates the icons for the breakpoints
			for (int i = 0; i < cpu.memory.Count; i++)
			{
				if (cpu.memory.ElementAt(i)._isBreakpoint)
				{
					DataGridViewImageCell cell = (DataGridViewImageCell)memoryGrid.Rows[i].Cells[3];
					cell.ValueIsIcon = true;
					cell.Value = BREAK_POINT_ICON;
				}
			}

			/*
			// Updates the StartPoint icon location
			if (cpu.memory.Count >= cpu.MemoryAddress)
			{
				DataGridViewImageCell selectedStartPointCell = (DataGridViewImageCell)memoryGrid.Rows[cpu.MemoryAddress].Cells[2];

				selectedStartPointCell.ValueIsIcon = true;
				selectedStartPointCell.Value = START_POINT_ICON;
			}
			*/

			// Updates the StartPoint icon location
			for (int i = 0; i < memoryGrid.Rows.Count; i++)
			{
				DataGridViewImageCell cell = (DataGridViewImageCell)memoryGrid.Rows[i].Cells[2];
				if (i == cpu.MemoryAddress)
				{
					cell.ValueIsIcon = true;
					cell.Value = START_POINT_ICON;
				}
				else
				{

					cell.ValueIsIcon = false;
					cell.Value = BLANK_IMAGE;
				}

			}

			// Variables that represent specific cells in the memory grid (These are decalared for readability purposes)
			DataGridViewImageCell lastStartPointCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[2];
			DataGridViewImageCell lastBreakPointCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[3];
			DataGridViewImageCell lastAddCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[4];
			DataGridViewImageCell lastRemoveCell = (DataGridViewImageCell)memoryGrid.Rows[memoryGrid.Rows.Count - 1].Cells[5];

			// Clears the icons from the last row of the memory grid
			lastStartPointCell.ValueIsIcon = false;
			lastStartPointCell.Value = BLANK_IMAGE;

			lastBreakPointCell.ValueIsIcon = false;
			lastBreakPointCell.Value = BLANK_IMAGE;

			lastAddCell.ValueIsIcon = true;
			lastAddCell.Value = ADD_COULUMN_ICON;

			lastRemoveCell.ValueIsIcon = false;
			lastRemoveCell.Value = BLANK_IMAGE;
		}

		/* - - - - - - - - - - Event Functions - - - - - - - - - - */

		// Runs when the mouse clicks a cell in the grid
		private void MemoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }

			// Preforms the action that corresponds to the cell that was clicked
			if (e.ColumnIndex == 0)
			{
				dragging = true;
				// If the mouse is over a valid row, start the drag-and-drop operation.
				memoryGrid.DoDragDrop(memoryGrid.Rows, DragDropEffects.Move);
			}
			else if (e.ColumnIndex == 2) 
			{
				cpu.MemoryAddress = e.RowIndex;
				MemoryGrid_Refresh();
			}
			else if (e.ColumnIndex == 3) 
			{
				cpu.memory.ElementAt(e.RowIndex)._isBreakpoint = !cpu.memory.ElementAt(e.RowIndex)._isBreakpoint;
				MemoryGrid_Refresh();
			}
			else if (e.ColumnIndex == 4) 
			{
				cpu.memory.AddAt(e.RowIndex);
				MemoryGrid_Refresh();
			}
			else if ((e.ColumnIndex == 5) && (e.RowIndex < memoryGrid.Rows.Count - 1)) 
			{
				cpu.memory.RemoveAt(e.RowIndex);
				MemoryGrid_Refresh();
			}
		}

		private void MemoryGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 1) { memoryGrid.BeginEdit(true); }
		}


		// Runs when the mouse enters a cell in the grid
		private void MemoryGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }

			// Shows the icon for the startPoint and breakPoint cells on mouse enter
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


		// Runs when the mouse leaves a cell in the grid
		private void MemoryGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= memoryGrid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= memoryGrid.Columns.Count)) { return; }

			// Returns early if the cell contents should not be changed on leave
			if ((e.ColumnIndex == 2) && (e.RowIndex == cpu.MemoryAddress)) { return; }
			if ((e.ColumnIndex == 3) && (e.RowIndex < cpu.memory.Count) && (cpu.memory.ElementAt(e.RowIndex)._isBreakpoint)) { return; }

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


		// Runs when the user finishes editing a cell in the grid
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
					if (e.RowIndex >= Memory.MAX_SIZE) { cpu.memory.Add(cellValue); }
					else { cpu.memory.SetElement(e.RowIndex, cellValue); }


					MemoryGrid_Refresh();
				}
			}
		}

		private bool dragging = false;

		private void MemoryGrid_MouseMove(object sender, MouseEventArgs e)
		{
			if (dragging)
			{
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				{
					memoryGrid.DoDragDrop(memoryGrid.Rows, DragDropEffects.Move);
				}
			}	
		}

		private void MemoryGrid_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void MemoryGrid_DragDrop(object sender, DragEventArgs e)
		{
			dragging = false;

			// The mouse locations are relative to the screen, so they must be converted to client coordinates
			Point clientPoint = memoryGrid.PointToClient(new Point(e.X, e.Y));

			// Get the row index of the item the mouse is below
			int rowIndexOfItemUnderMouseToDrop = memoryGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

			// If the drag operation is not within a valid row, return
			if (rowIndexOfItemUnderMouseToDrop == -1) { return; }

			SortedDictionary<int, Word> selectedRows = new();

			foreach (DataGridViewCell cell in memoryGrid.SelectedCells)
			{
				int row = cell.RowIndex;

				if (!selectedRows.ContainsKey(row))
				{
					selectedRows.Add(row, cpu.memory.ElementAt(row));
				}
			}

			int rowCount = selectedRows.Count;

			if (rowCount <= 0) { return; }

			// Move the row.
			if (e.Effect == DragDropEffects.Move)
			{
				for (int i = 0; i < rowCount; i++)
				{
					cpu.memory.RemoveAt(selectedRows.First().Key);
				}

				if (selectedRows.First().Key < rowIndexOfItemUnderMouseToDrop) { rowIndexOfItemUnderMouseToDrop -= rowCount; }

				foreach (KeyValuePair<int, Word> row in selectedRows)
				{
					cpu.memory.AddAt(rowIndexOfItemUnderMouseToDrop);
				}

				foreach (KeyValuePair<int, Word> row in selectedRows)
				{
					cpu.memory.SetElement(rowIndexOfItemUnderMouseToDrop, row.Value);

					rowIndexOfItemUnderMouseToDrop++;
				}

				MemoryGrid_Refresh();
			}
		}

		// Runs when enter is pressed in the accumulator text box
		private void MemoryGrid_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.V)
			{
				PasteClipboardValue();
				e.Handled = true;
			}
		}

		private void PasteClipboardValue()
		{
			if (!Clipboard.ContainsText()) { return; }

			string[] clipboardContents = Clipboard.GetText().Split('\n');

			List<DataGridViewCell> selectedCells = memoryGrid.SelectedCells.OfType<DataGridViewCell>().ToList();

			selectedCells.Sort((cell1, cell2) => cell1.RowIndex.CompareTo(cell2.RowIndex));

			int i = 0;

			foreach (DataGridViewCell cell in selectedCells)
			{
				cpu.memory.SetElement(cell.RowIndex, clipboardContents[i]);
				i++;

				if (i == clipboardContents.Length) { i = 0; }
			}
			MemoryGrid_Refresh();
		}
	}
}
