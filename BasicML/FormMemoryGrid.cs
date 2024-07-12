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
	public partial class FormBasicML : Form
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		private readonly Bitmap BLANK_IMAGE = new(2, 2);														// This is the image that is used when no icon is needed
		private readonly Icon START_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.MediaAudioDVD, 20);		// This is the icon that is used to show the current memory address
		private readonly Icon BREAK_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.Error, 20);				// This is the icon that is used to show a break point
		private readonly Icon ADD_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Stack, 20);				// This is the icon that is used to add a row to the memory grid
		private readonly Icon REMOVE_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Delete, 20);           // This is the icon that is used to remove a row from the memory grid



		/* - - - - - - - - - - General Functions - - - - - - - - - - */

		// Preforms setup the memory grid
		private void MemoryGrid_Initialize()
		{
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
		private void MemoryGrid_Refresh(bool repopulateCells = true)
		{
			// Deselects any selected cells
			memoryGrid.ClearSelection();

			// Repopulates the memory grid if needed
			if (repopulateCells) { memoryGrid.Rows.Clear(); }

			while(memoryGrid.Rows.Count <= Memory.Count) { memoryGrid.Rows.Add(); }

			// Updates the values of the memory grid
			MemoryGrid_RefreshValues();

			// Sets the icons that are displayed
			MemoryGrid_SetIcons();
		}


		private void Memory_Grid_Repopulate()
		{
			memoryGrid.Rows.Clear();
			for (int i = 0; i < Memory.Count; i++) { memoryGrid.Rows.Add(); }
		}


		// Refreshes the word values that are displayed
		private void MemoryGrid_RefreshValues()
		{
			// Updates the values of the memory grid
			for (int i = 0; i < Memory.Count; i++)
			{
				memoryGrid.Rows[i].Cells[0].Value = i.ToString();
				memoryGrid.Rows[i].Cells[1].Value = Memory.ElementAt(i).ToString(true);
			}
		}


		// Sets the icons that should be displayed in the memory grid
		private void MemoryGrid_SetIcons()
		{

			// Updates the icons for the breakpoints
			for (int i = 0; i < Memory.Count; i++)
			{
				if (Memory.ElementAt(i)._isBreakpoint)
				{
					DataGridViewImageCell cell = (DataGridViewImageCell)memoryGrid.Rows[i].Cells[3];
					cell.ValueIsIcon = true;
					cell.Value = BREAK_POINT_ICON;
				}
			}


			// Updates the StartPoint icon location
			if (Memory.Count >= Cpu.MemoryAddress)
			{
				DataGridViewImageCell selectedStartPointCell = (DataGridViewImageCell)memoryGrid.Rows[Cpu.MemoryAddress].Cells[2];

				selectedStartPointCell.ValueIsIcon = true;
				selectedStartPointCell.Value = START_POINT_ICON;
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

		// Runs when the mouse clicks a cell in the memoryGrid
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
				Cpu.MemoryAddress = e.RowIndex;
				RefreshMemory();
			}
			else if (e.ColumnIndex == 3) 
			{
				Memory.ElementAt(e.RowIndex)._isBreakpoint = !Memory.ElementAt(e.RowIndex)._isBreakpoint;
				RefreshMemory();
			}
			else if (e.ColumnIndex == 4) 
			{
				Memory.AddAt(e.RowIndex, 0000);
				RefreshMemory();
			}
			else if ((e.ColumnIndex == 5) && (e.RowIndex < memoryGrid.Rows.Count - 1)) 
			{
				Memory.RemoveAt(e.RowIndex);
				RefreshMemory();
			}

			// Refreshes the display so that the action's result is shown
		}


		// Runs when the mouse enters a cell in the memoryGrid
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


		// Runs when the user finishes editing a cell in the memoryGrid
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

			Logging.Log("Selected Rows: ");

			foreach (DataGridViewCell cell in memoryGrid.SelectedCells)
			{
				int row = cell.RowIndex;

				if (!selectedRows.ContainsKey(row))
				{
					Logging.Log(row.ToString() + " ");
					selectedRows.Add(row, Memory.ElementAt(row));
				}
			}
			Logging.Log("\n");

			int rowCount = selectedRows.Count;

			// Move the row.
			if (e.Effect == DragDropEffects.Move)
			{
				for (int i = 0; i < rowCount; i++)
				{
					Memory.RemoveAt(selectedRows.First().Key);
				}

				if (selectedRows.First().Key < rowIndexOfItemUnderMouseToDrop) { rowIndexOfItemUnderMouseToDrop -= rowCount; }

				foreach (KeyValuePair<int, Word> row in selectedRows)
				{
					Memory.AddAt(rowIndexOfItemUnderMouseToDrop, 0);
				}

				foreach (KeyValuePair<int, Word> row in selectedRows)
				{
					Memory.SetElement(rowIndexOfItemUnderMouseToDrop, row.Value);

					rowIndexOfItemUnderMouseToDrop++;
				}

				MemoryGrid_Refresh(false);
			}
		}
	}
}
