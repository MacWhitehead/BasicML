using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	// Represents the main memory of the computer
	internal static class MainMemory { public static Word[] memory = new Word[100]; }

	// Represents a 4-digit integer
	public struct Word
	{
		private const int MIN_VALUE = 9999;
		private const int MAX_VALUE = 9999;

		public int value = 0;

		public Word(int value) { this.value = value; }

		public static Word operator +(Word a, Word b) { return new Word(a.value + b.value); }
		public static Word operator -(Word a, Word b) { return new Word(a.value - b.value); }
		public static Word operator *(Word a, Word b) { return new Word(a.value * b.value); }
		public static Word operator /(Word a, Word b) { return new Word(a.value / b.value); }

		public bool IsNegative() { return value < 0; }
		public bool IsPositive() { return value > 0; }
		public bool IsZero() { return value == 0; }

		public Instruction ToInstruction() { return new(value); }
	}

	// Represents a type of instruction to be excecuted
	public enum InstructionType
	{
		nullInstruction = 0,
		Read = 10,
		Write = 11,
		Load = 20,
		Store = 21,
		Add = 30,
		Subtract = 31,
		Divide = 32,
		Multiply = 33,
		Branch = 40,
		BranchNeg = 41,
		BranchZero = 42,
		Halt = 43
	}

	// Represents an instruction
	public struct Instruction
	{
		public Instruction(int value)
		{
			int instructionValue = value / 100;
			address = Math.Clamp(value % 100, 0, 99);

			if (Enum.IsDefined(typeof(InstructionType), instructionValue)) { instructionType = (InstructionType)instructionValue; }
			else { instructionType = InstructionType.nullInstruction; }
		}

		public InstructionType instructionType;
		public int address;
	}
}
