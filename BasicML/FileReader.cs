using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	internal static class FileReader
	{
		// Reads a file matching the format of the "Test1.txt" and "Test2.txt" files provided on the "Group Project Milestone 2" page
		public static List<int> ReadFile(string filePath, bool verbose = true)
		{
			// List which stores the numbers read from the file
			List<int> _numbers = new();

			// Attempts to read the file
			try
			{
				// The entire contents of the text file
				string[] _lines = File.ReadAllLines(filePath);

				// Stores each line as an int
				foreach (string _line in _lines)
				{
					if (_line.Length > 1 && (_line[0] == '+' || _line[0] == '-') && int.TryParse(_line.Substring(1), out int number))
					{
						if (_line[0] == '-') { number = -number; }
						_numbers.Add(number);
					}
				}

				// Output the numbers for verification
				if (verbose)
				{
					Console.WriteLine("Test file Contents:");
					foreach (int num in _numbers) { Console.WriteLine(num); }
				}
			}
			catch (Exception e) { Console.WriteLine("Failed To read file: " + e.Message); }

			// Returns the array
			return _numbers;
		}

		public static void ReadFileToMemory(string filePath, bool verbose = true)
		{
			List<int> fileContent = ReadFile(filePath, verbose);

			Memory.InitMemory(fileContent.ToArray());
		}
	}
}
