using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class Arithmetic
	{
		public static void Add(this Cpu cpu, int address)
		{
			if (address < 0 || address > Memory.MAX_SIZE)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}

			cpu.Accumulator += cpu.memory.ElementAt(address);
		}

		public static void Subtract(this Cpu cpu, int address)
		{
			if (address < 0 || address > Memory.MAX_SIZE)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}
			cpu.Accumulator -= cpu.memory.ElementAt(address);
		}

		public static void Divide(this Cpu cpu, int address)
		{
			if (address < 0 || address > Memory.MAX_SIZE)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}
			cpu.Accumulator /= cpu.memory.ElementAt(address);
		}

		public static void Multiply(this Cpu cpu, int address)
		{
			if (address < 0 || address > Memory.MAX_SIZE)
			{
				throw new ArgumentOutOfRangeException("Address out of range");
			}
			cpu.Accumulator *= cpu.memory.ElementAt(address);
		}

	}
}
