/*
07
Write a program which is given a line of text, another line with a find string and another line with a replace string. Any part of text which matches the find string should be replaced with the replace string. Print the resulting text on the console.
Hint: things like string.find(), string.insert(), string.replace() might be useful
Example input: I am the night. Dark Night! No, not the knight
    night - > day
Example output: I am the day. Dark Night! No, not the kday
*/
#include <iostream>
#include <string>

using namespace std;

void consoleStringInput ( string & s , string infoText){
    cout <<  infoText;
    getline(cin, s);
}

int main(){
    string text, find, replace;

    consoleStringInput(text, "Enter first text line: ");
    consoleStringInput(find, "Enter text to find: ");
    consoleStringInput(replace, "Enter text to replace: ");

    size_t pos= 0;
    while((pos = text.find(find,pos)) != string::npos){
        text.replace(pos,replace.size(), replace);
        ++pos;
    }

    cout << "Result : " << text <<endl;

    return 0;
}
