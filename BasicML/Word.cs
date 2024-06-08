using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
    public class Word
    {
        public Word() { }

        public Word(int rawValue) 
        {
            Instruction = rawValue / 100;
            Operand = rawValue % 100;
        }

		public int RawValue { get { return (Instruction * 100) + Operand; } }

		public static Word operator +(Word a, Word b) { return new Word(a.RawValue + b.RawValue); }
		public static Word operator -(Word a, Word b) { return new Word(a.RawValue - b.RawValue); }
		public static Word operator *(Word a, Word b) { return new Word(a.RawValue * b.RawValue); }
		public static Word operator /(Word a, Word b) { return new Word(a.RawValue / b.RawValue); }

		// note: needs to add sign
		public int Instruction {  get; set; }
        public int Operand { get; set; }
    }
}
