using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicML
{
    internal class Memory
    {
        // TODO: change to interface
        private Word[] _memory;
        private int _memorySize = 0;
        private int _accumulator = 0;

        // Constructor
        public Memory()
        {
            _memory = new Word[100];
            for (int i = 0; i < 100; i++)
            {
                _memory[i] = new Word();
            }
        }

        // Indexer: access word from memory address
        public Word this[int address]
        {
            get
            {
                return _memory.ElementAt(address);
            }

            set
            {
                _memory[address] = value;
            }
        }

        public int GetInstrction(int address)
        {
            return _memory[address].Instruction;
        }

        public void SetInstrction(int address, int value)
        {
            _memory[address].Instruction = value;
        }

        public int GetOperand(int address)
        {
            return _memory[address].Operand;
        }

        public void SetOperand(int address, int value)
        {
            _memory[address].Operand = value;
        }

        public int GetAccumulator()
        {
            return _accumulator;
        }

        public void SetAccumulator(int value)
        {
            _accumulator = value;
        }
        
        // Memory size from InitMemory
        public int TotalSize
        {
            get
            {
                return _memorySize;
            }

            set
            {
                _memorySize = value;
            }
        }

        // Initialize memory from text file
        public void InitMemory(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                _memory[_memorySize].Instruction = int.Parse(line.Substring(1, 2));
                _memory[_memorySize].Operand = int.Parse(line.Substring(3, 2));
                _memorySize++;
            }
        }

        // Write Word into memory address
        public void WriteMemory(string word, int address)
        {
            _memory[address].Instruction = int.Parse(word.Substring(0, 2));
            _memory[address].Operand = int.Parse(word.Substring(2, 2));
        }

        // Read from memory address to string
        public string ReadMemoryToString(int address)
        {
            return _memory[address].Instruction.ToString() + _memory[address].Operand.ToString();
        }
    }
}
