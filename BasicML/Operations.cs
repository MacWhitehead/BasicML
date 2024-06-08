using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace BasicML
{
	internal class Operations
	{
		private Dictionary<int, string> memory = new Dictionary<int, string>();

		// Constructor
		public Operations()
		{

		}


		// Write to screen from memory
		public void Write(int location)
		{
			if (memory.ContainsKey(location))
			{
				Console.WriteLine($"Value at location {location}: {memory[location]}");
			}
			else
			{
				Console.WriteLine($"Location {location} is empty.");

			}
		}

		// Store accumulator value into memory
		public void Store(int location, int accumulator)
		{
			if (memory.ContainsKey(location))
			{
				memory[location] = accumulator.ToString();
				Console.WriteLine("Stored accumulator value into memory");
			}

			else
			{
				Console.WriteLine("Accumulator value not found");
			}

		}

		// Load value from memory into accumulator
		public void Load(int location, ref int accumulator)
		{
			if (memory.ContainsKey(location))
			{
				accumulator = int.Parse(memory[location]);
				Console.WriteLine("Loaded into accumulator");
			}

			else
			{
				Console.WriteLine($"Location {location} is empty.");
			}

		}
		// indexer: instruction code as key value
		// instructions dictionary
		public string this[int instruction]
		{
			get
			{
				return memory.ContainsKey(instruction) ? memory[instruction] : null;
			}
		}
	}
}
