using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicML;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Unittest_IOLoadSave
{
	[TestClass]
	public class UnitTestIO
	{
		// READ

		[TestMethod]
		// reject an empty string
		public void Read_RejectEmptyString_Fail()
		{
            SetupSystem.RunSetup();

            string inputString = "";

			// Returns false if the input string cannot parse to a word
            bool result = BasicML.IO.Read(2, inputString);

            bool expectedoutput = false;
			Assert.AreEqual(expectedoutput, result);

		}

		// READ

		[TestMethod]
		// accept the right string, pass
		public void Read_AcceptCorrectString_Pass()
		{
            SetupSystem.RunSetup();

            string inputString = "+1007";

            // Returns true if the input string parses to a word
            bool result = BasicML.IO.Read(2, inputString);

			bool expectedoutput = true;
			Assert.AreEqual(expectedoutput, result);
		}

		// WRITE

		[TestMethod]
		// Pass if successfully output word from memory location
		public void Write_OutputCorrectWord_Pass()
		{
			SetupSystem.RunSetup();
			int location = 01; // replace this as needed, unsure what to use for test

			bool result = BasicML.LoadStore.Load(location); // Assuming location 01 exists in memory

			// Assert
			bool expectedOutput = true;
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
				Assert.AreEqual(expectedOutput, result);
			}
		}

		// LOAD

		[TestMethod]
		// fail if location contains no value
		public void Load_NoValueFound_Fail()
		{
			int location = 99;

			var result = BasicML.LoadStore.Load(location); // Assuming location 01 exists in memory

			// Assert
			var expectedOutput = false;
			Assert.AreEqual(expectedOutput, result);

		}

		//LOAD

		[TestMethod]
		// pass if location contains a value
		public void Load_ValueFound_Pass()
		{
			SetupSystem.RunSetup();
			//Operations operations = new Operations();
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
			var result = BasicML.LoadStore.Store(locations);

			// Assert
			var expectedOutput = true;
			Assert.AreEqual(expectedOutput, result);
		}

	}
}
