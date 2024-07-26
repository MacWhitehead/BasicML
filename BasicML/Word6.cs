using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public class Word6 : Word
	{
		public static readonly int MAX_VALUE = 999999;

		public override int MaxValue { get { return MAX_VALUE; } }

		public Word6() : base() { }

		public Word6(string s) : base(s) { }

		public Word6(int rawValue) : base(rawValue) { }

        public override int RawValue
        {
            get { return _rawValue; }
            set
            {
                while (Math.Abs(value) > MaxValue)
                {
                    Logging.LogLine("Overflow occured. Truncating word value");
                    value %= 1000000;
                }

                _rawValue = value;
            }
        }


        // This is a convient way to read or write only the first three digits of the word
        public override int Instruction
		{
			get { return Math.Abs(RawValue / 1000); }
			set
			{
				int sign = Math.Sign(RawValue);
				if (sign == 0) { sign = 1; }

				if ((value > 999) || (value < 0)) { value = 0; }

				RawValue = ((value * 1000) + Operand) * sign;
			}
		}


		// This is a convient way to read or write only the last three digits of the word
		public override int Operand
		{
			get { return RawValue % 1000; }
			set
			{
				int sign = Math.Sign(RawValue);
				if (sign == 0) { sign = 1; }

				if ((value > 250) || (value < 0)) { value = 0; }

				RawValue = ((Instruction * 1000) + value) * sign;
			}
		}

		public static bool TryParse(string s, out Word6 word)
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

			word = new Word6(value);

			return success;
		}

		public override bool TryParseLocal(string s, out Word word) { return Word6.TryParse(s, out word); }

		// Returns the words value in a string format
		public override string ToString(bool includePositiveOperand = false)
		{
			string output = Math.Abs(RawValue).ToString().PadLeft(6, '0');

			if (RawValue < 0) { output = "-" + output; }
			else if (includePositiveOperand) { output = "+" + output; }

			return output;
		}

		public static implicit operator Word6(int i) => new(i);                                          // Allows implicit conversion to a Word from an int
		public static implicit operator Word6(string s) => new(s);                                       // Allows implicit conversion to a Word from a string

		//public static implicit operator Word6(Word4 w) => new(w.RawValue);								 // Allows implicit conversion to a Word from a string
	}
}
