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
			if (InstanceHandler.GetCpu(0).memory.Count > 0)
			{
				runButton.Visible = true;
				stepButton.Visible = true;
                saveAsButton.Visible = true;

                if (InstanceHandler.GetCpu(0).MemoryAddress != 0) { runFromStartButton.Visible = true; }
				else { runFromStartButton.Visible = false; }

				if ((InstanceHandler.GetCpu(0).MemoryAddress != 0) || (InstanceHandler.GetCpu(0).accumulator != 0)) { resetButton.Visible = true; }
				else { resetButton.Visible = false; }
			}
			else
			{
				runButton.Visible = false;
				stepButton.Visible = false;
				resetButton.Visible = false;
				runFromStartButton.Visible = false;
				saveAsButton.Visible = false;
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

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
			SaveFile();
        }


        // Runs when the "Run" button is clicked
        private void RunButton_Click(object sender, EventArgs e)
		{
			InstanceHandler.GetCpu(0).StartExecution();
			RefreshMemory();
		}


		// Runs when the "Step" button is clicked
		private void StepButton_Click(object sender, EventArgs e)
		{
			InstanceHandler.GetCpu(0).StepExecution();
			RefreshMemory();
		}


		// Runs when the "Run From Start" button is clicked
		private void RunFromStartButton_Click(object sender, EventArgs e)
		{
			InstanceHandler.GetCpu(0).MemoryAddress = 0;
			InstanceHandler.GetCpu(0).StartExecution();
		}


		// Runs when the "Reset" button is clicked
		private void ResetButton_Click(object sender, EventArgs e)
		{
			InstanceHandler.GetCpu(0).MemoryAddress = 0;
			InstanceHandler.GetCpu(0).accumulator = 0;
			programOutputBox.Clear();
			RefreshMemory();
		}


		// Runs when the "Color Scheme" button is clicked
		private void ColorSchemeButton_Click(object sender, EventArgs e)
		{
			// two variables: one to hold the background color of GUI, one to hold the button color of GUI
			// DEFAULT COLORS: Green: 4C721D and White: FFFFFF            

			//var UVUGreen = ColorTranslator.FromHtml("#4C721D");
			//var UVUWhite = ColorTranslator.FromHtml("#FFFFFF");
			//this.BackColor = UVUGreen;
			//this.chooseFile.BackColor = UVUWhite;
			//this.loadFileButton.BackColor = UVUWhite;
			//this.runButton.BackColor = UVUWhite;
			//this.stepButton.BackColor = UVUWhite;
			//this.ColorScheme.BackColor = UVUWhite;

			ColorSchemePopUp colorschemepopup = new ColorSchemePopUp();

			// subscribe to the OnSubmit event
			colorschemepopup.OnSubmit += ColorSchemePopUp_OnSubmit;
			colorschemepopup.Show();

			// pop up box for two hex colors, one for the main window, and one for the buttons
			// user should be able to enter in their own preferred hex color
			// a set of instructions, one with a textbox for inputting hex color, and a button to confirm their choice

			// re-create window with the desired new colors
		}
    }
}
