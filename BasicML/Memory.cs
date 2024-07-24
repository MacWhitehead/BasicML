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
	public class Memory
    {
		public string Log = "";                       // This is an internal log used for debugging

        public const int MAX_SIZE = 250;             // This is the maximum ammount of space that can be allocated

        private List<Word> wordList = new();		// This is where the underlying data is all stored

		public bool usingWord6 = false;

		public int Count 
        { 
            get { return wordList.Count; }
            set 
            {
                if (value <= 0) { wordList.Clear(); }
				else if (value < Count) { wordList.RemoveRange(value, Count - value); }
				else if (value > Count) 
                {
                    if (value > MAX_SIZE) { value = MAX_SIZE; }
                    for (int i = Count; i < value; i++) { Add(); }
                }
            }
        }

		public List<Word> memory
		{
			get
			{
				return wordList;
			}
		}


	    // Returns the Word stored at the given index
	    public Word ElementAt(int index)
        {
			if ((index >= MAX_SIZE) || (index < 0)) 
			{
				Log += $"Error: Index out of range: {index}\n";

				if (usingWord6) { return new Word6(0); }
				else { return new Word4(0); }
			}

			while (index >= Count) { Add(); }

			return wordList[index];
		}


        // Sets the word at the chosen index
        public bool SetElement(int index, Word word)
        {
            if ((index >= MAX_SIZE) || (index < 0)) { return false; }

            // Populates extra memory addresses if the program tries to access a noninitialised location that is within the memory limits of the system
            while (index >= Count)  { Add(); }

			wordList[index] = word;

            return true;
		}

		public bool SetElement(int index, string word)
		{
			if ((index >= MAX_SIZE) || (index < 0)) { return false; }

			// Populates extra memory addresses if the program tries to access a noninitialised location that is within the memory limits of the system
			while (index >= Count) { Add(); }

			// Adds a log entry if the word is not valid
			if (usingWord6)
			{
				if (!Word6.TryParse(word, out Word6 w6)) { Log += $"Error: Could not parse word: {word}\n"; }
			}
			else
			{
				if (!Word4.TryParse(word, out Word4 w4)) { Log += $"Error: Could not parse word: {word}\n"; }
			}


			wordList[index].SetValue(word);

			return true;
		}

		// Adds a word to the end of the word list
		public void Add()
		{
			Word word;

			if (usingWord6) { word = new Word6(0); }
			else { word = new Word4(0); }

			wordList.Add(word);
		}

		// Adds a word to the end of the word list
		public void Add(int i)
		{
			if (usingWord6) { wordList.Add(new Word6(i)); }
			else { wordList.Add(new Word4(i)); }
		}

		// Adds a word to the end of the word list
		public void Add(string s)
		{
			if (usingWord6) { wordList.Add(new Word6(s)); }
			else { wordList.Add(new Word4(s)); }
		}

		// Adds a word to the end of the word list
		public void Add(Word word)
        {
            // Will not add if memory is full
            if (Count >= MAX_SIZE) { return; }

            wordList.Add(word);
		}


		// Inserts a word at the chosen index
		public void AddAt(int index)
		{
			Word word;

			if (usingWord6) { word = new Word6(0); }
			else { word = new Word4(0); }

			AddAt(index, word);
		}

		// Inserts a word at the chosen index
		public void AddAt(int index, Word word)
        {
			// Will not add if memory is full
			if (Count >= MAX_SIZE) { return; }

			// Will not add if index is out of range
			if (index < 0) { return; }

			Add();

			while (Count <= index) { Add(); }

			for (int i = Count - 1; i > index; i--) { wordList[i] = wordList[i - 1]; }

			wordList[index] = word;
		}


        // Removes a word at a given index
        public void RemoveAt(int index)
        {
			wordList.RemoveAt(index);
		}


        // Clears the contents of the wordList
        public void Clear() { wordList.Clear(); }


		// Initialize memory from an array
		public void InitMemory(params Word[] memoryContents)
		{
            Clear();
            foreach (Word word in memoryContents) { Add(word); }
		}


		// Initialize memory from an array
		public void InitMemory(int[] memoryContents, bool usingWord6 = false)
		{
			this.usingWord6 = usingWord6;

			Word[] wordArray;

			if (usingWord6) { wordArray = Array.ConvertAll(memoryContents, item => (Word6)item); }
			else { wordArray = Array.ConvertAll(memoryContents, item => (Word4)item); }

            InitMemory(wordArray);
		}

		public void InitMemory(string[] memoryContents, bool usingWord6 = false)
		{
			this.usingWord6 = usingWord6;

			Word[] wordArray;

			if (usingWord6) { wordArray = Array.ConvertAll(memoryContents, item => (Word6)item); }
			else { wordArray = Array.ConvertAll(memoryContents, item => (Word4)item); }

			InitMemory(wordArray);
		}
	}
}
