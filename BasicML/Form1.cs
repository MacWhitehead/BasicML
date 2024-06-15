using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Emit;
using static System.Windows.Forms.LinkLabel;

namespace BasicML
{
    public partial class FormBasicML : Form
    {
		// Operations to convert instruction to operation in English
		Operations operations = new Operations();

        public FormBasicML()
        {
            InitializeComponent();
        }

        // Open the test input text
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Initialize memory and loading Test file
            //Memory.InitMemory("Test2.txt");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxMemory.Clear();

                    //Get the path of specified file
                    Memory.InitMemory(openFileDialog.FileName);

                    // Output memory as a memory map
                    for (int i = 0; i < Memory.TotalSize; i++)
                    {
                        // In case of operand is smaller than 10 because operand is int
                        var operand = "";
                        if (Memory.ElementAt(i).Operand < 10)
                        {
                            operand = "0" + Memory.ElementAt(i).Operand.ToString();
                        }
                        else
                        {
                            operand = Memory.ElementAt(i).Operand.ToString();
                        }

                        // Memory address number, memory instruction in integer, memory operand in two digit number
                        richTextBoxMemory.AppendText(i.ToString() + " " + Memory.ElementAt(i).Instruction.ToString() + " " + operand + "\n");
                    }
                }
            }
        }

        // Run the test program
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Cpu._logBox = richTextBoxLog;

			// Starts the cpu exececuting
			Cpu.StartExecution();

            refreshMemory();

		}

		private void refreshMemory()
        {
            richTextBoxMemory.Clear();

            for (int i = 0; i < Memory.TotalSize; i++)
            {
                var operand = "";
                if (Memory.ElementAt(i).Operand < 10)
                {
                    operand = "0" + Memory.ElementAt(i).Operand.ToString();
                }
                else
                {
                    operand = Memory.ElementAt(i).Operand.ToString();
                }
                richTextBoxMemory.AppendText(i.ToString() + " " + Memory.ElementAt(i).Instruction.ToString() + " " + operand + "\n");
            }
        }
    }
}
