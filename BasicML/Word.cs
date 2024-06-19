using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BasicML
{
	public class Word
	{
		public bool _isBreakpoint = false;
		private int _rawValue = 0;

		public int RawValue
		{
			get { return _rawValue; }
			set 
			{
				if (value < -9999) { value = -9999; }
				else if (value > 9999) { value = 9999; }
				_rawValue = value;
			}
		}

		public Word() { }

		public Word(int rawValue)
		{
			RawValue = rawValue;
		}

		public Word(string s)
		{
			Word word = new();
			TryParse(s, out word);

			RawValue = word.RawValue;
		}

		public static bool TryParse(string s, out Word word)
		{
			bool success = false;
			int value = 0;

			if (s != null)
			{
				if (s[0] == '-') 
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


		public static Word operator +(Word a, Word b) { return new Word(a.RawValue + b.RawValue); }
		public static Word operator -(Word a, Word b) { return new Word(a.RawValue - b.RawValue); }
		public static Word operator *(Word a, Word b) { return new Word(a.RawValue * b.RawValue); }
		public static Word operator /(Word a, Word b) { return new Word(a.RawValue / b.RawValue); }

		public static bool operator ==(Word a, Word b) { return a.RawValue == b.RawValue; }
		public static bool operator !=(Word a, Word b) { return a.RawValue == b.RawValue; }

		public static bool operator ==(Word a, int i) { return a.RawValue == i; }
		public static bool operator !=(Word a, int i) { return a.RawValue == i; }

		public static implicit operator Word(int i) => new(i);
		public static implicit operator Word(string s) => new(s);

		// Returns the words value in string format
		public string ToString(bool includePositiveOperand = false)
		{
			string output = Math.Abs(RawValue).ToString().PadLeft(4, '0');

			if (RawValue < 0) { output = "-" + output; }
			else if (includePositiveOperand) { output = "+" + output; }
			
			return output;
		}

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
	}
}
