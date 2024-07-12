using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("BasicMLTests")]

namespace BasicML
{
    // This class represents the memory for the BasicML simulator
	public static class Memory
    {
        public static string Log;                       // This is an internal log used for debugging

        public const int MAX_SIZE = 100;                // This is the maximum ammount of space that can be allocated

        private static List<Word> wordList = new();     // This is where the underlying data is all stored

        public static int Count 
        { 
            get { return wordList.Count; }
            set 
            {
                if (value <= 0) { wordList.Clear(); }
				else if (value < Count) { wordList.RemoveRange(value, Count - value); }
				else if (value > Count) 
                {
                    if (value > MAX_SIZE) { value = MAX_SIZE; }
                    for (int i = Count; i < value; i++) { Add(new Word(0)); }
                }
            }
        }

		public static List<Word> memory
		{
			get
			{
				return wordList;
			}
		}


	    // Returns the Word stored at the given index
	    public static Word ElementAt(int index)
        {
			if ((index >= MAX_SIZE) || (index < 0)) { return new Word(0); }

			while (index >= Count) { Add(new Word(0)); }

			return wordList[index];
		}


        // Sets the word at the chosen index
        public static bool SetElement(int index, Word word)
        {
            if ((index >= MAX_SIZE) || (index < 0)) { return false; }

            // Populates extra memory addresses if the program tries to access a noninitialised location that is within the memory limits of the system
            while (index >= Count)  { Add(new Word(0)); }

			wordList[index] = word;

            return true;
		}

		public static bool SetElement(int index, string word)
		{
			if ((index >= MAX_SIZE) || (index < 0)) { return false; }

			// Populates extra memory addresses if the program tries to access a noninitialised location that is within the memory limits of the system
			while (index >= Count) { Add(new Word(0)); }

			// Adds a log entry if the word is not valid
			if (!Word.TryParse(word)) { Log += $"Error: Could not parse word: {word}\n"; }

			wordList[index] = word;

			return true;
		}


		// Adds a word to the end of the word list
		public static void Add(Word word)
        {
            // Will not add if memory is full
            if (Count >= MAX_SIZE) { return; }

            wordList.Add(word);
		}


        // Inserts a word at the chosen index
        public static void AddAt(int index, Word word)
        {
			// Will not add if memory is full
			if (Count >= MAX_SIZE) { return; }

			// Will not add if index is out of range
			if (index < 0) { return; }

			
			Add(0);

			while (Count <= index) { Add(0); }

			for (int i = Count - 1; i > index; i--) { wordList[i] = wordList[i - 1]; }

			wordList[index] = word;
		}


        // Removes a word at a given index
        public static void RemoveAt(int index)
        {
			wordList.RemoveAt(index);
		}


        // Clears the contents of the wordList
        public static void Clear() { wordList.Clear(); }


		// Initialize memory from an array
		public static void InitMemory(params Word[] memoryContents)
		{
            Clear();
            foreach (Word word in memoryContents) { Add(word); }
		}


		// Initialize memory from an array
		public static void InitMemory(params int[] memoryContents)
		{
            InitMemory(Array.ConvertAll(memoryContents, item => (Word)item));
		}

		// Initialize memory from an array
		public static void InitMemory(params string[] memoryContents)
		{
			InitMemory(Array.ConvertAll(memoryContents, item => (Word)item));
		}


		// Initialize memory from text file
		public static void InitMemory(string filePath)
        {
            int[] lines = FileReader.ReadFile(filePath).ToArray();
			InitMemory(lines);
        }
    }
}
