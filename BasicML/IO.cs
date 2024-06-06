using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	internal static class IO
	{
		public static void Read(this Cpu cpu, int operand)
		{

				// Input box will only works with 4 digit integer
				InputBoxItem[] items = new InputBoxItem[]
				{
						new InputBoxItem("Input")
				};
				InputBox input = InputBox.Show("Enter input number", items, InputBoxButtons.OKCancel);

				if (input.Result == InputBoxResult.OK)
				{
					// Write input Word into operand
					cpu.Memory.WriteMemory(input.Items["Input"], operand);
				}
		}

	}
}
