using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicML;
using Microsoft.VisualStudio.TestPlatform.Utilities;

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
			string inputString = ""; // simulate user input

			var result = BasicML.IO.Read(int.Parse(inputString));

			bool expectedoutput = false;
			Assert.AreNotEqual(expectedoutput, result);

		}

		// READ

		[TestMethod]
		// accept the right string, pass
		public void Read_AcceptCorrectString_Pass()
		{
			string inputString = "+1007";

			var result = BasicML.IO.Read(int.Parse(inputString));

			bool expectedoutput = true;
			Assert.AreEqual(expectedoutput, result);
		}

		// WRITE

		[TestMethod]
		// Pass if successfully output word from memory location
		public void Write_OutputCorrectWord_Pass()
		{
			int location = 01; // replace this as needed, unsure what to use for test

			var result = BasicML.LoadStore.Load(01); // Assuming location 01 exists in memory

			// Assert
			var expectedOutput = true;
			Assert.AreEqual(expectedOutput, result);
		}

		// WRITE 

		[TestMethod]
		// Fail if location contains no value
		public void Write_NoValueFound_Fail()
		{
			int location = 99; // replace this as needed
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw); // Redirect Console.WriteLine to StringWriter
				var result = BasicML.IO.Write(location); // Assuming location 01 exists in memory

				// Assert
				var expectedOutput = false;
				Assert.AreNotEqual(expectedOutput, result);
			}
		}

		// LOAD

		[TestMethod]
		// fail if location contains no value
		public void Load_NoValueFound_Fail()
		{
			int location = 01;

			var result = BasicML.LoadStore.Load(location); // Assuming location 01 exists in memory

			// Assert
			var expectedOutput = false;
			Assert.AreNotEqual(expectedOutput, result);

		}

		//LOAD

		[TestMethod]
		// pass if location contains a value
		public void Load_ValueFound_Pass()
		{
			int input = 1234;
			IO.Read(input);
			int location = 01;
			var result = BasicML.IO.Write(location); // Assuming location 01 exists in memory

			// Assert
			var expectedOutput = true;
			Assert.AreEqual(expectedOutput, result);
		}

		// STORE

		[TestMethod]

		public void Store_NoValueFound_Fail()
		{
			//Operations operations = new Operations();
			int locations = 01;
			var result = BasicML.LoadStore.Store(locations);

			// Assert
			var expectedOutput = false;
			Assert.AreNotEqual(expectedOutput, result);
		}
		// STORE

		[TestMethod]

		public void Store_FoundValue_Pass()
		{
			int locations = 01;
			//ref int accumulator = 0; // What to put into this?
			var result = BasicML.LoadStore.Store(locations);

			// Assert
			var expectedOutput = true;
			Assert.AreEqual(expectedOutput, result);
		}

	}
}
