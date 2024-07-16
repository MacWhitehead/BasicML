using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class LoadStore
	{
		// Load value from memory into accumulator
		public static bool Load(this Cpu cpu, int location)
		{
			if (location < Memory.MAX_SIZE)
			{
				bool returnValue = location < cpu.memory.Count;

				cpu.accumulator = cpu.memory.ElementAt(location);

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
		public static bool Store(this Cpu cpu, int location)
		{
			if ((location < 0) || (location >= Memory.MAX_SIZE)) { return false; }

			bool returnValue = location < cpu.memory.Count;

			cpu.memory.SetElement(location, cpu.accumulator);

            return returnValue;
        }



	}
}
