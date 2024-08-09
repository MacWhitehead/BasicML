# BasicML Program (Group Project for UVU 2450)

## Summary:
The BasicML program is a simple software that introduces computer architecture and the underlying functions to interested computer science students, professors and hobbyists alike. The program allows you to send inputs and watch how they move around in memory to achieve a desired output. The memory has a max of 250 addresses.

## Specifications: 
This project was created with C# 12.0 with Windows Forms. Please use Microsoft Visual Studio to run the unit tests.

## What You Need Before Using Program:

A text file of either a max length of 4 or 6 digit memory addresses and locations with the following format:

+/- (two digit number for memory location) (operand number)

Example: +1007, -100834, +123456

Four digit to 6 digit conversion: Add a zero for the first and third digit
Example: +1007 -> +010007

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

## Installation:
Download the program from the Releases tab and unzip it to the location of your choice. Run BasicML.exe from the folder.

## Instructions on starting program:
1. Upload the text file to the program through the 'Choose File' option for either the 4 or 6 digit file types.
   After uploading, the 'Run', 'Reload', 'Save As', and 'Stop' options will appear.
2. After running your file, the 'Run From Start' button will appear. This button will run from the beginning of the program with all user changes.
3. Explanation of Buttons
    - Run will run the program without breakpoints unless the user toggles a breakpoint at some point.
    - Step will run the program step by step. User can keep pressing the step button to continue the program.
    - Reload will reload the original file the user loaded and remove any changes the user has made.
    - If changes need to be saved, click 'Save As' to save the file in your local directory.
4. The user will see the memory contents and can add a line or delete a line if needed.
    - Break will set a dot at the line and tells the program to stop at that line when running. This allows the user to see what is happening at that moment
    - CPU sets the pointer for the CPU at that line to start running the program from.
    - Add will add an extra register before the line clicked on. Ex: Adding on register 3 will add a new register to the spot '3', making the old register 3 to be register 4
       - Note: Max length of program is 250 registers    
5. The user can also see a log that will display errors or processes during the process in the log dialogue box.

## Starting Up a Second Program or More
After uploading the first program, the user may want to upload a second program or more for comparison. Here's how to do it:

1. If you want to upload a second text file, press the 'Add Tab' button and
     a second tab will show up where you can load the second file in.
3. Only one program can run at a time, but you can have as many tabs with a program uploaded as you want.
4. To remove a tab, press the 'Remove Tab to remove the current instance of the program.

## Changing Color Scheme:
1. Open up the BasicML program
2. Click on the 'ColorScheme' button on the right hand side
3. Type in a hexadecimal code for a color of your choice
     - NOTE: The program requires you to write a '#' sign with 6 characters right after, otherwise an error comes up requiring you to input again.
3.5 Press the Preview button to see what the colors will look like for the background and for the buttons.
4. The program will change for the buttons and for the background color of the GUI.
