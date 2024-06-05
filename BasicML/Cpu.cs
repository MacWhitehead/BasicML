using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	//  This class is used to simulate the CPU
	internal class Cpu
	{
		/* - - - - - - - - - - Variables - - - - - - - - - - */

		// Private variables
		private int _memoryAddress = 0;											// The memory address of the next instruction to be executed
		private bool _excecuting = false;										// Whether or not the CPU is currently excecuting
		private Memory _memory = new();											// The pool of memory used by the CPU
		private Accumulator _accumulator = new();								// The accumulator for the CPU



		/* - - - - - - - - - - Properties - - - - - - - - - - */

		// Properties that are just getters for private variables
		public Memory Memory { get { return _memory; } }
		public Accumulator Accumulator { get { return _accumulator; } }

		public bool Excecuting { get; set; }


		// Property for getting and setting the memory address
		public int MemoryAddress 
		{ 
			get { return _memoryAddress; }

			// The setter has error checking bulit in, so that the memory address cannot be set to an invalid location
			set 
			{
				if ((value < 0) || (value > Memory.TotalSize)) { throw new IndexOutOfRangeException(); }
				_memoryAddress = value;
			}
		}


		// Properties that are used as convient ways to refer to commonly used variables
		public Word CurrentWord { get { return _memory[_memoryAddress]; } }		// Gets the word at the current memory address
		public int CurrentOperand { get { return CurrentWord.Operand; } }		// Gets the operand from the word at the current memory address



		/* - - - - - - - - - - Excecution - - - - - - - - - - */

		// Starts excicuting instructions until the cpu is halted or runs into an error
		public void StartExecution()
		{
			_excecuting = true;

			// Excecutes until told to stop
			while (_excecuting) 
			{
				try { Execute(); }
				catch (Exception e)
				{
					// Prints some basic debug info to the console
					PrintDebugToConsole();

					// Prints the error message included with the exception
					Console.Write("Error Message: ");
					Console.WriteLine(e.Message);

					// Stops further excecution
					StopExcution();
				}
			}
		}


		// Stops the cpu from excecuting further instructions
		public void StopExcution() 
		{ 
			_excecuting = false;
			Console.WriteLine("Excecution Halted");
		}


		// Executes the instruction at the current memory address
		public void Execute()
		{
			switch (CurrentWord.GetInstructionType())
			{
				case InstructionType.Read:
					//IO.Read();
					break;
				case InstructionType.Write:
					//IO.Write();
					break;
				case InstructionType.Load:
					//LoadStore.Load();
					break;
				case InstructionType.Store:
					//LoadStore.Store();
					break;
				case InstructionType.Add:
					//Arithmetic.Add();
					break;
				case InstructionType.Subtract:
					//Arithmetic.Subtract();
					break;
				case InstructionType.Multiply:
					//Arithmetic.Multiply();
					break;
				case InstructionType.Divide:
					//Arithmetic.Divide();
					break;
				case InstructionType.Branch:
					Control.Branch(this, CurrentWord.Operand);
					break;
				case InstructionType.BranchNeg:
					Control.BranchNegative(this, CurrentWord.Operand);
					break;
				case InstructionType.BranchZero:
					Control.BranchZero(this, CurrentWord.Operand);
					break;
				case InstructionType.Halt:
					Control.Halt(this);
					break;
				default:
					throw new InvalidOperationException("Invalid instruction");
			}
		}



		/* - - - - - - - - - - Debug - - - - - - - - - - */

		// Prints some useful debug information to the console
		private void PrintDebugToConsole()
		{
			Console.WriteLine("The CPU ran into an error during excecution.");

			Console.Write("Current Memory Address: ");
			Console.WriteLine(MemoryAddress.ToString());

			Console.Write("Memory Address Raw Value: ");
			Console.WriteLine(CurrentWord.GetRawValue().ToString());
		}
	}
}
