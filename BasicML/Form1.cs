using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

[assembly: InternalsVisibleTo("BasicMLTests")]

namespace BasicML
{
	// This file contains the functions that are used to control the form
	// Large portions relating to specific sections of the form have been moved to other files
	public partial class FormBasicML : Form
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		// These are used to access the form's controls from other classes
		public static RichTextBox? _formLoggingBox;       // The box labeled "Log" in the form



		/* - - - - - - - - - - Constructor - - - - - - - - - - */

		// Constructor
		public FormBasicML()
		{
			// Initializes the form
			InitializeComponent();

			RefreshTabContent();

			//InstanceHandler.AddInstance();

			// Sets the variables for the logging objects
			_formLoggingBox = loggingBox;

			// Updates the display so it is ready for use
			RefreshMemory();
		}



		/* - - - - - - - - - - Display Functions - - - - - - - - - - */

		// Updates the display so it shows the current state of the memory
		private void RefreshMemory()
		{
			/*
			int i = 0;
			do
			{
				InstanceHandler.GetCpu(i).memoryGrid.Refresh();
				i++;
			}
			while (i < InstanceHandler.Count);

			Buttons_Refresh();

			accumulatorTextBox.Text = InstanceHandler.GetCpu(0).Accumulator.ToString(true);
			*/
		}


	}
}
