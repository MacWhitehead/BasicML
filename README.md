# BasicML Program

## Summary:
The BasicML program is a simple software that introduces computer architecture and the underlying functions to interested computer science students, professors and hobbyists alike. The program allows you to send inputs and watch how they move around in memory to achieve a desired output. The memory will open up with 100 addresses minimum to prevent overloading.

## Specifications: 
This project was created with C# 12.0 with Windows Forms. Please use Microsoft Visual Studio to run the unit tests.

## What You Need Before Using Program:

A text file with memory addresses and locations with the following format:

+/- (two digit number for memory location) (operand number)

Example: +1007, -1008

I/O operation:
READ = 10 Read a word from the keyboard into a specific location in memory.
WRITE = 11 Write a word from a specific location in memory to screen.

Load/store operations:
LOAD = 20 Load a word from a specific location in memory into the accumulator.
STORE = 21 Store a word from the accumulator into a specific location in memory.

Arithmetic operation:
ADD = 30 Add a word from a specific location in memory to the word in the accumulator (leave the result in the accumulator)
SUBTRACT = 31 Subtract a word from a specific location in memory from the word in the accumulator (leave the result in the accumulator)
DIVIDE = 32 Divide the word in the accumulator by a word from a specific location in memory (leave the result in the accumulator).
MULTIPLY = 33 multiply a word from a specific location in memory to the word in the accumulator (leave the result in the accumulator).

Control operation:
BRANCH = 40 Branch to a specific location in memory
BRANCHNEG = 41 Branch to a specific location in memory if the accumulator is negative.
BRANCHZERO = 42 Branch to a specific location in memory if the accumulator is zero.
HALT = 43 Stop the program

## Instructions:
1. Upload the text file to the program through the 'Load' option.
2. Save the test file with this name in this location: C:\Users\<username>\Source\Repos\BasicML\BasicML\bin\Debug\net8.0-windows\Test2.txt
3. Click on either Run or Step button
    - Run will run the program without breakpoints unless the user toggles a breakpoint at some point.
    - Step will run the program step by step. User can keep pressing the step button to continue the program
4. The user will see the memory contents and can add a line or delete a line if needed
5. The user can also see a log that will display errors or processes during the run.
6. Upload a new text file to start a new program.
