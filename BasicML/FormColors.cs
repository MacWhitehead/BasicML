using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public partial class FormBasicML : Form
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		// Colors that are important enough to deserve a name
		private readonly Color UVU_GREEN = ColorTranslator.FromHtml("#4C721D");
		private readonly Color UVU_WHITE = ColorTranslator.FromHtml("#FFFFFF");



		/* - - - - - - - - - - Functions - - - - - - - - - - */

		// Sets the colors used by the form
		private void SetColors(Color backgroundColor, Color buttonColor)
		{
			SetBackgroundColor(backgroundColor);
			SetButtonColor(buttonColor);
		}


		// Sets the background color used by form
		private void SetBackgroundColor(Color color)
		{
			BackColor = color;
		}


		// Sets the button color used by the form
		private void SetButtonColor(Color color)
		{
			chooseFileButton.BackColor = color;
			reloadFileButton.BackColor = color;

			runButton.BackColor = color;
			runFromStartButton.BackColor = color;
			stepButton.BackColor = color;
			resetButton.BackColor = color;
		}


		// This function will change colors based on what hex values provided by the user
		private void ColorSchemePopUp_OnSubmit(string value1, string value2)
		{
			Color userBackgroundColor = ColorTranslator.FromHtml(value1);
			Color userButtonColor = ColorTranslator.FromHtml(value2);

			SetColors(userBackgroundColor, userButtonColor);
		}
	}
}
