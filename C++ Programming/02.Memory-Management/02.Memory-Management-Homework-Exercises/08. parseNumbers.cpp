/*
08
Write a function int * parseNumbers(const string& str, int& resultLength) which returns a pointer to new-allocated array with the numbers parsed from str (assume you don’t need to handle wrongly-formatted input). str will contain integer numbers separated by spaces. The function writes the length of the allocated array in resultLength. Write a program which lets the user enter a number of lines of integers from the console, and prints their sum. Use the parseNumbers function in your program, but make sure you delete each array once you’re done with it.
Example input (note: first line is the count of lines of numbers, in this case: 2 lines):
2
1 2 3
4 5
Expected output (sum of 1 2 3 and 4 5): 15
*/
#include <iostream>
#include <string>
#include <sstream>
#include <ctype.h>

using namespace std;

int * parseNumber(const string& str, int& resultLength) {
    int numCounter = 0;
    for(int i = 0 ; i < str.length(); i++) {
        if(isdigit(str[i]) && str[i - 1] == ' ') {
            numCounter++;
        }
        if(numCounter == 0 && isdigit(str[i])) {
            numCounter++;
        }
    }
    resultLength = numCounter;
    int * newallocArray = new int[resultLength];
    istringstream numReader(str);
    int number;
    int index = 0;
    while(numReader >> number) {
        newallocArray[index] = number;
        index++;
    }
    return newallocArray;
}


int main() {
    int numberOfLine = 0;
    cout << "Enter numbers of lines: ";
    cin >> numberOfLine;
    cin.clear();
    cin.ignore(256, '\n');
    ostringstream outPut;
    outPut << "(sum of";
    int sum = 0;
    for(int i = 0; i < numberOfLine; i++) {
        int parsedLength = 0;
        if(numberOfLine > 1 && i > 0) {
            outPut << " and";
        }
        string input;
        cout << "Enter " << i + 1 << " line of numbers: ";
        getline(cin, input);
        int * parsed = parseNumber(input, parsedLength);
        for(int j = 0; j < parsedLength; j++) {
            sum += parsed[j];
            outPut << " ";
            outPut << parsed[j];
        }
        delete[] parsed;
    }
    outPut << ") : ";
    cout << outPut.str() << sum << endl;
    return 0;
}
