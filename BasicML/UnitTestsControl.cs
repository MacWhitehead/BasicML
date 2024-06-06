using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML.UnitTests
{
	// Unit test for the Control class
	internal class ControlTests
	{
		/*
		// Runs the tests
		public List<bool> RunTests()
		{
			// Creates list for storing results
			List<bool> _results = new();


			// Test Branch
			_results.Add(TestBranch());


			// Test BranchNegative
			//_cpu.Accumulator.RegisterContent = new Word(-0001);
			_results.Add(TestBranchNegative());

			//_cpu.Accumulator.RegisterContent = new Word(0001);
			_results.Add(!TestBranchNegative());


			// Test BranchZero
			//_cpu.Accumulator.RegisterContent = new Word(0000);
			_results.Add(TestBranchZero());

			//_cpu.Accumulator.RegisterContent = new Word(0001);
			_results.Add(TestBranchZero());


			// Test Halt
			_results.Add(TestHalt());


			// Returns results
			return _results;

		}


		// Returns true if the CPU branches when the Branch function is run
		public bool TestBranch()
		{
			Branch(0);
			Branch(69);

			if (Cpu.MemoryAddress == 69) { return true; }
			return false;

		}


		// Returns true if the CPU branches when the BranchNegative function is run
		public bool TestBranchNegative()
		{
			Cpu.Branch(0);
			Cpu.BranchNegative(69);

			if (_cpu.MemoryAddress == 69) { return true; }
			return false;
		}


		// Returns true if the CPU branches when the BranchZero function is run
		public bool TestBranchZero()
		{
			_cpu.Branch(0);
			_cpu.BranchNegative(69);

			if (_cpu.MemoryAddress == 69) { return true; }
			return false;
		}


		// Returns true if running Halt sets the cpu excecuting state to false
		public bool TestHalt()
		{
			_cpu.Excecuting	= true;
			_cpu.Halt();
			
			if (_cpu.Excecuting) { return false; }
			return true;
		}
		*/
	}
}
