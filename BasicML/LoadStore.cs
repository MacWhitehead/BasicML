using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public class LoadStore
	{
		// Load value from memory into accumulator
		public static bool Load(int location)
		{
			if (location < Memory.MAX_SIZE)
			{
				bool returnValue = location < Memory.Count;

				Accumulator._registerContent = Memory.ElementAt(location);

				return returnValue;
			}
			else
			{
				Logging.LogLine($"Memory Size: {Memory.MAX_SIZE}");
				Logging.LogLine($"Location: {location}");
				//Cpu.LogLine($"Location {location} is empty.");
				return false;
			}
		}

		// Store accumulator value into memory
		public static bool Store(int location)
		{
			if ((location < 0) || (location >= Memory.MAX_SIZE)) { return false; }

			bool returnValue = location < Memory.Count;

            Memory.SetElement(location, Accumulator._registerContent);

            return returnValue;
        }
		
	}
}
