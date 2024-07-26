using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public class Word4 : Word
	{
		public static readonly int MAX_VALUE = 9999;

		public override int MaxValue { get { return MAX_VALUE; } }

		public Word4() : base() { }

		public Word4(string s) : base(s) { }

		public Word4(int rawValue) : base(rawValue) { }

		public override int RawValue
		{
			get { return _rawValue; }
			set
			{
				while (Math.Abs(value) > MaxValue)
				{
					Logging.LogLine("Overflow occured. Truncating word value");
					value %= 10000;
				}

				_rawValue = value;
			}
		}


		// This is a convient way to read or write only the first two digits of the word
		public override int Instruction
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
		public override int Operand
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

		public static bool TryParse(string s, out Word4 word)
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

			word = new Word4(value);

			return success;
		}

		public override bool TryParseLocal(string s, out Word word) { return Word4.TryParse(s, out word); }

		// Returns the words value in a string format
		public override string ToString(bool includePositiveOperand = false)
		{
			string output = Math.Abs(RawValue).ToString().PadLeft(4, '0');

			if (RawValue < 0) { output = "-" + output; }
			else if (includePositiveOperand) { output = "+" + output; }

			return output;
		}

		public static implicit operator Word4(int i) => new(i);                                          // Allows implicit conversion to a Word from an int
		public static implicit operator Word4(string s) => new(s);                                       // Allows implicit conversion to a Word from a string
	}
}
