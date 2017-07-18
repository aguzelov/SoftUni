/*
Task 2
Simalar Words
*/
#include <iostream>
#include <string>
#include <sstream>
#include <algorithm>

using namespace std;

int checkForSimilar(string wordInText, string word, int percentage, int & similarWord) {
    int matchLetter = 0;
    int counter = 0;
    if(wordInText[0] != word[0]) {
        //cout << "Diferent start letter" << endl;
        return 0;
    }
    if(wordInText.size() != word.size()) {
        //cout << "Diferent size" << endl;
        return 0;
    }
    for (int i = 0 ; i < word.size(); i++) {
            if(word[i] == wordInText[i]) {
                matchLetter++;

        }
    }

    double percentSimilar = (matchLetter / (double)word.size()) * 100;

    if (percentSimilar >= percentage) {
        similarWord++;
    }
}

void textConvertToWord(string inputText, string word, int percentage, int & similarWord) {
    for(int i = 0 ; i < inputText.size(); i++) {
        if(inputText[i] == ',' || inputText[i] == '.' || inputText[i] == ';' || inputText[i] == '!' || inputText[i] == '?' ) {
            inputText.replace(i, 1, " ");
        }
    }
    istringstream inputStream (inputText);
    string singleWord;
    while(getline(inputStream, singleWord, ' ')) {
//        singleWord.erase(std::remove(singleWord.begin(), singleWord.end(), ','), singleWord.end());
//        singleWord.erase(std::remove(singleWord.begin(), singleWord.end(), '.'), singleWord.end());
//        singleWord.erase(std::remove(singleWord.begin(), singleWord.end(), '!'), singleWord.end());
//        singleWord.erase(std::remove(singleWord.begin(), singleWord.end(), '?'), singleWord.end());
        singleWord.erase(std::remove(singleWord.begin(), singleWord.end(), ' '), singleWord.end());
        checkForSimilar(singleWord, word, percentage, similarWord);
    }
}

int main() {
    string text;
    getline(cin, text);
    string word;
    int percentage = 0;
    cin >> word >> percentage;
    int similarWord = 0;
    textConvertToWord(text, word, percentage, similarWord);
    cout <<similarWord << endl;
    return 0;
}
