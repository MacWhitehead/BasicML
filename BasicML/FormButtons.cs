using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	// This file contains the functions that are used to control the buttons in the form
	public partial class FormBasicML : Form
	{
		/* - - - - - - - - - - Display Functions - - - - - - - - - - */

		// Updates the visibility of the buttons
		private void Buttons_Refresh()
		{
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

			if (fileLoaded) { reloadFileButton.Visible = true; }
			else { reloadFileButton.Visible = false; }
		}



		/* - - - - - - - - - - Event Functions - - - - - - - - - - */

		// Runs when the "Choose File" button is clicked
		private void ChooseFile_Click(object sender, EventArgs e)
		{
			ChooseFile();
			LoadFile();
			RefreshMemory();
		}


		// Runs when the "Reload File" button is clicked
		private void LoadFileButton_Click(object sender, EventArgs e)
		{
			LoadFile();
			RefreshMemory();
		}


		// Runs when the "Run" button is clicked
		private void RunButton_Click(object sender, EventArgs e)
		{
			Cpu.StartExecution();
			RefreshMemory();
		}


		// Runs when the "Step" button is clicked
		private void StepButton_Click(object sender, EventArgs e)
		{
			Cpu.StepExecution();
			RefreshMemory();
		}


		// Runs when the "Run From Start" button is clicked
		private void RunFromStartButton_Click(object sender, EventArgs e)
		{
			Cpu.MemoryAddress = 0;
			Cpu.StartExecution();
		}


		// Runs when the "Reset" button is clicked
		private void ResetButton_Click(object sender, EventArgs e)
		{
			Cpu.MemoryAddress = 0;
			Accumulator._registerContent = 0;
			programOutputBox.Clear();
			RefreshMemory();
		}
	}
}
