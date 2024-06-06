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
		public static void Branch(this Cpu cpu, int operand) { cpu.MemoryAddress = operand; }


		// Branch to a specific location in memory if the accumulator is positive
		public static void BranchNegative(this Cpu cpu, int operand)
		{
			if (cpu.Accumulator.RegisterContent.IsNegative()) { cpu.Branch(operand); }
		}


		// Branch to a specific location in memory if the accumulator is negative
		public static void BranchZero(this Cpu cpu, int operand)
		{
			if (cpu.Accumulator.RegisterContent.IsZero()) { cpu.Branch(operand); }
		}


		// Stop the program
		public static void Halt(this Cpu cpu) { cpu.StopExecution(); }
	}
}
