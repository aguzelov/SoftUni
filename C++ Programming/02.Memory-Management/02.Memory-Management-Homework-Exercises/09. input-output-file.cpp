/*
09
Write a program which does the same as task 8, but instead of printing to the console, asks the user for the name of an input file and an output file (each entered on a separate line) and reads the input from the input file and prints the output in the output file. If the output file already exists, it should be overwritten. Note: the input and output file could be the same. Note2: just copy-paste the code from 8 to reuse it
*/
#include <iostream>
#include <string>
#include <sstream>
#include <fstream>
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
//input file
    ifstream inputFile;
    string inputFileName;
    cout << "Enter a input file name: ";
    cin >> inputFileName;
    inputFile.open(inputFileName);
//output file
    string outputFileName;
    cout << "Enter a output file name: ";
    cin >> outputFileName;
    ofstream outFile(outputFileName);

    ostringstream outPut;
    outPut << "(sum of";

    int sum = 0;
    int parsedLength = 0;

//counting file lines
    string str1;
    int lines = 0;
    ifstream inputFile2(inputFileName);
    while(!inputFile2.eof()) {
        getline(inputFile2, str1);
        lines++;
    }
//parsing to new allocated array
    for(int i = 0; i < lines; i++) {
            // format output
        if(lines > 1 && i > 0) {
            outPut << " and";
        }
        string input;
        getline(inputFile, input);
        int * parsed = parseNumber(input, parsedLength);
        for(int j = 0; j < parsedLength; j++) {
            sum += parsed[j];
            outPut << " ";
            outPut << parsed[j];
        }
        delete[] parsed;
    }
    outPut << ") : ";
    outFile << outPut.str() << sum << endl;
    return 0;
}
