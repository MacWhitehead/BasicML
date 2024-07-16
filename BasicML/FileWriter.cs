using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
    internal static class FileWriter
    {
        public static void WriteMemoryToFile(this Cpu cpu, string filePath)
        {
            var lines = new List<string>();
            cpu.memory.memory.ForEach(memory =>
            {
                lines.Add(memory.ToString(true));
            });
            File.WriteAllLines(filePath, lines.ToArray());
        }
    }
}
