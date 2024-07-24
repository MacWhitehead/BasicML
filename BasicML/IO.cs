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

		// Asks the user for a value and places it into memory
		public static bool Read(this Cpu cpu, int operand)
		{
			return cpu.Read(operand, UserInput.GetUserInput());
		}

        // Places a value into memory
        public static bool Read(this Cpu cpu, int operand, string s, bool setDefaultOnFail = true)
        {
			Logging.LogLine($"Reading {s} into memory at location {operand}");

			bool success = false;

			if (cpu.UsingWord6)
			{
				success = Word6.TryParse(s, out Word6 word);
				if (success) { return cpu.Read(operand, word); }
				else if (setDefaultOnFail) { cpu.Read(operand, word); }
			}
			else
			{
				success = Word4.TryParse(s, out Word4 word);
				if (success) { return cpu.Read(operand, word); }
				else if (setDefaultOnFail) { cpu.Read(operand, word); }
			}
			return success;
        }

        // Places a value into memory
        public static bool Read(this Cpu cpu, int operand, Word word)
        {
			return cpu.memory.SetElement(operand, word);
        }


        // Write to screen from memory
        public static bool Write(this Cpu cpu, int location)
		{
			if ((location < 0) || (location >= Memory.MAX_SIZE)) { return false; }

			bool returnValue = location < cpu.memory.Count;

            cpu.output += ($"Value at location {location}: {cpu.memory.ElementAt(location).ToString()}\n");

			return returnValue;
		}

    }
}
