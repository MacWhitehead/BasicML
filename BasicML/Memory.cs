using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicML
{
    internal static class Memory
    {
        // TODO: change to interface
        private static Word[] _memory = new Word[100];
        private static int _memorySize = 0;
        private static int _accumulator = 0;


        public static Word ElementAt(int address)
        {
            return _memory.ElementAt(address);
		}

        public static void SetElement(int address, Word word)
        {
            _memory[address] = word;
		}

        public static int GetInstrction(int address)
        {
            return _memory[address].Instruction;
        }

        public static void SetInstrction(int address, int value)
        {
            _memory[address].Instruction = value;
        }

        public static int GetOperand(int address)
        {
            return _memory[address].Operand;
        }

        public static void SetOperand(int address, int value)
        {
            _memory[address].Operand = value;
        }

        public static int GetAccumulator()
        {
            return _accumulator;
        }

        public static void SetAccumulator(int value)
        {
            _accumulator = value;
        }
        
        // Memory size from InitMemory
        public static int TotalSize
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
        public static void InitMemory(string filePath)
        {
            for (int i = 0; i < 100; i++)
            {
                _memory[i] = new Word();
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                _memory[_memorySize].Instruction = int.Parse(line.Substring(1, 2));
                _memory[_memorySize].Operand = int.Parse(line.Substring(3, 2));
                _memorySize++;
            }
        }

        // Write Word into memory address
        public static void WriteMemory(string word, int address)
        {
            _memory[address].Instruction = int.Parse(word.Substring(0, 2));
            _memory[address].Operand = int.Parse(word.Substring(2, 2));
        }

        // Read from memory address to string
        public static string ReadMemoryToString(int address)
        {
            return _memory[address].Instruction.ToString() + _memory[address].Operand.ToString();
        }
    }
}
