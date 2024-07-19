using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	internal static class Word_Extensions
	{
		// Returns true is the value stored in the word is negative
		public static bool IsNegative(this Word word) { return word.RawValue < 0; }


		// Returns true is the value stored in the word is positive
		public static bool IsPositive(this Word word) { return word.RawValue > 0; }


		// Returns true is the value stored in the word is exactly 0
		public static bool IsZero(this Word word) { return word.RawValue == 0; }


		// Clears the value stored in the word
		public static void Clear(this Word word) { word.RawValue = 0; }


		// Returns an enum which represents the instruction type stored in the word
		public static InstructionType GetInstructionType(this Word word)
		{
			if (Enum.IsDefined(typeof(InstructionType), word.Instruction)) { return (InstructionType)word.Instruction; }
			else { return InstructionType.NullInstruction; }
		}
	}

	// Represents a type of instruction to be excecuted
	public enum InstructionType
	{
		NullInstruction = 0,
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
}
