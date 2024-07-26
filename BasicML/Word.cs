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
	public abstract class Word
	{
		/* - - - - - - - - - - Variables! - - - - - - - - - - */

		public bool _isBreakpoint = false;		// This is true if the CPU should halt before excecuting this instruction
		protected int _rawValue = 0;              // This is the data stored by the cpu

		public abstract int MaxValue { get; }



		/* - - - - - - - - - - Parameters - - - - - - - - - - */

		//public int RawValue
		//{
		//	get { return _rawValue; }
		//	set
		//	{
		//		while (Math.Abs(value) > MaxValue)
		//		{
		//			Logging.LogLine("Overflow occured. Truncating word value");
		//			value %= 10000;
		//		}

		//		_rawValue = value;
		//	}
		//}
        public abstract int RawValue { get; set; }


        // This is a convient way to read or write only the first two digits of the word
        public abstract int Instruction { get; set; }


		// This is a convient way to read or write only the last two digits of the word
		public abstract int Operand { get; set; }



		/* - - - - - - - - - - Constructors - - - - - - - - - - */

		// Default Constuctor
		public Word() { RawValue = 0; }


		// Creates a Word object with its value equal to a given int
		public Word(int rawValue) { RawValue = rawValue; }



		// Creates a Word object with its value parsed from a string
		public Word(string s)
		{
			Word word = Parse(s);
			RawValue = word.RawValue;
		}



		/* - - - - - - - - - - Parsing/Casting Functions - - - - - - - - - - */

		public void SetValue(int i) { RawValue = i; }

		public void SetValue(string s)
		{
			if (TryParseLocal(s, out Word word)) { RawValue = word.RawValue; }
			else { RawValue = 0; }
		}

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

			if (Math.Abs(value) <= Word4.MAX_VALUE) { word = new Word4(value); }
			else { word = new Word6(value); }

			return success;
		}

		// This returns a bool signifying whether or not a string value can be cleanly parsed to a word. It also has the option of additionally returning the parsed word as an out variable
		public abstract bool TryParseLocal(string s, out Word word);

		// This returns a bool signifying whether or not a string value can be cleanly parsed to a word. It also has the option of additionally returning the parsed word as an out variable
		public static bool TryParse(string s) { return TryParse(s, out Word word); }


		// Returns the words value in a string format
		public abstract string ToString(bool includePositiveOperand = false);



		/* - - - - - - - - - - Operator Overloads - - - - - - - - - - */

		// Defines how an addition operator should be applied when used with two words
		public static Word operator +(Word a, Word b) 
		{
			if ((a.GetType() == typeof(Word6)) || (b.GetType() == typeof(Word6))) { return new Word6(a.RawValue + b.RawValue); }
			return new Word4(a.RawValue + b.RawValue);
		}

		// Defines how a subtraction operator should be applied when used with two words
		public static Word operator -(Word a, Word b)
		{
			if ((a.GetType() == typeof(Word6)) || (b.GetType() == typeof(Word6))) { return new Word6(a.RawValue - b.RawValue); }
			return new Word4(a.RawValue - b.RawValue);
		}

		// Defines how a multiplication operator should be applied when used with two words
		public static Word operator *(Word a, Word b)
		{
			if ((a.GetType() == typeof(Word6)) || (b.GetType() == typeof(Word6))) { return new Word6(a.RawValue * b.RawValue); }
			return new Word4(a.RawValue * b.RawValue);
		}

		// Defines how a division operator should be applied when used with two words
		public static Word operator /(Word a, Word b)
		{
			if ((a.GetType() == typeof(Word6)) || (b.GetType() == typeof(Word6))) { return new Word6(a.RawValue / b.RawValue); }
			return new Word4(a.RawValue / b.RawValue);
		}

		public static bool operator ==(Word a, Word b) { return a.RawValue == b.RawValue; }             // Defines how an equality operator should be applied when used with two words
		public static bool operator !=(Word a, Word b) { return a.RawValue != b.RawValue; }             // Defines how an inequality operator should be applied when used with two words

		public static bool operator ==(Word a, int i) { return a.RawValue == i; }                       // Defines how an equality operator should be applied when used with a word and an int
		public static bool operator !=(Word a, int i) { return a.RawValue != i; }                       // Defines how an inequality operator should be applied when used with a word and an int



	}
}
