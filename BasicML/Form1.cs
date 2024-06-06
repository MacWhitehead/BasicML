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
		private Memory memory = new Memory();
        private Cpu cpu;

        public FormBasicML()
        {
            InitializeComponent();
            cpu = new Cpu(memory, richTextBoxLog);
        }

        // Open the test input text
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Initialize memory and loading Test file
            memory.InitMemory("Test1.txt");

            // Output memory as a memory map
            for (int i = 0; i < memory.TotalSize; i++)
            {
                // In case of operand is smaller than 10 because operand is int
                var operand = "";
                if (memory[i].Operand < 10)
                {
                    operand = "0" + memory[i].Operand.ToString();
                }
                else
                {
                    operand = memory[i].Operand.ToString();
                }

                // Memory address number, memory instruction in integer, memory operand in two digit number
                richTextBoxMemory.AppendText(i.ToString() + " " + memory[i].Instruction.ToString() + " " + operand + "\n");
            }
        }

        // Run the test program
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Starts the cpu exececuting
            cpu.StartExecution();
        }

		private void refreshMemory()
        {
            richTextBoxMemory.Clear();

            for (int i = 0; i < memory.TotalSize; i++)
            {
                var operand = "";
                if (memory[i].Operand < 10)
                {
                    operand = "0" + memory[i].Operand.ToString();
                }
                else
                {
                    operand = memory[i].Operand.ToString();
                }
                richTextBoxMemory.AppendText(i.ToString() + " " + memory[i].Instruction.ToString() + " " + operand + "\n");
            }
        }
    }
}
