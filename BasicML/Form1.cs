namespace BasicML
{
    public partial class FormBasicML : Form
    {
        public FormBasicML()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = "Test1.txt";
            List<string> output = new List<string>();

            output = ReadML(filePath);
            foreach (string line in output)
            {
                richTextBox1.AppendText(line + "\n");
            }
        }
        
        // temporary method to read test input
        static List<string> ReadML(string filePath)
        {
            Operations operations = new Operations();
            List<string> codes = new List<string>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                codes.Add(operations[int.Parse(line.Substring(1, 2))] + " " + line.Substring(3, 2));
            }

            return codes;
        }
    }
}
