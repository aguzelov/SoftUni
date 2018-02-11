/*
10
Write a program which checks if the lines of two text files are the same (same number of lines and each line from the first file should be equal to the line of the second file).
*/
#include <iostream>
#include <fstream>
#include <string.h>

#include <string>
#include <stdio.h>

using namespace std;

int main(){
    string file1 = "10in.txt";
    string file2 = "10in2.txt";
    ifstream firstInputFile, secondInputFile;

    firstInputFile.open(file1.c_str(), ios::binary);
    secondInputFile.open(file2.c_str(), ios::binary);


    if(!firstInputFile){
        cout << "Couldn`t open the file " << file1 << endl;
        return 1;
    }
    if(!secondInputFile){
        cout << "Couldn`t open the file " << file2 << endl;
        return 1;
    }

//---------- compare number of lines in both files ------------------//
    int counter1 = 0;
    int counter2 = 0;
    string str;
    while(!firstInputFile.eof()){
        getline(firstInputFile,str);
        counter1++;
    }

    while(!secondInputFile.eof()){
        getline(secondInputFile, str);
        counter2++;
    }

    firstInputFile.clear();
    firstInputFile.seekg(0, ios::beg);

    secondInputFile.clear();
    secondInputFile.seekg(0, ios::beg);

    if(counter1 != counter2){
        cout << "Different number of lines in files!" << endl;
        cout << "First file has " << counter1 << " lines." << endl;
        cout << "Second file has " << counter2 << " lines." << endl;
        return 1;
    } else {
        cout << "Equal number of line in files!" << endl;
    }
//---------- compare two files line by line ------------------//
    char string1[256] , string2[256];
    int j =0;
    int error_count = 0;
    while(!firstInputFile.eof()){
        firstInputFile.getline(string1,256);
        secondInputFile.getline(string2,256);
        j++;
        if(strcmp(string1, string2) != 0){
            cout << j << "-the line are not equal " << endl;
            cout << "Line "<< j <<" in "<< file1 << " is :" << string1 << endl;
            cout << "Line "<< j <<" in "<< file2 << " is :" << string2 << endl;
            error_count++;
            }
    }
    if(error_count > 0){
        cout << "Files are diffrent" << endl;
    } else {
        cout << "Files are the same" << endl;
    }


    return 0;
}

