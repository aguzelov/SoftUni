/*
06
Write a function int occurences(const string& text, const string& search) which returns the number of times search is contained in text.
Example call: string text = “Write a function int occurences(const string& text, const string& search) which returns the number of times search is contained in text”string search = “on”;occurences(text, search);
Expected result: 5
Make a program which reads two lines of text from the console – first the text, then the search string and prints the number of times search is contained in text
*/
#include <iostream>
#include <string>


using namespace std;

int occurences(const string & text, const string & search);

int main() {
    string text;
    cout << "Enter text: ";
    getline(cin, text);

    cout << "Enter search: ";
    string occurence;
    getline(cin, occurence);

    int t = occurences(text, occurence);

    cout << "The number of times '" << occurence << "' is contained in text is :" << t << endl;

    return 0;
}

int occurences(const string& text, const string& search) {
    int counter = 0;
    size_t pos = 0;
    while((pos = text.find(search, pos)) != string::npos ) {
        ++counter;
        ++pos;
    }
    return counter;
}
