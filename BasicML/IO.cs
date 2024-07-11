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
		public static bool Read(int operand)
		{
			return Read(operand, UserInput.GetUserInput());
		}

        // Places a value into memory
        public static bool Read(int operand, string s, bool setDefaultOnFail = true)
        {
			bool success = Word.TryParse(s, out Word word);
			if (success) { return Read(operand, word); }
			else if (setDefaultOnFail) { Read(operand, word); }
			return success;
        }

        // Places a value into memory
        public static bool Read(int operand, Word word)
        {
			return Memory.SetElement(operand, word);
        }

        // Write to screen from memory
        public static bool Write(int location)
		{
			if ((location < 0) || (location >= Memory.MAX_SIZE)) { return false; }

			bool returnValue = location < Memory.Count;

            Logging.LogLine($"Value at location {location}: {Memory.ElementAt(location).ToString()}", Logging.LoggingDestination.ProgramOutput);

			return returnValue;


		}

    }
}
