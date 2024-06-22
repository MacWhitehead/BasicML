using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BasicML
{
	// This class represents the data stored in one block of memory used by the BasicML Language
	public class Word
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		public bool _isBreakpoint = false;		// This is true if the CPU should halt before excecuting this instruction
		private int _rawValue = 0;              // This is the data stored by the cpu



		/* - - - - - - - - - - Parameters - - - - - - - - - - */

		// This is used to safely interface with the _rawValue variable as it does not allow invalid values to be set
		public int RawValue
		{
			get { return _rawValue; }
			set 
			{
				if ((value > 9999) || (value < -9999))
				{
					Logging.LogLine("Overflow occured. Truncating word value");
					value %= 10000;
				}

				_rawValue = value;
			}
		}


		// This is a convient way to read or write only the first two digits of the word
		public int Instruction
		{
			get { return Math.Abs(RawValue / 100); }
			set
			{
				int sign = Math.Sign(RawValue);
				if (sign == 0) { sign = 1; }

				if ((value > 99) || (value < 0)) { value = 0; }

				RawValue = ((value * 100) + Operand) * sign;
			}
		}


		// This is a convient way to read or write only the last two digits of the word
		public int Operand
		{
			get { return RawValue % 100; }
			set
			{
				int sign = Math.Sign(RawValue);
				if (sign == 0) { sign = 1; }

				if ((value > 99) || (value < 0)) { value = 0; }

				RawValue = ((Instruction * 100) + value) * sign;
			}
		}



		/* - - - - - - - - - - Constructors - - - - - - - - - - */

		// Default Constuctor
		public Word() { }


		// Creates a Word object with its value equal to a given int
		public Word(int rawValue) { RawValue = rawValue; }


		// Creates a Word object with its value parsed from a string
		public Word(string s)
		{
			Word word = Parse(s);
			RawValue = word.RawValue;
		}



		/* - - - - - - - - - - Parsing/Casting Functions - - - - - - - - - - */

		// This returns a word object with it's value parsed from a string
		public static Word Parse(string s)
		{
			TryParse(s, out Word word);
			return word;
        }


		// This returns a bool signifying whether or not a string value can be cleanly parsed to a word. It also has the option of additionally returning the parsed word as an out variable
		public static bool TryParse(string s, out Word word)
		{
			bool success = false;
			int value = 0;

			if (s != null)
			{
				if (s.Length == 0) { success = false; }
				else if (s[0] == '-')
				{
					success = int.TryParse(s.AsSpan(1), out value);
					value = -value;
				}
				else if (s[0] == '+') { success = int.TryParse(s.AsSpan(1), out value); }
				else { success = int.TryParse(s, out value); }
			}

			word = new Word(value);
			return success;
		}


		// Returns the words value in a string format
		public string ToString(bool includePositiveOperand = false)
		{
			string output = Math.Abs(RawValue).ToString().PadLeft(4, '0');

			if (RawValue < 0) { output = "-" + output; }
			else if (includePositiveOperand) { output = "+" + output; }

			return output;
		}



		/* - - - - - - - - - - Operator Overloads - - - - - - - - - - */

		public static Word operator +(Word a, Word b) { return new Word(a.RawValue + b.RawValue); }		// Defines how an addition operator should be applied when used with two words
		public static Word operator -(Word a, Word b) { return new Word(a.RawValue - b.RawValue); }     // Defines how a subtraction operator should be applied when used with two words
		public static Word operator *(Word a, Word b) { return new Word(a.RawValue * b.RawValue); }     // Defines how a multiplication operator should be applied when used with two words
		public static Word operator /(Word a, Word b) { return new Word(a.RawValue / b.RawValue); }     // Defines how a division operator should be applied when used with two words

		public static bool operator ==(Word a, Word b) { return a.RawValue == b.RawValue; }             // Defines how an equality operator should be applied when used with two words
		public static bool operator !=(Word a, Word b) { return a.RawValue == b.RawValue; }             // Defines how an inequality operator should be applied when used with two words

		public static bool operator ==(Word a, int i) { return a.RawValue == i; }                       // Defines how an equality operator should be applied when used with a word and an int
		public static bool operator !=(Word a, int i) { return a.RawValue == i; }                       // Defines how an inequality operator should be applied when used with a word and an int

		public static implicit operator Word(int i) => new(i);                                          // Allows implicit conversion to a Word from an int
		public static implicit operator Word(string s) => new(s);                                       // Allows implicit conversion to a Word from a string

	}
}
