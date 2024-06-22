using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("BasicMLTests")]

namespace BasicML
{
	public static class Memory
    {
        // TODO: change to interface
        private static Word[] _memory = new Word[100];
        private static int _memorySize = 0;
        private static int _accumulator = 0;
        public static string _log = "";


        public static Word ElementAt(int address)
        {
            if ((address < _memorySize) || (address < 0))
            {
                return _memory.ElementAt(address);
            }
            else
            {
				_log += "Invalid Index\n";
				return new Word(0);
            }
		}

        // TODO: change sign in a proper way
        public static bool SetElement(int address, Word word)
        {
            if ((address >= _memory.Length) || (address < 0)) { return false; }

            // Populates extra memory addresses if the program tries to access a noninitialised location that is within the memory limits of the system
            while (address >= TotalSize)  { Add(new Word(0)); }

			_memory[address] = word;
            return true;
		}


        public static void Add(Word word)
        {
            // Will not add if memory is full
            if (TotalSize >= _memory.Length) { return; }

            _memorySize++;
            SetElement(_memorySize - 1, word);
		}

        public static void AddAt(int index, Word word)
        {
			// Will not add if memory is full
			if (TotalSize >= _memory.Length) { return; }

            // Will not add if index is out of range
			if ((index < 0) || (index >= _memory.Length)) { return; }

			_memorySize++;

			for (int i = _memorySize - 1; i > index; i--) { _memory[i] = _memory[i - 1]; }

			_memory[index] = word;
		}

        public static void RemoveAt(int index)
        {
			_memorySize--;

			for (int i = index; i < _memorySize; i++) { _memory[i] = _memory[i + 1]; }
		}


        public static void Clear()
        {
            _memorySize = 0;
        }

        //public static int GetInstrction(int address)
        //{
        //    return _memory[address].Instruction;
        //}

        //private static void SetInstrction(int address, int value)
        //{
        //    _memory[address].Instruction = value;
        //}

        //public static int GetOperand(int address)
        //{
        //    return _memory[address].Operand;
        //}

        //private static void SetOperand(int address, int value)
        //{
        //    _memory[address].Operand = value;
        //}

        //public static int GetAccumulator()
        //{
        //    return _accumulator;
        //}

        //public static void SetAccumulator(int value)
        //{
        //    _accumulator = value;
        //}

        private static bool checkLength(string methodName, string word, int? address)
        {
            if (word.Length > 5)
            {
                if (address.HasValue)
                {
                    _log += $"{methodName}: Length is longer than 5 at line {address}\n";
                }
                else
                {
                    _log += $"{methodName}: Length is longer than 5\n";
                }
                
                return false;
            }
            else if (word.Length < 5)
            {
                if (address.HasValue)
                {
                    _log += $"{methodName}: Length is shorter than 5 at line {address}\n";
                }
                else
                {
                    _log += $"{methodName}: Length is shorter than 5\n";
                }
                
                return false;
            }
            else
            {
                return true;
            }
        }

        private static (bool bResult, int iParsed) parseInstruction(string methodName, string word, int? address)
        {
            var result = 0;

            if (int.TryParse(word.Substring(1, 2), out result))
            {
                return (true, result);
            }
            else
            {
                if (address.HasValue)
                {
                    _log += $"{methodName}: Parsing instruction error at line {address}\n";
                }
                else
                {
                    _log += $"{methodName}: Parsing instruction error\n";
                }

                return (false, -1);
            }
        }

        private static (bool bResult, int iParsed) parseOperand(string methodName, string word, int? address)
        {
            var result = 0;

            if (int.TryParse(word.Substring(3, 2), out result))
            {
                return (true, result);
            }
            else
            {
                if (address.HasValue)
                {
                    _log += $"{methodName}: Parsing operand error at line {address}\n";
                }
                else
                {
                    _log += $"{methodName}: Parsing operand error\n";
                }

                return (false, -1);
            }
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
                if (value > 99)
                {
                    _memorySize = 99;
                    _log += $"{nameof(TotalSize)}: Set memory value is larger than 99\n";
                }
                else if (value < 0)
                {
                    _memorySize = 0;
                    _log += $"{nameof(TotalSize)}: Set memory value is smaller than 0\n";
                }
                else
                {
                    _memorySize = value;
                }
            }
        }

        // Initialize memory from text file
        public static void InitMemory(string filePath)
        {
            _memorySize = 0;

            for (int i = 0; i < 100; i++)
            {
                _memory[i] = new Word();
            }

            string[] lines = File.ReadAllLines(filePath);
            ParseProgram(lines);
        }

        public static void InitMemory(string[] program)
        {
            _memorySize = 0;

            for (int i = 0; i < 100; i++)
            {
                _memory[i] = new Word();
            }

            ParseProgram(program);
        }

        private static void ParseProgram(string[] lines)
        {
            foreach (string line in lines)
            {
                if (checkLength(nameof(ParseProgram), line, _memorySize))
                {
                    var resultInstruction = parseInstruction(nameof(ParseProgram), line, _memorySize);
                    if (resultInstruction.bResult)
                    {
                        _memory[_memorySize].Instruction = resultInstruction.iParsed;
                    }

                    var resultOperand = parseOperand(nameof(ParseProgram), line, _memorySize);
                    if (resultOperand.bResult)
                    {
                        _memory[_memorySize].Operand = resultOperand.iParsed;
                    }
                }

				_memorySize++;
            }
        }

        // Write Word into memory address
        public static void WriteMemory(string word, int address)
        {
            if (checkLength(nameof(WriteMemory), word, address))
            {
                var resultInstruction = parseInstruction(nameof(WriteMemory), word, address);
                if (resultInstruction.bResult)
                {
                    if (address < 99)
                    {
                        _memory[address].Instruction = resultInstruction.iParsed;
                    }
                }

                var resultOperand = parseOperand(nameof(WriteMemory), word, address);
                if (resultOperand.bResult)
                {
                    if (address < 99)
                    {
                        _memory[address].Operand = resultOperand.iParsed;
                    }
                }
            }
        }

        // Read from memory address to string
        // TODO: return with sign
        //public static string ReadMemoryToString(int address)
        //{
        //    return _memory[address].Instruction.ToString() + _memory[address].Operand.ToString();
        //}

        public static string Log
        {
            get { return _log; }
        }
    }
}
