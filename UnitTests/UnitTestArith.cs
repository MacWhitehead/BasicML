using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicML;

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
            BasicML.Accumulator._registerContent = new BasicML.Word(12);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Add(3);

            Assert.AreEqual(Accumulator._registerContent, new BasicML.Word(14));
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

            Assert.AreEqual(Accumulator._registerContent, new BasicML.Word(4));
        }

        [TestMethod]
        // Tests subtraction - False
        public void SubtractVals2()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(10);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Subtract(3);

            Assert.AreEqual(Accumulator._registerContent, new BasicML.Word(5));
        }

        [TestMethod]
        // Tests divide - True
        public void DivideVals()
        {
            SetupSystem.RunSetup();
            Accumulator._registerContent = new BasicML.Word(12);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Divide(3);

            Assert.AreEqual(Accumulator._registerContent, new BasicML.Word(6));
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

            Assert.AreEqual(Accumulator._registerContent, new Word(20));
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
