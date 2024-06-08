using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public class LoadStore
	{
		// Load value from memory into accumulator
		public static void Load(int location)
		{
			if (location < Memory.TotalSize)
			{
				Accumulator._registerContent = Memory.ElementAt(location);
			}
			else
			{
				Cpu.LogLine($"Memory Size: {Memory.TotalSize}");
				Cpu.LogLine($"Location: {location}");
				//Cpu.LogLine($"Location {location} is empty.");
			}
		}

		// Store accumulator value into memory
		public static void Store(int location)
		{
			Memory.SetElement(location, Accumulator._registerContent);
		}
	}
}
