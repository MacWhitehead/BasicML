using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
    internal class Word
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


		public int Instruction
		{
			get { return Math.Abs(_rawValue / 100); }
			set 
			{
				int sign = Math.Sign(_rawValue);
				if (sign == 0) { sign = 1; }

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

				_rawValue = ((Instruction * 100) + value) * sign;
			}
		}
    }
}
