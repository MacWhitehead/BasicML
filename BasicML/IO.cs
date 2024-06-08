using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class IO
	{

		public static bool Read(int operand)
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
				Memory.WriteMemory(input.Items["Input"], operand);
			return true;
			}

			return false;
		}

		/*
		// Read from keyboard and store in memory
		public static void Read(int location)
		{
			Console.Write("Enter a value: ");
			//string input = Console.ReadLine();
			string input = "1234";
			Memory.SetElement(location, new Word(int.Parse(input)));
		}
		*/

		// Write to screen from memory
		public static bool Write(int location)
		{
			if (Memory.TotalSize < location)
			{
                Console.WriteLine($"Value at location {location}: {Memory.ElementAt(location)}");
				return true;
            }
				
			else
			{
                Console.WriteLine($"Location {location} is empty.");
				return false;
            }

		}

    }
}
