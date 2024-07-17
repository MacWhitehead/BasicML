using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	//  This class is used to simulate the CPU
	public class Cpu
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		// Private variables
		private int _memoryAddress = 0;				// The memory address of the next instruction to be executed
		private bool _executing = false;			// Whether or not the CPU is currently excecuting

		public Memory memory = new();
		private Word? accumulator;

		public Word Accumulator
		{
			get
			{
				if (accumulator is null)
				{
					if (UsingWord6) { accumulator = new Word6(0); }
					else { accumulator = new Word4(0); }
				}

				return accumulator;
			}
			set
			{
				if (accumulator is null)
				{
					if (UsingWord6) { accumulator = new Word6(0); }
					else { accumulator = new Word4(0); }
				}

				accumulator = value;
			}
		}




		/* - - - - - - - - - - Properties - - - - - - - - - - */

		public bool Executing { get { return _executing; } set { _executing = value; } }

		public bool UsingWord6 { get { return memory.usingWord6; } }


		// Property for getting and setting the memory address
		public int MemoryAddress
		{
			get { return _memoryAddress; }

			// The setter has error checking bulit in, so that the memory address cannot be set to an invalid location
			set
			{
				// Sets the memory address to -1 if an invalid index is given
				if ((value < 0) || (value > Memory.MAX_SIZE)) { _memoryAddress = -1; }
				else { _memoryAddress = value; }
			}
		}


		// Properties that are used as convient ways to refer to commonly used variables
		public Word CurrentWord { get { return memory.ElementAt(_memoryAddress); } }		// Gets the word at the current memory address
		public int CurrentOperand { get { return CurrentWord.Operand; } }       // Gets the operand from the word at the current memory address

		public int CurrentInstruction { get { return CurrentWord.Instruction; } }       // Gets the operand from the word at the current memory address

		public InstructionType CurrentInstructionType { get { return CurrentWord.GetInstructionType(); } }       // Gets the operand from the word at the current memory address



		/* - - - - - - - - - - Excecution - - - - - - - - - - */

		// Starts excecuting instructions until the cpu is halted or runs into an error
		public void StartExecution()
		{
			// Resets the memory address location if it is invalid
			if ((_memoryAddress < 0) || (_memoryAddress >= Memory.MAX_SIZE)) { MemoryAddress = 0; }

			Logging.LogLine("Starting Excecution");
			//Logging.LogLine("Memory Size: " + Memory.MAX_SIZE.ToString());
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
		public void StepExecution()
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
		public void StopExecution() 
		{ 
			_executing = false;
			Logging.LogLine("Excecution Halted");
		}


		// Moves the memory address the cpu is pointing to forward 1
		private void StepMemoryAddresss() 
		{
			_memoryAddress++;
		}


		// Executes the instruction at the current memory address
		public void Execute()
		{
			Logging.LogLine("Current Memory Location: " + MemoryAddress.ToString() + " (" + CurrentWord.ToString() + ")	" + ExcecutionLog());

			switch (CurrentWord.GetInstructionType())
			{
				case InstructionType.Read:
					this.Read(CurrentWord.Operand);
					break;
				case InstructionType.Write:
					this.Write(CurrentWord.Operand);
					break;
				case InstructionType.Load:
					this.Load(CurrentWord.Operand);
					break;
				case InstructionType.Store:
					this.Store(CurrentWord.Operand);
					break;
				case InstructionType.Add:
					this.Add(CurrentWord.Operand);
					break;
				case InstructionType.Subtract:
					this.Subtract(CurrentWord.Operand);
					break;
				case InstructionType.Multiply:
					this.Multiply(CurrentWord.Operand);
					break;
				case InstructionType.Divide:
					this.Divide(CurrentWord.Operand);
					break;
				case InstructionType.Branch:
					this.Branch(CurrentWord.Operand);
					break;
				case InstructionType.BranchNeg:
					this.BranchNegative(CurrentWord.Operand);
					break;
				case InstructionType.BranchZero:
					this.BranchZero(CurrentWord.Operand);
					break;
				case InstructionType.Halt:
					this.Halt();
					break;
				default:
					throw new InvalidOperationException("Invalid instruction");
			}
		}


		// Returns a string with log information about the current instuction's excecution
		public string ExcecutionLog()
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
					return "Store value from accumulator (" + accumulator.ToString() + ") into memory at [" + CurrentWord.Operand.ToString() + "] (" + memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Add:
					return "Add value from accumulator (" + accumulator.ToString() + ") to value from memory at [" + CurrentWord.Operand.ToString() + "] (" + memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Subtract:
					return "Subtract value from accumulator (" + accumulator.ToString() + ") from value from memory at [" + CurrentWord.Operand.ToString() + "] (" + memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Multiply:
					return "Multiply value from accumulator (" + accumulator.ToString() + ") with value from memory at [" + CurrentWord.Operand.ToString() + "] (" + memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Divide:
					return "Divide value from accumulator (" + accumulator.ToString() + ") by value from memory at [" + CurrentWord.Operand.ToString() + "] (" + memory.ElementAt(CurrentWord.Operand).ToString() + ")";
				case InstructionType.Branch:
					return "Branch to the memory location [" + CurrentWord.Operand.ToString() + "]";
				case InstructionType.BranchNeg:
					return "Branch to the memory location [" + CurrentWord.Operand.ToString() + "] if the value in the accumulator (" + accumulator.ToString() + ") is negative";
				case InstructionType.BranchZero:
					return "Branch to the memory location [" + CurrentWord.Operand.ToString() + "] if the value in the accumulator (" + accumulator.ToString() + ") is non-zero";
				case InstructionType.Halt:
					return "Halt further operations";
				default:
					return "Unexpected value given as instruction (" + CurrentWord.Instruction.ToString() + ")";
			}
		}
	}
}
