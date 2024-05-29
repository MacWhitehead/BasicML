using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	internal class Control
	{
		// Branch to a specific location in memory
		public static void Branch(int address) 
		{ 
			if ((address < 0) || (address < MainMemory.memory.Length)) { throw new IndexOutOfRangeException();  }
			Cpu.memoryAddress = address;
		}


		// Branch to a specific location in memory if the accumulator is positive
		public static void BranchNegative(int address)
		{
			if (Accumulator.registerContent.IsNegative()) { Branch(address); }
		}


		// Branch to a specific location in memory if the accumulator is negative
		public static void BranchZero(int address)
		{
			if (Accumulator.registerContent.IsZero()) { Branch(address); }
		}


		// Stop the program
		public static void Halt()
		{
			Cpu.Excecuting = false;
			Console.WriteLine("Excecution Halted");
		}
	}
}
