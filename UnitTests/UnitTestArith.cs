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
        // Tests addition
        public static bool AddTogether()
        {
			BasicML.Accumulator._registerContent = new BasicML.Word(12);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Add(3);

            if(Accumulator._registerContent == new BasicML.Word(14))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public static bool AddTogether2()
        {
            Accumulator._registerContent = new BasicML.Word(6);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Add(3);

            if (Accumulator._registerContent == new BasicML.Word(8))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public static bool SubtractVals()
        {
            Accumulator._registerContent = new BasicML.Word(6);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Subtract(3);

            if (Accumulator._registerContent == new BasicML.Word(3))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public static bool SubtractVals2()
        {
            Accumulator._registerContent = new BasicML.Word(10);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Subtract(3);

            if (Accumulator._registerContent == new BasicML.Word(5))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public static bool DivideVals()
        {
            Accumulator._registerContent = new BasicML.Word(12);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Divide(3);

            if (Accumulator._registerContent == new BasicML.Word(6))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public static bool DivideVals2()
        {
            Accumulator._registerContent = new BasicML.Word(22);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Divide(3);

            if (Accumulator._registerContent == new BasicML.Word(11))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public static bool MultiplyVals()
        {
            Accumulator._registerContent = new BasicML.Word(10);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Multiply(3);

            if (Accumulator._registerContent == new Word(20))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public static bool MultiplyVals2()
        {
            Accumulator._registerContent = new BasicML.Word(25);
			BasicML.Memory.SetElement(3, new BasicML.Word(2));
			BasicML.Arithmetic.Multiply(3);

            if (Accumulator._registerContent == new BasicML.Word(50))
            {
                return true;
            }
            return false;
        }
    }
}
