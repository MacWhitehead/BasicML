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
    public partial class ColorSchemePopUp : Form
    {
        public delegate void SubmitEventHandler(string value1, string value2);
        public event SubmitEventHandler OnSubmit;

        public ColorSchemePopUp()
        {
            InitializeComponent();
        }

        private bool ValidateInput(string input)
        {
            string pattern = @"^#([0-9A-Fa-f]{6})$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
        }

        private void HexButtonSubmit_Click(object sender, EventArgs e)
        {
            string value1 = HexValueBackgroundInput.Text;
            string value2 = HexValueButtonInput.Text;

            if (ValidateInput(value1) && ValidateInput(value2))
            {
                OnSubmit?.Invoke(HexValueBackgroundInput.Text, HexValueButtonInput.Text);
                this.Close();
            }

            else
            {
                MessageBox.Show("Please enter values in the format #123ABC." +
                    " One or both values are incorrect.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
