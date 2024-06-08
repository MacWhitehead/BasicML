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
			if (location < Memory.TotalSize)
			{
				Accumulator._registerContent = Memory.ElementAt(location);
				return true;
			}
			else
			{
				Cpu.LogLine($"Memory Size: {Memory.TotalSize}");
				Cpu.LogLine($"Location: {location}");
				//Cpu.LogLine($"Location {location} is empty.");
				return false;
			}
		}

		// Store accumulator value into memory
		public static bool Store(int location)
		{
			if (location == 0)
			{
                return false;

            }
            Memory.SetElement(location, Accumulator._registerContent);
            return true;

        }
		
	}
}
