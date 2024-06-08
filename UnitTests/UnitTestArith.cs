using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicML;
using System.Net;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace BasicML.UnitTestArith
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        // Tests addition - True
        public void AddTogether()
        {
            SetupSystem.RunSetup();
			Console.WriteLine(Accumulator._registerContent._rawValue);
			BasicML.Accumulator._registerContent = new BasicML.Word(12);
            Console.WriteLine(Accumulator._registerContent._rawValue);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			Console.WriteLine(Accumulator._registerContent._rawValue);
			BasicML.Arithmetic.Add(3);
			Console.WriteLine(Accumulator._registerContent._rawValue);
			Console.WriteLine(Memory.ElementAt(3)._rawValue);

			Assert.AreEqual(Accumulator._registerContent._rawValue, new BasicML.Word(14)._rawValue);
        }

        [TestMethod]
        // Tests addition - False
        public void AddTogether2()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(6);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Add(3);
            Assert.AreNotEqual(Accumulator._registerContent, new BasicML.Word(9));
        }

        [TestMethod]
        // Tests subtraction - True
        public void SubtractVals()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(6);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Subtract(3);

            Assert.AreEqual(Accumulator._registerContent._rawValue, 4);
        }

        [TestMethod]
        // Tests subtraction - False
        public void SubtractVals2()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(10);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Subtract(3);

            Assert.AreEqual(Accumulator._registerContent._rawValue, 8);
        }

        [TestMethod]
        // Tests divide - True
        public void DivideVals()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(12);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Divide(3);

            Assert.AreEqual(Accumulator._registerContent._rawValue, 6);
        }

        [TestMethod]
        // Tests divide - false
        public void DivideVals2()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(22);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Divide(3);

            Assert.AreNotEqual(Accumulator._registerContent, new BasicML.Word(10));
        }

        [TestMethod]
        // Tests multiply - True
        public void MultiplyVals()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(10);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Multiply(3);

            Assert.AreEqual(Accumulator._registerContent._rawValue, 20);
        }

        [TestMethod]
        // Tests multiply - false
        public void MultiplyVals2()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(25);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Multiply(3);

            Assert.AreNotEqual(Accumulator._registerContent, new BasicML.Word(55));
        }
    }
}
