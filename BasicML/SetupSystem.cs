using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class SetupSystem
	{
		public static void RunSetup(this Cpu cpu)
		{
			cpu.memory.InitMemory("+1009", "+1010", "+2009", "+3110", "+4107", "+1109", "+4300", "+1110", "+4300", "+0000", "+0000");
		}
	}
}
