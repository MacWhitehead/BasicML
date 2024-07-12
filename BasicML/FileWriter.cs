﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
    internal static class FileWriter
    {
        // Reads a file matching the format of the "Test1.txt" and "Test2.txt" files provided on the "Group Project Milestone 2" page
        public static void WriteMemoryToFile(string filePath)
        {
            var lines = new List<string>();
            Memory.memory.ForEach(memory =>
            {
                lines.Add(memory.ToString(true));
            });
            File.WriteAllLines(filePath, lines.ToArray());
        }
    }
}
