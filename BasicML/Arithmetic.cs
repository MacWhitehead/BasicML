using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public class Arithmetic
	{
		public static void Add(int address)
		{
			if (address < 0 || address > Memory.TotalSize)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}

			int a = Accumulator._registerContent._rawValue;
			int b = Memory.ElementAt(address)._rawValue;

			Accumulator._registerContent = a + b;
		}

		public static void Subtract(int address)
		{
			if (address < 0 || address > Memory.TotalSize)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}
			Accumulator._registerContent -= Memory.ElementAt(address);
		}

		public static void Divide(int address)
		{
			if (address < 0 || address > Memory.TotalSize)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}
			Accumulator._registerContent /= Memory.ElementAt(address);
		}

		public static void Multiply(int address)
		{
			if (address < 0 || address > Memory.TotalSize)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}
			Accumulator._registerContent *= Memory.ElementAt(address);
		}

	}
}
