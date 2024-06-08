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
			_results.Add(TestBranchOutOfRange());

			// Test BranchNegative
			_results.Add(TestBranchNegative());
			_results.Add(TestBranchNegativeContradiction());

			// Test BranchZero
			_results.Add(TestBranchZero());
			_results.Add(TestBranchZeroContradiction());

			// Test Halt
			_results.Add(TestHalt());
			_results.Add(TestHaltContradiction());

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


		// Returns true if the CPU address returns to zero if an out of index branch location is given
		public static bool TestBranchOutOfRange()
		{
			Control.Branch(0);
			Control.Branch(1000);

			if (Cpu.MemoryAddress == 0) { return true; }
			return false;
		}


		// Returns true if the CPU branches when the BranchNegative function is run
		public static bool TestBranchNegative()
		{
			Accumulator._registerContent = new Word(-0001);

			Control.Branch(0);
			Control.BranchNegative(4);

			if (Cpu.MemoryAddress == 4) { return true; }
			return false;
		}

		// Returns true if the CPU does not branch when the BranchNegative function is run
		public static bool TestBranchNegativeContradiction()
		{
			Accumulator._registerContent = new Word(0001);

			Control.Branch(0);
			Control.BranchNegative(4);

			if (Cpu.MemoryAddress == 0) { return true; }
			return false;
		}


		// Returns true if the CPU branches when the BranchZero function is run
		public static bool TestBranchZero()
		{
			Accumulator._registerContent = new Word(0000);

			Control.Branch(0);
			Control.BranchZero(4);

			if (Cpu.MemoryAddress == 4) { return true; }
			return false;
		}

		// Returns true if the CPU does not branch when the BranchZero function is run
		public static bool TestBranchZeroContradiction()
		{
			Accumulator._registerContent = new Word(0001);

			Control.Branch(0);
			Control.BranchZero(4);

			if (Cpu.MemoryAddress == 0) { return true; }
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

		// Returns true if the cpu state remains as non-excecuting when running halt
		public static bool TestHaltContradiction()
		{
			Cpu.Excecuting = false;
			Control.Halt();

			if (Cpu.Excecuting) { return false; }
			return true;
		}
	}
}
