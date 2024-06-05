using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Emit;
using static System.Windows.Forms.LinkLabel;

namespace BasicML
{
    public partial class FormBasicML : Form
    {
        private Memory memory = new Memory();

        public FormBasicML()
        {
            InitializeComponent();
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
            // Operations to convert instruction to operation in English
            Operations operations = new Operations();

            for (int i = 0; i < memory.TotalSize; i++)
            {
                var operation = operations[memory[i].Instruction];

                // In this test case, only the READ operation is attempted.
                if (operation.Contains("READ"))
                {
                    // Input box will only works with 4 digit integer
                    InputBoxItem[] items = new InputBoxItem[]
                    {
                        new InputBoxItem("Input")
                    };
                    InputBox input = InputBox.Show("Enter input number", items, InputBoxButtons.OKCancel);

                    if (input.Result == InputBoxResult.OK)
                    {
                        // Write input Word into operand
                        memory.WriteMemory(input.Items["Input"], memory[i].Operand);

                        // Print log
                        richTextBoxLog.AppendText(operation + " " + memory[i].Operand + "\n");

                        // Refresh memory map
                        refreshMemory();
                    }
                }
            }
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
