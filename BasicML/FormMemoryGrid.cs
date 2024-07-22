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
	public class MemoryGrid
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		private readonly Bitmap BLANK_IMAGE = new(2, 2);														// This is the image that is used when no icon is needed
		private readonly Icon START_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.MediaAudioDVD, 20);		// This is the icon that is used to show the current memory address
		private readonly Icon BREAK_POINT_ICON = SystemIcons.GetStockIcon(StockIconId.Error, 20);				// This is the icon that is used to show a break point
		private readonly Icon ADD_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Stack, 20);				// This is the icon that is used to add a row to the memory grid
		private readonly Icon REMOVE_COULUMN_ICON = SystemIcons.GetStockIcon(StockIconId.Delete, 20);           // This is the icon that is used to remove a row from the memory grid

		private Cpu cpu;

		public DataGridView grid;
		private DataGridViewTextBoxColumn memoryIndexColumn;
		private DataGridViewTextBoxColumn memoryContentsColumn;
		private DataGridViewImageColumn startPointColumn;
		private DataGridViewImageColumn breakPointColumn;
		private DataGridViewImageColumn memoryAddColumn;
		private DataGridViewImageColumn memoryRemoveColumn;



		/* - - - - - - - - - - Constructors! - - - - - - - - - - */

		public MemoryGrid(Cpu cpu)
		{
			this.cpu = cpu;
			Initialize();
		}

		public MemoryGrid(int cpuIndex)
		{
			this.cpu = InstanceHandler.GetCpu(cpuIndex);
			Initialize();
		}



		/* - - - - - - - - - - General Functions - - - - - - - - - - */

		// Preforms setup the memory grid
		private void Initialize()
		{
			// Creates the memory grids internal objects
			this.grid = new DataGridView();
			this.memoryIndexColumn = new DataGridViewTextBoxColumn();
			this.memoryContentsColumn = new DataGridViewTextBoxColumn();
			this.startPointColumn = new DataGridViewImageColumn();
			this.breakPointColumn = new DataGridViewImageColumn();
			this.memoryAddColumn = new DataGridViewImageColumn();
			this.memoryRemoveColumn = new DataGridViewImageColumn();

			this.grid.AllowDrop = true;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AllowUserToResizeColumns = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid.Columns.AddRange(new DataGridViewColumn[] { this.memoryIndexColumn, this.memoryContentsColumn, this.startPointColumn, this.breakPointColumn, this.memoryAddColumn, this.memoryRemoveColumn });
			this.grid.Dock = DockStyle.Fill;
			this.grid.EditMode = DataGridViewEditMode.EditProgrammatically;
			this.grid.Location = new Point(4, 29);
			this.grid.Name = "grid";
			this.grid.RightToLeft = RightToLeft.No;
			this.grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.grid.RowHeadersVisible = false;
			this.grid.RowHeadersWidth = 62;
			this.grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.grid.Size = new Size(1115, 410);
			this.grid.TabIndex = 9;

			
			// memoryIndexColumn
			this.memoryIndexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.memoryIndexColumn.HeaderText = "Index";
			this.memoryIndexColumn.MinimumWidth = 8;
			this.memoryIndexColumn.Name = "memoryIndexColumn";
			this.memoryIndexColumn.ReadOnly = true;
			this.memoryIndexColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.memoryIndexColumn.Width = 61;
			
			// memoryContentsColumn
			this.memoryContentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.memoryContentsColumn.HeaderText = "Memory Contents";
			this.memoryContentsColumn.MinimumWidth = 8;
			this.memoryContentsColumn.Name = "memoryContentsColumn";
			this.memoryContentsColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			
			// startPointColumn
			this.startPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.startPointColumn.HeaderText = "CPU";
			this.startPointColumn.MinimumWidth = 8;
			this.startPointColumn.Name = "startPointColumn";
			this.startPointColumn.ReadOnly = true;
			this.startPointColumn.Resizable = DataGridViewTriState.True;
			this.startPointColumn.ToolTipText = "The location in memory that the CPU is at";
			this.startPointColumn.Width = 51;
			
			// breakPointColumn
			this.breakPointColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.breakPointColumn.HeaderText = "Break";
			this.breakPointColumn.MinimumWidth = 8;
			this.breakPointColumn.Name = "breakPointColumn";
			this.breakPointColumn.ReadOnly = true;
			this.breakPointColumn.Resizable = DataGridViewTriState.True;
			this.breakPointColumn.ToolTipText = "Breakpoints";
			this.breakPointColumn.Width = 61;
			
			// memoryAddColumn
			this.memoryAddColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.memoryAddColumn.HeaderText = "Add";
			this.memoryAddColumn.MinimumWidth = 8;
			this.memoryAddColumn.Name = "memoryAddColumn";
			this.memoryAddColumn.ReadOnly = true;
			this.memoryAddColumn.Resizable = DataGridViewTriState.True;
			this.memoryAddColumn.ToolTipText = "Adds a new element to memory";
			this.memoryAddColumn.Width = 52; 

			// memoryRemoveColumn
			this.memoryRemoveColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.memoryRemoveColumn.HeaderText = "Delete";
			this.memoryRemoveColumn.MinimumWidth = 8;
			this.memoryRemoveColumn.Name = "memoryRemoveColumn";
			this.memoryRemoveColumn.ReadOnly = true;
			this.memoryRemoveColumn.Resizable = DataGridViewTriState.True;
			this.memoryRemoveColumn.ToolTipText = "Deletes an element from memory";
			this.memoryRemoveColumn.Width = 68;

			// Adds events to the memory grids internal objects
			this.grid.CellClick += CellClick;
			this.grid.CellDoubleClick += CellDoubleClick;
			this.grid.CellEndEdit += CellEndEdit;
			this.grid.CellMouseEnter += CellMouseEnter;
			this.grid.CellMouseLeave += CellMouseLeave;
			this.grid.DragDrop += DragDrop;
			this.grid.DragOver += DragOver;
			this.grid.KeyDown += KeyDown;
			this.grid.MouseMove += MouseMove;

			// Sets the default icons for the memory grid
			startPointColumn.Image = BLANK_IMAGE;
			breakPointColumn.Image = BLANK_IMAGE;

			memoryAddColumn.Icon = ADD_COULUMN_ICON;
			memoryAddColumn.ValuesAreIcons = true;

			memoryRemoveColumn.Icon = REMOVE_COULUMN_ICON;
			memoryRemoveColumn.ValuesAreIcons = true;

			// Centers the text for the headers
			foreach (DataGridViewColumn column in grid.Columns) { column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; }

			// Might be important
			//((System.ComponentModel.ISupportInitialize)this.grid).EndInit();
		}


		// Updates the memory grid's display so it shows the current state of the memory
		public void Refresh()
		{
			// Deselects any selected cells
			grid.ClearSelection();

			// Repopulates the memory grid if needed
			if (grid.Rows.Count > cpu.memory.Count + 1) { grid.Rows.Clear(); }
			while (grid.Rows.Count <= cpu.memory.Count) { grid.Rows.Add(); }

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
				grid.Rows[i].Cells[0].Value = i.ToString();
				grid.Rows[i].Cells[1].Value = cpu.memory.ElementAt(i).ToString(true);
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
					DataGridViewImageCell cell = (DataGridViewImageCell)grid.Rows[i].Cells[3];
					cell.ValueIsIcon = true;
					cell.Value = BREAK_POINT_ICON;
				}
			}


			// Updates the StartPoint icon location
			if (cpu.memory.Count >= cpu.MemoryAddress)
			{
				DataGridViewImageCell selectedStartPointCell = (DataGridViewImageCell)grid.Rows[cpu.MemoryAddress].Cells[2];

				selectedStartPointCell.ValueIsIcon = true;
				selectedStartPointCell.Value = START_POINT_ICON;
			}

			// Variables that represent specific cells in the memory grid (These are decalared for readability purposes)
			DataGridViewImageCell lastStartPointCell = (DataGridViewImageCell)grid.Rows[grid.Rows.Count - 1].Cells[2];
			DataGridViewImageCell lastBreakPointCell = (DataGridViewImageCell)grid.Rows[grid.Rows.Count - 1].Cells[3];
			DataGridViewImageCell lastAddCell = (DataGridViewImageCell)grid.Rows[grid.Rows.Count - 1].Cells[4];
			DataGridViewImageCell lastRemoveCell = (DataGridViewImageCell)grid.Rows[grid.Rows.Count - 1].Cells[5];

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
		private void CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= grid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= grid.Columns.Count)) { return; }

			// Preforms the action that corresponds to the cell that was clicked
			if (e.ColumnIndex == 0)
			{
				dragging = true;
				// If the mouse is over a valid row, start the drag-and-drop operation.
				grid.DoDragDrop(grid.Rows, DragDropEffects.Move);
			}
			else if (e.ColumnIndex == 2) 
			{
				cpu.MemoryAddress = e.RowIndex;
				Refresh();
			}
			else if (e.ColumnIndex == 3) 
			{
				cpu.memory.ElementAt(e.RowIndex)._isBreakpoint = !cpu.memory.ElementAt(e.RowIndex)._isBreakpoint;
				Refresh();
			}
			else if (e.ColumnIndex == 4) 
			{
				cpu.memory.AddAt(e.RowIndex);
				Refresh();
			}
			else if ((e.ColumnIndex == 5) && (e.RowIndex < grid.Rows.Count - 1)) 
			{
				cpu.memory.RemoveAt(e.RowIndex);
				Refresh();
			}
		}

		private void CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 1) { grid.BeginEdit(true); }
		}


		// Runs when the mouse enters a cell in the grid
		private void CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= grid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= grid.Columns.Count)) { return; }

			// Shows the icon for the startPoint and breakPoint cells on mouse enter
			if (e.RowIndex < grid.Rows.Count - 1)
			{
				if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
				{
					DataGridViewImageCell cell = (DataGridViewImageCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
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
		private void CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= grid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= grid.Columns.Count)) { return; }

			// Returns early if the cell contents should not be changed on leave
			if ((e.ColumnIndex == 2) && (e.RowIndex == cpu.MemoryAddress)) { return; }
			if ((e.ColumnIndex == 3) && (e.RowIndex < cpu.memory.Count) && (cpu.memory.ElementAt(e.RowIndex)._isBreakpoint)) { return; }

			// Clears the icon from the startPoint and breakPoint cells on mouse leave
			if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
			{
				DataGridViewImageCell cell = (DataGridViewImageCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
				if (cell != null)
				{
					cell.ValueIsIcon = false;
					cell.Value = BLANK_IMAGE;
				}
			}
		}


		// Runs when the user finishes editing a cell in the grid
		private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// Returns early if the cell is out of bounds
			if ((e.RowIndex < 0) || (e.RowIndex >= grid.Rows.Count)) { return; }
			if ((e.ColumnIndex < 0) || (e.ColumnIndex >= grid.Columns.Count)) { return; }

			if (e.ColumnIndex == 1)
			{
				DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];

				if (cell != null)
				{
					string? cellValue = null;

					if (cell.Value != null) { cellValue = cell.Value.ToString(); }

					if ((cellValue == null) || (cellValue == string.Empty)) { cellValue = "0000"; }


					// Sets the value of the corresponding memory element to the value of the cell
					if (e.RowIndex >= Memory.MAX_SIZE) { cpu.memory.Add(cellValue); }
					else { cpu.memory.SetElement(e.RowIndex, cellValue); }


					Refresh();
				}
			}
		}

		private bool dragging = false;

		private void MouseMove(object sender, MouseEventArgs e)
		{
			if (dragging)
			{
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				{
					grid.DoDragDrop(grid.Rows, DragDropEffects.Move);
				}
			}	
		}

		private void DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void DragDrop(object sender, DragEventArgs e)
		{
			dragging = false;

			// The mouse locations are relative to the screen, so they must be converted to client coordinates
			Point clientPoint = grid.PointToClient(new Point(e.X, e.Y));

			// Get the row index of the item the mouse is below
			int rowIndexOfItemUnderMouseToDrop = grid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

			// If the drag operation is not within a valid row, return
			if (rowIndexOfItemUnderMouseToDrop == -1) { return; }

			SortedDictionary<int, Word> selectedRows = new();

			foreach (DataGridViewCell cell in grid.SelectedCells)
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

				Refresh();
			}
		}

		// Runs when enter is pressed in the accumulator text box
		private void KeyDown(object sender, KeyEventArgs e)
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

			List<DataGridViewCell> selectedCells = grid.SelectedCells.OfType<DataGridViewCell>().ToList();

			selectedCells.Sort((cell1, cell2) => cell1.RowIndex.CompareTo(cell2.RowIndex));

			int i = 0;

			foreach (DataGridViewCell cell in selectedCells)
			{
				cpu.memory.SetElement(cell.RowIndex, clipboardContents[i]);
				i++;

				if (i == clipboardContents.Length) { i = 0; }
			}
			Refresh();
		}
	}
}
