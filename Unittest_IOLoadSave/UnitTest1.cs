using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicML;

namespace Unittest_IOLoadSave
{
    [TestClass]
    public class UnitTest1
    {
        // READ

        [TestMethod]
        // reject an empty string
        public void Read_RejectEmptyString_Fail()
        {
            Operations operations = new Operations();

            string inputString = "\n"; // simulate user input

            StringReader sr = new StringReader(inputString)

            Console.SetOut(_consoleOutput);

            operations.Read(inputString);

            string expectedOutput = "Successfully stored;
            Assert.AreNotEqual(expectedoutput, _consoleOutput.ToString());
  
        }

        // READ

        [TestMethod]
        // accept the right string, pass
        public void Read_AcceptCorrectString_Pass()
        {
            Operations operations = new Operations();
            string inputString = "+1007";

            StringReader sr = new StringReader(inputString)

            Console.SetOut(_consoleOutput);

            operations.Read(inputString);

            string expectedOutput = "Successfully stored;
            Assert.AreEqual(expectedoutput, _consoleOutput.ToString());
        }

        // WRITE

        [TestMethod]
        // Pass if successfully output word from memory location
        public void Write_OutputCorrectWord_Pass()
        {
            Operations operations = new Operations();
            int location = 01; // replace this as needed, unsure what to use for test
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect Console.WriteLine to StringWriter
                operations.Write(01); // Assuming location 01 exists in memory

                // Assert
                var expectedOutput = $"Value at location 01: Value1{Environment.NewLine}";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        // WRITE 

        [TestMethod]
        // Fail if location contains no value
        public void Write_NoValueFound_Fail()
        {
            Operations operations = new Operations();
            int location = 99; // replace this as needed
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect Console.WriteLine to StringWriter
                operations.Write(01); // Assuming location 01 exists in memory

                // Assert
                var expectedOutput = $"Value at location 01: Value1{Environment.NewLine}";
                Assert.AreNotEqual(expectedOutput, sw.ToString());
            }


        }

        // LOAD

        [TestMethod]
        // fail if location contains no value
        public void Load_NoValueFound_Fail()
        {
            Operations operations = new Operations();
            int location = 01;
            ref int accumulator = 0; // not sure what to put into this?

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect Console.WriteLine to StringWriter
                operations.Load(01, accumulator); // Assuming location 01 exists in memory

                // Assert
                var expectedOutput = "Loaded into accumulator";
                Assert.AreNotEqual(expectedOutput, sw.ToString());
            }
        }

        //LOAD

        [TestMethod]
        // pass if location contains a value
        public void Load_ValueFound_Pass()
        {
            Operations operations = new Operations();
            int location = 01;
            ref int accumulator = 0; // not sure what to put into this?

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect Console.WriteLine to StringWriter
                operations.Write(01, accumulator); // Assuming location 01 exists in memory

                // Assert
                var expectedOutput = "Loaded into accumulator";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        // STORE

        [TestMethod]

        public void Store_NoValueFound_Fail()
        {
            Operations operations = new Operations();
            int locations = 01;
            ref int accumulator = 0; // What to put into this?

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                operations.Store(locations, accumulator);

                // Assert
                var expectedOutput = "Store accumulator value into memory";
                Assert.AreNotEqual(expectedOutput, sw.ToString());
            }
        }
        // STORE

        [TestMethod]

        public void Store_FoundValue_Pass()
        {
            Operations operations = new Operations();
            int locations = 01;
            ref int accumulator = 0; // What to put into this?

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                operations.Store(locations, accumulator);

                // Assert
                var expectedOutput = "Store accumulator value into memory";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

    }
}
