using System;
using System.Collections.Generic;
using System.Linq;
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
        private static string _log = "";


        public static Word ElementAt(int address)
        {
            return _memory.ElementAt(address);
		}

        public static void SetElement(int address, Word word)
        {
            _memory[address] = word;
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
            ParseProgram(lines);
        }

        public static void InitMemory(string[] program)
        {
            for (int i = 0; i < 100; i++)
            {
                _memory[i] = new Word();
            }

            ParseProgram(program);
        }

        public static void ParseProgram(string[] lines)
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
                    _memory[address].Instruction = resultInstruction.iParsed;
                }

                var resultOperand = parseOperand(nameof(WriteMemory), word, address);
                if (resultOperand.bResult)
                {
                    _memory[address].Operand = resultOperand.iParsed;
                }
            }
        }

        // Read from memory address to string
        // TODO: return with sign
        public static string ReadMemoryToString(int address)
        {
            return _memory[address].Instruction.ToString() + _memory[address].Operand.ToString();
        }

        public static string Log
        {
            get { return _log; }
        }
    }
}
