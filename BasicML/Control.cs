using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	// Control operations for the CPU
	internal static class Control
	{
		// Branch to a specific location in memory
		public static void Branch(this Cpu cpu) { cpu.MemoryAddress = cpu.CurrentOperand; }


		// Branch to a specific location in memory if the accumulator is positive
		public static void BranchNegative(this Cpu cpu)
		{
			if (cpu.Accumulator.RegisterContent.IsNegative()) { cpu.Branch(); }
		}


		// Branch to a specific location in memory if the accumulator is negative
		public static void BranchZero(this Cpu cpu)
		{
			if (cpu.Accumulator.RegisterContent.IsZero()) { cpu.Branch(); }
		}


		// Stop the program
		public static void Halt(this Cpu cpu) { cpu.StopExcution(); }
	}
}
