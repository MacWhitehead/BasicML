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
		public bool Write(int location)
		{
			if (memory.ContainsKey(location))
			{
				Console.WriteLine($"Value at location {location}: {memory[location]}");
				return true;
			}
			return false;
		}

		// Store accumulator value into memory
		public bool Store(int location, int accumulator)
		{
			if (memory.ContainsKey(location))
			{
				memory[location] = accumulator.ToString();
				return true;
			}

			return false;

		}

		// Load value from memory into accumulator
		public bool Load(int location, ref int accumulator)
		{
			if (memory.ContainsKey(location))
			{
				accumulator = int.Parse(memory[location]);
				return true;
			}

			return false;

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
