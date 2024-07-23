using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicML
{
	public partial class FormTab : UserControl
	{
		public FormTab()
		{
			InitializeComponent();

			// Sets the initial colors for the form
			SetColors(UVU_GREEN, UVU_WHITE);

			MemoryGrid_Initialize();

			// Updates the display so it is ready for use
			RefreshTab();
		}

		public void LogToOutputBox(string message)
		{
			cpu.output += message;
			RefreshOutputBox();
		}

		public void RefreshOutputBox() 
		{
			programOutputBox.Text = cpu.output;
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{

		}

		/* - - - - - - - - - - Display Functions - - - - - - - - - - */

		// Updates the display so it shows the current state of the memory
		public void RefreshTab()
		{
			MemoryGrid_Refresh();

			Buttons_Refresh();

			RefreshOutputBox();

			accumulatorTextBox.Text = cpu.Accumulator.ToString(true);
		}




		/* - - - - - - - - - - Event Functions - - - - - - - - - - */

		// Runs when enter is pressed in the accumulator text box
		private void AccumulatorTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cpu.Accumulator.SetValue(accumulatorTextBox.Text);
				accumulatorTextBox.Text = cpu.Accumulator.ToString(true);
			}
		}

	}
}
