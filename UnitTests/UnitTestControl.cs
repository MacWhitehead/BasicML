using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using BasicML;

namespace UnitTest_Potato
{
	[TestClass]
	public class UnitTestControl
	{
		// Returns true if the CPU branches when the Branch function is run
		[TestMethod]
		public void TestBranch()
		{
			SetupSystem.RunSetup();
			Control.Branch(0);
			Control.Branch(4);

			Assert.AreEqual(Cpu.MemoryAddress, 4);
		}

		// Returns true if the CPU address returns to zero if an out of index branch location is given
		[TestMethod]
		public void TestBranchOutOfRange()
		{
			SetupSystem.RunSetup();
			Control.Branch(0);
			Control.Branch(1000);

			Assert.AreEqual(Cpu.MemoryAddress, 0);
		}


		// Returns true if the CPU branches when the BranchNegative function is run
		[TestMethod]
		public void TestBranchNegative()
		{
			SetupSystem.RunSetup();
			Accumulator._registerContent = new Word(-0001);

			Control.Branch(0);
			Control.BranchNegative(4);

			Assert.AreEqual(Cpu.MemoryAddress, 4);
		}

		// Returns true if the CPU does not branch when the BranchNegative function is run
		[TestMethod]
		public void TestBranchNegativeContradiction()
		{
			SetupSystem.RunSetup();
			Accumulator._registerContent = new Word(0001);

			Control.Branch(0);
			Control.BranchNegative(4);

			Assert.AreEqual(Cpu.MemoryAddress, 0);
		}


		// Returns true if the CPU branches when the BranchZero function is run
		[TestMethod]
		public void TestBranchZero()
		{
			SetupSystem.RunSetup();
			Accumulator._registerContent = new Word(0000);

			Control.Branch(0);
			Control.BranchZero(4);

			Assert.AreEqual(Cpu.MemoryAddress, 4);
		}

		// Returns true if the CPU does not branch when the BranchZero function is run
		[TestMethod]
		public void TestBranchZeroContradiction()
		{
			SetupSystem.RunSetup();
			Accumulator._registerContent = new Word(0001);

			Control.Branch(0);
			Control.BranchZero(4);

			Assert.AreEqual(Cpu.MemoryAddress, 0);
		}


		// Returns true if running Halt sets the cpu excecuting state to false
		[TestMethod]
		public void TestHalt()
		{
			SetupSystem.RunSetup();
			Cpu.Excecuting = true;
			Control.Halt();

			Assert.AreEqual(Cpu.Excecuting, false);
		}

		// Returns true if the cpu state remains as non-excecuting when running halt
		[TestMethod]
		public void TestHaltContradiction()
		{
			SetupSystem.RunSetup();
			Cpu.Excecuting = false;
			Control.Halt();

			Assert.AreEqual(Cpu.Excecuting, false);
		}
	}
}
