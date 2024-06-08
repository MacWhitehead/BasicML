using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	// Control operations for the CPU
	public static class Control
	{
		// Branch to a specific location in memory
		public static void Branch(int operand) 
		{
			Cpu.MemoryAddress = operand;
		}


		// Branch to a specific location in memory if the accumulator is positive
		public static void BranchNegative(int operand)
		{
			if (Accumulator._registerContent.IsNegative()) 
			{
				Branch(operand);
			}
		}


		// Branch to a specific location in memory if the accumulator is negative
		public static void BranchZero(int operand)
		{
			if (Accumulator._registerContent.IsZero())
			{
				Branch(operand);
			}
		}


		// Stop the program
		public static void Halt() 
		{ 
			Cpu.StopExecution();
		}
	}
}
