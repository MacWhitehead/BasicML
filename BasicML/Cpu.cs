using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	//  This class is used to simulate the CPU
	public static class Cpu
	{
		/* - - - - - - - - - - Variables - - - - - - - - - - */

		// Private variables
		private static int _memoryAddress = 0;											// The memory address of the next instruction to be executed
		private static bool _executing = false;                                        // Whether or not the CPU is currently excecuting



		/* - - - - - - - - - - Properties - - - - - - - - - - */
		public static bool Executing { get { return _executing; } set { _executing = value; } }


		// Property for getting and setting the memory address
		public static int MemoryAddress
		{
			get
			{
				return _memoryAddress;
			}

			// The setter has error checking bulit in, so that the memory address cannot be set to an invalid location
			set
			{
				if ((value < 0) || (value > Memory.MAX_SIZE))
				{
					// Sets the memory address to 0 if an invalid index is given
					_memoryAddress = -1;
					//throw new IndexOutOfRangeException();
				}
				else
				{
					_memoryAddress = value;
				}
			}
		}


		// Properties that are used as convient ways to refer to commonly used variables
		public static Word CurrentWord { get { return Memory.ElementAt(_memoryAddress); } }		// Gets the word at the current memory address
		public static int CurrentOperand { get { return CurrentWord.Operand; } }       // Gets the operand from the word at the current memory address

		public static int CurrentInstruction { get { return CurrentWord.Instruction; } }       // Gets the operand from the word at the current memory address

		public static InstructionType CurrentInstructionType { get { return CurrentWord.GetInstructionType(); } }       // Gets the operand from the word at the current memory address


		/* - - - - - - - - - - Excecution - - - - - - - - - - */

		// Starts excecuting instructions until the cpu is halted or runs into an error
		public static void StartExecution()
		{
			// Resets the memory address location if it is invalid
			if ((_memoryAddress < 0) || (_memoryAddress >= Memory.MAX_SIZE))
			{
				MemoryAddress = 0;
			}

			Logging.LogLine("Starting Excecution");
			Logging.LogLine("Memory Size: " + Memory.MAX_SIZE.ToString());
			_executing = true;

			// Excecutes until told to stop
			while (_executing) 
			{
				StepExecution();

				if (CurrentWord._isBreakpoint) 
				{
					_executing = false;
					Logging.Log("Hit breakpoint.");
				}
			}
		}

		// Excecutes a single instruction, then stops
		public static void StepExecution()
		{
			try
			{
				Execute();
				StepMemoryAddresss();
			}
			catch (Exception e)
			{
				// Prints the error message included with the exception
				Logging.Log("Error Message: ");
				Logging.LogLine(e.Message);

				// Stops further excecution
				StopExecution();
			}
		}

		// Stops the cpu from excecuting further instructions
		public static void StopExecution() 
		{ 
			_executing = false;
			Logging.LogLine("Excecution Halted");
		}

		// Moves the memory address the cpu is pointing to forward 1
		private static void StepMemoryAddresss() 
		{
			_memoryAddress++;
		}

		// Executes the instruction at the current memory address
		public static void Execute()
		{
			Logging.LogLine("Current Memory Location: " + MemoryAddress.ToString() + " (" + CurrentWord.ToString() + ")	" + ExcecutionLog());

			switch (CurrentWord.GetInstructionType())
			{
				case InstructionType.Read:
					IO.Read(CurrentWord.Operand);
					break;
				case InstructionType.Write:
					IO.Write(CurrentWord.Operand);
					break;
				case InstructionType.Load:
					LoadStore.Load(CurrentWord.Operand);
					break;
				case InstructionType.Store:
					LoadStore.Store(CurrentWord.Operand);
					break;
				case InstructionType.Add:
					Arithmetic.Add(CurrentWord.Operand);
					break;
				case InstructionType.Subtract:
					Arithmetic.Subtract(CurrentWord.Operand);
					break;
				case InstructionType.Multiply:
					Arithmetic.Multiply(CurrentWord.Operand);
					break;
				case InstructionType.Divide:
					Arithmetic.Divide(CurrentWord.Operand);
					break;
				case InstructionType.Branch:
					Control.Branch(CurrentWord.Operand);
					break;
				case InstructionType.BranchNeg:
					Control.BranchNegative(CurrentWord.Operand);
					break;
				case InstructionType.BranchZero:
					Control.BranchZero(CurrentWord.Operand);
					break;
				case InstructionType.Halt:
					Control.Halt();
					break;
				default:
					throw new InvalidOperationException("Invalid instruction");
			}
		}

		public static string ExcecutionLog()
		{
			switch (CurrentWord.GetInstructionType())
			{
				case InstructionType.Read:
					return "Reading value from screen and placing it into memory at [" + CurrentWord.Operand.ToString() + "]";
				case InstructionType.Write:
					return "Writing value from memory at [" + CurrentWord.Operand.ToString() + "] to the screen";
				case InstructionType.Load:
					return "Loading value from memory at [" + CurrentWord.Operand.ToString() + "] into the accumulator";
				case InstructionType.Store:
					return "Store value from accumulator (" + Accumulator._registerContent.ToString() + ") into memory at [" + CurrentWord.Operand.ToString() + "] (" + Memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Add:
					return "Add value from accumulator (" + Accumulator._registerContent.ToString() + ") to value from memory at [" + CurrentWord.Operand.ToString() + "] (" + Memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Subtract:
					return "Subtract value from accumulator (" + Accumulator._registerContent.ToString() + ") from value from memory at [" + CurrentWord.Operand.ToString() + "] (" + Memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Multiply:
					return "Multiply value from accumulator (" + Accumulator._registerContent.ToString() + ") with value from memory at [" + CurrentWord.Operand.ToString() + "] (" + Memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Divide:
					return "Divide value from accumulator (" + Accumulator._registerContent.ToString() + ") by value from memory at [" + CurrentWord.Operand.ToString() + "] (" + Memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Branch:
					return "Branch to the memory location [" + CurrentWord.Operand.ToString() + "]";
				case InstructionType.BranchNeg:
					return "Branch to the memory location [" + CurrentWord.Operand.ToString() + "] if the value in the accumulator (" + Accumulator._registerContent.ToString() + ") is negative";
				case InstructionType.BranchZero:
					return "Branch to the memory location [" + CurrentWord.Operand.ToString() + "] if the value in the accumulator (" + Accumulator._registerContent.ToString() + ") is non-zero";
				case InstructionType.Halt:
					return "Halt further operations";
				default:
					return "Unexpected value given as instruction (" + CurrentWord.Instruction.ToString() + ")";
			}
		}
	}
}
