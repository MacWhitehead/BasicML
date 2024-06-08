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
            Accumulator._registerContent = new Word(12);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Add(3);

            if(Accumulator._registerContent == new Word(14))
            {
                return true;
            }
            return false;
        }

        public static bool AddTogether2()
        {
            Accumulator._registerContent = new Word(6);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Add(3);

            if (Accumulator._registerContent == new Word(8))
            {
                return true;
            }
            return false;
        }


        public static bool SubtractVals()
        {
            Accumulator._registerContent = new Word(6);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Subtract(3);

            if (Accumulator._registerContent == new Word(3))
            {
                return true;
            }
            return false;
        }

        public static bool SubtractVals2()
        {
            Accumulator._registerContent = new Word(10);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Subtract(3);

            if (Accumulator._registerContent == new Word(5))
            {
                return true;
            }
            return false;
        }

        public static bool DivideVals()
        {
            Accumulator._registerContent = new Word(12);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Divide(3);

            if (Accumulator._registerContent == new Word(6))
            {
                return true;
            }
            return false;
        }

        public static bool DivideVals2()
        {
            Accumulator._registerContent = new Word(22);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Divide(3);

            if (Accumulator._registerContent == new Word(11))
            {
                return true;
            }
            return false;
        }


        public static bool MultiplyVals()
        {
            Accumulator._registerContent = new Word(10);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Multiply(3);

            if (Accumulator._registerContent == new Word(20))
            {
                return true;
            }
            return false;
        }


        public static bool MultiplyVals2()
        {
            Accumulator._registerContent = new Word(25);
            Memory.SetElement(3, new Word(2));
            Arithmetic.Multiply(3);

            if (Accumulator._registerContent == new Word(50))
            {
                return true;
            }
            return false;
        }
    }
}
