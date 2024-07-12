using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	// This file contains the functions that are used to control the file dialog
	public partial class FormBasicML : Form
	{
		// Data about the file dialog
		private static bool fileLoaded = false;
		private static string fileName = "";


		// Opens a file dialog to choose a file
		private void ChooseFile()
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 1;
				openFileDialog.RestoreDirectory = true;

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
		}


		// Loads the chosen file into memory
		private void LoadFile()
		{
			try { FileReader.ReadFileToMemory(fileTextBox.Text, false); }
			catch { Logging.Log("Could not read file"); }

			// Resets the value in the accumulator
			Accumulator._registerContent = 0;

			Cpu.MemoryAddress = 0;
		}
	}
}
