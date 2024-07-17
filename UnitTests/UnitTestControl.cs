using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using BasicML;

namespace UnitTests_Control
{
	[TestClass]
	public class UnitTestControl
	{
		// Returns true if the CPU branches when the Branch function is run
		[TestMethod]
		public void TestBranch()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Branch(0);
			InstanceHandler.GetCpu(0).Branch(4);

			Assert.AreEqual(InstanceHandler.GetCpu(0).MemoryAddress, 4);
		}

		// Returns true if the CPU address returns to zero if an out of index branch location is given
		[TestMethod]
		public void TestBranchOutOfRange()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Branch(0);
			InstanceHandler.GetCpu(0).Branch(1000);

			Assert.AreEqual(InstanceHandler.GetCpu(0).MemoryAddress, -1);
		}


		// Returns true if the CPU branches when the BranchNegative function is run
		[TestMethod]
		public void TestBranchNegative()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Accumulator = new Word4(-0001);

			InstanceHandler.GetCpu(0).Branch(0);
			InstanceHandler.GetCpu(0).BranchNegative(4);

			Assert.AreEqual(InstanceHandler.GetCpu(0).MemoryAddress, 4);
		}

		// Returns true if the CPU does not branch when the BranchNegative function is run
		[TestMethod]
		public void TestBranchNegativeContradiction()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Accumulator = new Word4(0001);

			InstanceHandler.GetCpu(0).Branch(0);
			InstanceHandler.GetCpu(0).BranchNegative(4);

			Assert.AreEqual(InstanceHandler.GetCpu(0).MemoryAddress, 0);
		}


		// Returns true if the CPU branches when the BranchZero function is run
		[TestMethod]
		public void TestBranchZero()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Accumulator = new Word4(0000);

			InstanceHandler.GetCpu(0).Branch(0);
			InstanceHandler.GetCpu(0).BranchZero(4);

			Assert.AreEqual(InstanceHandler.GetCpu(0).MemoryAddress, 4);
		}

		// Returns true if the CPU does not branch when the BranchZero function is run
		[TestMethod]
		public void TestBranchZeroContradiction()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Accumulator = new Word4(0001);

			InstanceHandler.GetCpu(0).Branch(0);
			InstanceHandler.GetCpu(0).BranchZero(4);

			Assert.AreEqual(InstanceHandler.GetCpu(0).MemoryAddress, 0);
		}


		// Returns true if running Halt sets the cpu excecuting state to false
		[TestMethod]
		public void TestHalt()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Executing = true;
			InstanceHandler.GetCpu(0).Halt();

			Assert.AreEqual(InstanceHandler.GetCpu(0).Executing, false);
		}

		// Returns true if the cpu state remains as non-excecuting when running halt
		[TestMethod]
		public void TestHaltContradiction()
		{
			SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			InstanceHandler.GetCpu(0).Executing = false;
			InstanceHandler.GetCpu(0).Halt();

			Assert.AreEqual(InstanceHandler.GetCpu(0).Executing, false);
		}
	}
}
