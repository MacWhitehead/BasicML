using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML.UnitTests
{
	// Unit test for the Control class
	internal static class ControlTests
	{
		// Runs the tests
		public static List<bool> RunTests(bool verbose = true)
		{
			// Creates list for storing results
			List<bool> _results = new();


			// Test Branch
			_results.Add(TestBranch());


			// Test BranchNegative
			Accumulator._registerContent = new Word(-0001);
			_results.Add(TestBranchNegative());

			Accumulator._registerContent = new Word(0001);
			_results.Add(!TestBranchNegative());


			// Test BranchZero
			Accumulator._registerContent = new Word(0000);
			_results.Add(TestBranchZero());

			Accumulator._registerContent = new Word(0001);
			_results.Add(!TestBranchZero());


			// Test Halt
			_results.Add(TestHalt());

			if (verbose)
			{
				foreach (bool s in _results)
				{
					Cpu.Log(s.ToString() + ", ");
				}
				Cpu.LogLine("");
			}	

			// Returns results
			return _results;

		}


		// Returns true if the CPU branches when the Branch function is run
		public static bool TestBranch()
		{
			Control.Branch(0);
			Control.Branch(4);

			if (Cpu.MemoryAddress == 4) { return true; }
			return false;

		}


		// Returns true if the CPU branches when the BranchNegative function is run
		public static bool TestBranchNegative()
		{
			Control.Branch(0);
			Control.BranchNegative(4);

			if (Cpu.MemoryAddress == 4) { return true; }
			return false;
		}


		// Returns true if the CPU branches when the BranchZero function is run
		public static bool TestBranchZero()
		{
			Control.Branch(0);
			Control.BranchZero(4);

			if (Cpu.MemoryAddress == 4) { return true; }
			return false;
		}


		// Returns true if running Halt sets the cpu excecuting state to false
		public static bool TestHalt()
		{
			Cpu.Excecuting	= true;
			Control.Halt();
			
			if (Cpu.Excecuting) { return false; }
			return true;
		}
	}
}
