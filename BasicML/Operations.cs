using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace BasicML
{
    internal class Operations
    {
        //I/O operation:
        //READ = 10 Read a word from the keyboard into a specific location in memory.
        //WRITE = 11 Write a word from a specific location in memory to screen.

        //Load/store operations:
        //LOAD = 20 Load a word from a specific location in memory into the accumulator.
        //STORE = 21 Store a word from the accumulator into a specific location in memory.

        //Arithmetic operation:
        //ADD = 30 Add a word from a specific location in memory to the word in the accumulator (leave the result in the accumulator)
        //SUBTRACT = 31 Subtract a word from a specific location in memory from the word in the accumulator(leave the result in the accumulator)
        //DIVIDE = 32 Divide the word in the accumulator by a word from a specific location in memory(leave the result in the accumulator).
        //MULTIPLY = 33 multiply a word from a specific location in memory to the word in the accumulator(leave the result in the accumulator).


        public void Add(int address)
        {
            if (address < 0 || address > memory.Length)
            {
                throw new ArgumentOutOfRangeException("Address out of range");
            }
            accumulator += memory[address];
        }

        public void Subtract(int address)
        {
            if (address < 0 || address > memory.Length)
            {
                throw new ArgumentOutOfRangeException("Address out of range");
            }
            accumulator -= memory[address];
        }

        public int Divide(int address, int toDivide)
        {
            if (address < 0 || address > memory.Length)
            {
                throw new ArgumentOutOfRangeException("Address out of range");
            }
            accumulator += memory[address] / toDivide;
        }

        public int Multiply(int address, int toDivide)
        {
            if (address < 0 || address > memory.Length)
            {
                throw new ArgumentOutOfRangeException("Address out of range");
            }
            accumulator += memory[address] * toDivide;
        }


        //Control operation:
        //BRANCH = 40 Branch to a specific location in memory
        //BRANCHNEG = 41 Branch to a specific location in memory if the accumulator is negative.
        //BRANCHZERO = 42 Branch to a specific location in memory if the accumulator is zero.
        //HALT = 43 Stop the program

        private Dictionary<int, string> _dict = new Dictionary<int, string>();

        // constructor
        // TODO: this code only works when the instruction code only contains integer
        public Operations()
        {
            var lines = File.ReadAllLines("Operations.txt");
            _dict = lines.Select(line => line.Split('='))
                .ToDictionary(x => int.Parse(x[0]), x => x[1]);
        }

        // add elements
        public void Add(int instruction, string operation)
        {
            _dict[instruction] = operation;
        }

        // indexer: instruction code as key value
        public string this[int instruction]
        {
            get
            {
                return _dict.ContainsKey(instruction) ? _dict[instruction] : null;
            }
        }

        // retrive instruction code from operation
        public int ToInstruction(string operation)
        {
            return _dict.FirstOrDefault(x => x.Value == operation).Key;
        }
    }
}
