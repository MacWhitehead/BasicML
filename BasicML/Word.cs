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
		public int _rawValue = 0;

		public Word() { }

		public Word(int rawValue)
		{
			_rawValue = rawValue;
		}

		public static Word operator +(Word a, Word b) { return new Word(a._rawValue + b._rawValue); }
		public static Word operator -(Word a, Word b) { return new Word(a._rawValue - b._rawValue); }
		public static Word operator *(Word a, Word b) { return new Word(a._rawValue * b._rawValue); }
		public static Word operator /(Word a, Word b) { return new Word(a._rawValue / b._rawValue); }

		public static bool operator ==(Word a, Word b) { return a._rawValue == b._rawValue; }
		public static bool operator !=(Word a, Word b) { return a._rawValue == b._rawValue; }

		public static bool operator ==(Word a, int i) { return a._rawValue == i; }
		public static bool operator !=(Word a, int i) { return a._rawValue == i; }

		public static implicit operator Word(int i) => new Word(i);

		// Returns the words value in string format
		public string ToString()
		{
			return _rawValue.ToString();
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
