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
		private static Operations operations = new();									// Used for mapping the code for an operation to it's name
		public static RichTextBox _logBox;												// The location that output logs are written to

		private static int _memoryAddress = 0;											// The memory address of the next instruction to be executed
		private static bool _excecuting = false;										// Whether or not the CPU is currently excecuting



		/* - - - - - - - - - - Properties - - - - - - - - - - */
		public static bool Excecuting { get; set; }


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
				if ((value < 0) || (value > Memory.TotalSize)) { throw new IndexOutOfRangeException(); }
				_memoryAddress = value;
			}
		}


		// Properties that are used as convient ways to refer to commonly used variables
		public static Word CurrentWord { get { return Memory.ElementAt(_memoryAddress); } }		// Gets the word at the current memory address
		public static int CurrentOperand { get { return CurrentWord.Operand; } }       // Gets the operand from the word at the current memory address

		public static int CurrentInstruction { get { return CurrentWord.Instruction; } }       // Gets the operand from the word at the current memory address


		/* - - - - - - - - - - Excecution - - - - - - - - - - */

		// Starts excicuting instructions until the cpu is halted or runs into an error
		public static void StartExecution()
		{
			LogLine("Starting Excecution");
			LogLine("Memory Size: " + Memory.TotalSize.ToString());
			_excecuting = true;

			// Excecutes until told to stop
			while (_excecuting) 
			{
				try 
				{ 
					Execute();
					StepMemoryAddresss();
				}
				catch (Exception e)
				{
					// Prints some basic debug info to the console
					PrintDebugToConsole();

					// Prints the error message included with the exception
					Log("Error Message: ");
					LogLine(e.Message);

					// Stops further excecution
					StopExecution();
				}
			}

		}


		// Stops the cpu from excecuting further instructions
		public static void StopExecution() 
		{ 
			_excecuting = false;
			LogLine("Excecution Halted");
		}

		// Moves the memory address the cpu is pointing to forward 1
		private static void StepMemoryAddresss() 
		{
			_memoryAddress++;
		}

		// Executes the instruction at the current memory address
		public static void Execute()
		{
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

			LogOperation();
		}

		public static void LogOperation()
		{
			// Prints the operation that is currently selected to the log output
			string operation = CurrentInstruction.ToString();
			LogLine(operation + " " + CurrentOperand);
		}



		/* - - - - - - - - - - Debug - - - - - - - - - - */

		// Prints some useful debug information to the console
		private static void PrintDebugToConsole()
		{
			LogLine("The CPU ran into an error during excecution.");

			Log("Current Memory Address: ");
			LogLine(MemoryAddress.ToString());

			Log("Memory Address Raw Value: ");
			LogLine(CurrentWord.GetRawValue().ToString());
		}

		public static void Log(string s)
		{
			_logBox.AppendText(s);
		}

		public static void LogLine(string s)
		{
			_logBox.AppendText(s + "\n");
		}
	}
}
