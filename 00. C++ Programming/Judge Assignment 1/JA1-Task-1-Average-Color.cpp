/*
Task 1
Average Color
*/
#include <iostream>
#include <sstream>
#include <string>
#include <locale>

using namespace std;


void getColor(string & color1, string & color2) {
    string notFormatedInput;
    getline(cin, notFormatedInput);
    unsigned int counter = 0;
    for(unsigned int i = 0 ; i < notFormatedInput.size(); i++) {
        if(!isalnum(notFormatedInput[i])) {
            continue;
        } else if(counter < 6) {
            color1 = color1 + notFormatedInput[i];
        } else {
            color2 = color2 + notFormatedInput[i];
        }
        counter++;
    }
}
int getColorValue(string colorString, string currentColor) {
    int color;
    string str;
    if(currentColor == "red") {
        str = colorString.substr(0, 2);
        stringstream stream;
        stream << std::hex << str;
        stream >> color;
    } else if(currentColor == "green") {
        str = colorString.substr(2, 2);
        stringstream stream;
        stream << std::hex << str;
        stream >> color;
    } else if(currentColor == "blue") {
        str = colorString.substr(4, 2);
        stringstream stream;
        stream << std::hex << str;
        stream >> color;
    } else {
        cout << "Error in getColorValue()" << endl;
    }
    return color;
}

const int colorvalue = 3;

int main() {
    string firstColor;
    string secondColor;
    getColor(firstColor, secondColor);
    unsigned int red1, green1, blue1, red2, green2, blue2;
    red1 = getColorValue(firstColor, "red");
    green1 = getColorValue(firstColor, "green");
    blue1 = getColorValue(firstColor, "blue");

    red2 = getColorValue(secondColor, "red");
    green2 = getColorValue(secondColor, "green");
    blue2 = getColorValue(secondColor, "blue");

    int averageRed = (red1 + red2) / 2;
    int averageGreen = (green1 + green2) / 2;
    int averageBlue = (blue1 + blue2) / 2;

    string result;
    stringstream stream ;
    stream << "#";
    if(averageRed == 0) {
        stream << "00";
    } else {
        stream << std::hex << averageRed;
    }
    if(averageGreen == 0) {
        stream << "00";
    } else {
        stream << std::hex << averageGreen;
    }
    if(averageBlue == 0) {
        stream << "00";
    } else {
        stream << std::hex << averageBlue;
    }
    result = stream.str();
    cout << result << endl;

    return 0;
}
