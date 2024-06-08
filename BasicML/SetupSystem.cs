using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class SetupSystem
	{
		public static void RunSetup()
		{
			// Initialize memory and loading Test file
			Memory.InitMemory("Test2.txt");

			// Output memory as a memory map
			for (int i = 0; i < Memory.TotalSize; i++)
			{
				// In case of operand is smaller than 10 because operand is int
				var operand = "";
				if (Memory.ElementAt(i).Operand < 10)
				{
					operand = "0" + Memory.ElementAt(i).Operand.ToString();
				}
				else
				{
					operand = Memory.ElementAt(i).Operand.ToString();
				}
			}
		}
	}
}
