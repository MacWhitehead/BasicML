using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	//  This class is used to simulate the CPU
	internal static class Cpu
	{
		// The memory address of the next instruction to be executed
		public static int memoryAddress = 0;
		public static bool Excecuting = true;

		// Execute the instruction at the current memory address
		public static void Execute()
		{
			Instruction instruction = MainMemory.memory[memoryAddress].ToInstruction();

			switch (instruction.instructionType)
			{
				case InstructionType.Read:
					//IO.Read(instruction.address);
					break;
				case InstructionType.Write:
					//IO.Write(instruction.address);
					break;
				case InstructionType.Load:
					//LoadStore.Load(instruction.address);
					break;
				case InstructionType.Store:
					//LoadStore.Store(instruction.address);
					break;
				case InstructionType.Add:
					//Arithmetic.Add(instruction.address);
					break;
				case InstructionType.Subtract:
					//Arithmetic.Subtract(instruction.address);
					break;
				case InstructionType.Multiply:
					//Arithmetic.Multiply(instruction.address);
					break;
				case InstructionType.Divide:
					//Arithmetic.Divide(instruction.address);
					break;
				case InstructionType.Branch:
					Control.Branch(instruction.address);
					break;
				case InstructionType.BranchNeg:
					Control.BranchNegative(instruction.address);
					break;
				case InstructionType.BranchZero:
					Control.BranchZero(instruction.address);
					break;
				case InstructionType.Halt:
					Control.Halt();
					break;
				default:
					throw new InvalidOperationException("Invalid instruction");
			}
		}
	}
}
