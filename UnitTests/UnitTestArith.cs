using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicML;
using System.Net;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace UnitTests_Arithmatic
{
    [TestClass]
    public class UnitTestArithmatic
    {
        [TestMethod]
        // Tests addition - True
        public void AddTogether()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
			Console.WriteLine(InstanceHandler.GetCpu(0).Accumulator.RawValue);
			InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(12);
            Console.WriteLine(InstanceHandler.GetCpu(0).Accumulator.RawValue);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new BasicML.Word4(2));
			Console.WriteLine(InstanceHandler.GetCpu(0).Accumulator.RawValue);
			InstanceHandler.GetCpu(0).Add(3);
			Console.WriteLine(InstanceHandler.GetCpu(0).Accumulator.RawValue);
			Console.WriteLine(InstanceHandler.GetCpu(0).memory.ElementAt(3).RawValue);

			Assert.AreEqual(InstanceHandler.GetCpu(0).Accumulator.RawValue, new Word4(14).RawValue);
        }

        [TestMethod]
        // Tests addition - False
        public void AddTogether2()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
            InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(6);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new BasicML.Word4(2));
			InstanceHandler.GetCpu(0).Add(3);
            Assert.AreNotEqual(InstanceHandler.GetCpu(0).Accumulator, new BasicML.Word4(9));
        }

        [TestMethod]
        // Tests subtraction - True
        public void SubtractVals()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
            InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(6);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new BasicML.Word4(2));
			InstanceHandler.GetCpu(0).Subtract(3);

            Assert.AreEqual(InstanceHandler.GetCpu(0).Accumulator.RawValue, 4);
        }

        [TestMethod]
        // Tests subtraction - False
        public void SubtractVals2()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
            InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(10);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new BasicML.Word4(2));
			InstanceHandler.GetCpu(0).Subtract(3);

            Assert.AreEqual(InstanceHandler.GetCpu(0).Accumulator.RawValue, 8);
        }

        [TestMethod]
        // Tests divide - True
        public void DivideVals()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
            InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(12);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new BasicML.Word4(2));
			InstanceHandler.GetCpu(0).Divide(3);

            Assert.AreEqual(InstanceHandler.GetCpu(0).Accumulator.RawValue, 6);
        }

        [TestMethod]
        // Tests divide - false
        public void DivideVals2()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
            InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(22);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new BasicML.Word4(2));
			InstanceHandler.GetCpu(0).Divide(3);

            Assert.AreNotEqual(InstanceHandler.GetCpu(0).Accumulator, new BasicML.Word4(10));
        }

        [TestMethod]
        // Tests multiply - True
        public void MultiplyVals()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
            InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(10);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new Word4(2));
			InstanceHandler.GetCpu(0).Multiply(3);

            Assert.AreEqual(InstanceHandler.GetCpu(0).Accumulator.RawValue, 20);
        }

        [TestMethod]
        // Tests multiply - false
        public void MultiplyVals2()
        {
            SetupSystem.RunSetup(InstanceHandler.GetCpu(0));
            InstanceHandler.GetCpu(0).Accumulator = new BasicML.Word4(25);
			InstanceHandler.GetCpu(0).memory.SetElement(3, new BasicML.Word4(2));
			InstanceHandler.GetCpu(0).Multiply(3);

            Assert.AreNotEqual(InstanceHandler.GetCpu(0).Accumulator, new BasicML.Word4(55));
        }
    }
}
