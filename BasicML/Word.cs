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
		public int _rawValue = 0;

		public Word() { }

		public Word(int rawValue)
		{
			_rawValue = rawValue;
		}

		public Word(string s)
		{
			int value = 0;

			if (s != null)
			{
				if (s[0] == '-')
				{
					value = -int.Parse(s.AsSpan(1));
				}
				else if (s[0] == '+')
				{
					value = int.Parse(s.AsSpan(1));
				}
				else
				{
					value = int.Parse(s);
				}
			}

			_rawValue = value;
			return;
		}


		public static Word operator +(Word a, Word b) { return new Word(a._rawValue + b._rawValue); }
		public static Word operator -(Word a, Word b) { return new Word(a._rawValue - b._rawValue); }
		public static Word operator *(Word a, Word b) { return new Word(a._rawValue * b._rawValue); }
		public static Word operator /(Word a, Word b) { return new Word(a._rawValue / b._rawValue); }

		public static bool operator ==(Word a, Word b) { return a._rawValue == b._rawValue; }
		public static bool operator !=(Word a, Word b) { return a._rawValue == b._rawValue; }

		public static bool operator ==(Word a, int i) { return a._rawValue == i; }
		public static bool operator !=(Word a, int i) { return a._rawValue == i; }

		public static implicit operator Word(int i) => new(i);
		public static implicit operator Word(string s) => new(s);

		// Returns the words value in string format
		public override string ToString()
		{
			return _rawValue.ToString();
		}

		public string ToString(bool includePositiveOperand = false)
		{
			string prefix = "";
			if (includePositiveOperand && (_rawValue > 0)) { prefix = "+"; }
			return prefix + _rawValue.ToString();
		}

		public int Instruction
		{
			get { return Math.Abs(_rawValue / 100); }
			set
			{
				int sign = Math.Sign(_rawValue);
				if (sign == 0) { sign = 1; }

				if ((value > 99) || (value < 0)) { value = 0; }

				_rawValue = ((value * 100) + Operand) * sign;
			}
		}
		public int Operand
		{
			get { return _rawValue % 100; }
			set
			{
				int sign = Math.Sign(_rawValue);
				if (sign == 0) { sign = 1; }

				if ((value > 99) || (value < 0)) { value = 0; }

				_rawValue = ((Instruction * 100) + value) * sign;
			}
		}
	}
}
