using BasicML;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BasicMLTests
{
    [TestClass]
    public class UnitTestMemory
    {
        [TestMethod]
        public void ParseProgram_ValidProgram_ContainsData()
        {
            // Arrange
            var program = new string[] { "+1234", "+5678", "+9012" };

            // Act
            Memory.InitMemory(program);

            // Assert
            for (int i = 0; i < program.Length; i++)
            {
                Assert.AreEqual(int.Parse(program[i].Substring(1, 2)), Memory.ElementAt(i).Instruction);
                Assert.AreEqual(int.Parse(program[i].Substring(3, 2)), Memory.ElementAt(i).Operand);
            }
        }

        [TestMethod]
        public void ParseProgram_InvalidProgramWithChar_ZeroDataWithLog()
        {
            // Arrange
            var programWithChar = new string[] { "+aaaa", "+bbbb", "+cccc" };

            // Act
            Memory.InitMemory(programWithChar);

            // Assert
            for (int i = 0; i < programWithChar.Length; i++)
            {
                Assert.AreEqual(00, Memory.ElementAt(i).Instruction);
                Assert.AreEqual(00, Memory.ElementAt(i).Operand);
            }

            Assert.IsTrue(Memory.Log != "");
        }

        [TestMethod]
        public void ParseProgram_InvalidProgramLengthLessThan5_ZeroDataWithLog()
        {
            // Arrange
            var programLengthLessThan5 = new string[] { "+111", "+222", "+333" };

            // Act
            Memory.InitMemory(programLengthLessThan5);

            // Assert
            for (int i = 0; i < programLengthLessThan5.Length; i++)
            {
                Assert.AreEqual(00, Memory.ElementAt(i).Instruction);
                Assert.AreEqual(00, Memory.ElementAt(i).Operand);
            }

            Assert.IsTrue(Memory.Log != "");
        }

        [TestMethod]
        public void ParseProgram_InvalidProgramLengthMoreThan5_ZeroDataWithLog()
        {
            // Arrange
            var programLengthMoreThan5 = new string[] { "+11111", "+22222", "+33333" };

            // Act
            Memory.InitMemory(programLengthMoreThan5);

            // Assert
            for (int i = 0; i < programLengthMoreThan5.Length; i++)
            {
                Assert.AreEqual(00, Memory.ElementAt(i).Instruction);
                Assert.AreEqual(00, Memory.ElementAt(i).Operand);
            }

            Assert.IsTrue(Memory.Log != "");
        }

        [TestMethod]
        public void WriteMemory_ValidWordAndAddress_ContainsData()
        {
            // Arrange
            var program = new Word();
            program.Instruction = 12;
            program.Operand = 34;
            var word = "+" + program.Instruction.ToString() + program.Operand.ToString();
            var address = 0;

            // Act
            Memory.WriteMemory(word, address);

            // Assert
            Assert.AreEqual(program.Instruction, Memory.ElementAt(address).Instruction);
            Assert.AreEqual(program.Operand, Memory.ElementAt(address).Operand);
        }

        [TestMethod]
        public void WriteMemory_InvalidWord_ZeroDataWithLog()
        {
            // Arrange
            var program = new Word();
            program.Instruction = 12;
            program.Operand = 34;
            var word = "+" + program.Instruction.ToString() + program.Operand.ToString() + "1234";
            var address = 50;

            // Act
            Memory.WriteMemory(word, address);

            // Assert
            Assert.AreEqual(00, Memory.ElementAt(address).Instruction);
            Assert.AreEqual(00, Memory.ElementAt(address).Operand);

            Assert.IsTrue(Memory.Log != "");
        }

        [TestMethod]
        public void WriteMemory_InvalidAddress_ZeroDataWithLog()
        {
            // Arrange
            var program = new Word();
            program.Instruction = 12;
            program.Operand = 34;
            var word = "+" + program.Instruction.ToString() + program.Operand.ToString();
            var address = 999;

            // Act
            Memory.WriteMemory(word, address);

            // Assert
            Assert.AreEqual(00, Memory.ElementAt(address).Instruction);
            Assert.AreEqual(00, Memory.ElementAt(address).Operand);

            Assert.IsTrue(Memory.Log != "");
        }

        [TestMethod]
        public void ElementAt_ValidAddress_ContainsData()
        {
            // Arrange
            var program = new string[] { "+1234", "+5678", "+9012" };
            var wordList = new List<Word>();

            // Act
            Memory.InitMemory(program);
            for (int i = 0; i < program.Length; i++)
            {
                wordList.Add(Memory.ElementAt(i));
            }

            // Assert
            for (int i = 0; i < program.Length; i++)
            {
                Assert.AreEqual(wordList.ElementAt(i).Instruction, Memory.ElementAt(i).Instruction);
                Assert.AreEqual(wordList.ElementAt(i).Operand, Memory.ElementAt(i).Operand);
            }
        }

        [TestMethod]
        public void ElementAt_InvalidAddress_ZeroDataWithLog()
        {
            // Arrange
            var program = new string[] { "+1234", "+5678", "+9012" };
            var address = 999;

            // Act
            Memory.InitMemory(program);

            // Assert
            Assert.AreEqual(00, Memory.ElementAt(address).Instruction);
            Assert.AreEqual(00, Memory.ElementAt(address).Operand);

            Assert.IsTrue(Memory.Log != "");
        }

        [TestMethod]
        public void SetElement_ValidElement_ContainsData()
        {
            // Arrange
            var word = new Word();
            word.Instruction = 00;
            word.Operand = 00;
            var program = Enumerable.Repeat("+0000", 5).ToArray();
            var wordTest = new Word();
            wordTest.Instruction = 12;
            wordTest.Operand = 34;
            var address = 2;

            // Act
            Memory.InitMemory(program);
            Memory.SetElement(address, wordTest);

            // Assert
            Assert.AreEqual(wordTest.Instruction, Memory.ElementAt(address).Instruction);
            Assert.AreEqual(wordTest.Operand, Memory.ElementAt(address).Operand);
        }

        [TestMethod]
        public void SetElement_InvalidElement_ZeroDataWithLog()
        {
            // Arrange
            var word = new Word();
            word.Instruction = 00;
            word.Operand = 00;
            var program = Enumerable.Repeat("+0000", 5).ToArray();
            var wordTest = new Word();
            wordTest.Instruction = 123;
            wordTest.Operand = 345;
            var address = 2;

            // Act
            Memory.InitMemory(program);
            Memory.SetElement(address, wordTest);

            // Assert
            Assert.AreEqual(00, Memory.ElementAt(address).Instruction);
            Assert.AreEqual(00, Memory.ElementAt(address).Operand);

            Assert.IsTrue(Memory.Log != "");
        }

        [TestMethod]
        public void TotalSize_SetValidSize_SetToValidSize()
        {
            // Arrange
            var program = Enumerable.Repeat("+0000", 5).ToArray();
            var memorySize = 10;

            // Act
            Memory.InitMemory(program);
            Memory.TotalSize = memorySize;

            // Assert
            Assert.AreEqual(memorySize, Memory.TotalSize);
        }

        [TestMethod]
        public void TotalSize_SetSizeBiggerThan99_SetTo99()
        {
            // Arrange
            var program = Enumerable.Repeat("+0000", 5).ToArray();
            var memorySize = 999;

            // Act
            Memory.InitMemory(program);
            Memory.TotalSize = memorySize;

            // Assert
            Assert.AreEqual(99, Memory.TotalSize);
        }

        [TestMethod]
        public void TotalSize_SetSizeSmallerThan99_SetTo0()
        {
            // Arrange
            var program = Enumerable.Repeat("+0000", 5).ToArray();
            var memorySize = -999;

            // Act
            Memory.InitMemory(program);
            Memory.TotalSize = memorySize;

            // Assert
            Assert.AreEqual(0, Memory.TotalSize);
        }
    }
}