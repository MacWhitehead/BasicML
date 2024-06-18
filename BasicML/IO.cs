using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class IO
	{
		public static bool Read(int operand)
		{
            // Input box will only works with 4 digit integer
            var value = "";

            if (InputBox("Input", "Enter input number", ref value) == DialogResult.OK)
            {
                // Write input Word into operand
                if (value.Substring(0,1) != "+" || value.Substring(0, 1) != "-")
                {
                    value = "+" + value;
                }
                Memory.WriteMemory(value, operand);
                return true;
            }

			return false;
		}

		// Write to screen from memory
		public static bool Write(int location, RichTextBox log)
		{
            if (log != null)
            {
                if (location <= Memory.TotalSize)
                {
                    log.AppendText($"Value at location {location}: " +
                        $"{Memory.ElementAt(location).Instruction.ToString() + Memory.ElementAt(location).Operand.ToString()}");
                    log.AppendText("\n");

                    return true;
                }
                else
                {
                    log.AppendText($"Location {location} is empty.");
                    log.AppendText("\n");

                    return false;
                }
            }
            else
            {
                // else only works for UnitTests project
                if (location <= Memory.TotalSize)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
		}

        public static DialogResult InputBox(string title, string content, ref string value)
        {
            Form form = new Form();
            //PictureBox picture = new PictureBox();
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.ClientSize = new Size(300, 100);
            form.Controls.AddRange(new System.Windows.Forms.Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            form.Text = title;
            //picture.Image = Properties.Resources.Clogo;
            //picture.SizeMode = PictureBoxSizeMode.StretchImage;
            label.Text = content;
            textBox.Text = value;
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            //picture.SetBounds(10, 10, 50, 50);
            label.SetBounds(10, 17, 150, 20);
            textBox.SetBounds(10, 40, 270, 20);
            buttonOk.SetBounds(135, 70, 70, 20);
            buttonCancel.SetBounds(215, 70, 70, 20);

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }
    }
}
