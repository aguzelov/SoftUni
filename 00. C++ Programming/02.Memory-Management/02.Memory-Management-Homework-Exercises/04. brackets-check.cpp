/*
04
Write a program that reads a line from the console containing a mathematical expression. Write a bool function that checks whether the brackets in the expression () are placed correctly (assume everything else is correct, i.e. you don’t need to check for correct signs, correct variables/numbers, etc.) and returns true if they are correct and false if they are not correct
Examples of correctly placed brackets: ((a+b)/5-d); a+b; a+(b); ((a))
Examples of incorrectly placed brackets: ((a+b)/5-d; (a+b; a+b); (a))
*/
#include <iostream>
#include <string>
#include <sstream>

bool bracketsCheck(std::string s) {
    std::istringstream inputStream(s);
    char singleElement;
    int opening = 0;
    int closing = 0;
    int counter = 0;
    while(inputStream >> singleElement ) {
        if(singleElement == '(') {
            counter++;
            opening++;
        } else if(singleElement == ')') {
            counter--;
            closing++;
        }
        if(closing > opening) {
            return false;
        }
    }
    return !counter;
}

int main() {
    std::string mathExpression;
    std::cout << "Enter math expression : ";
    std::getline(std::cin, mathExpression);
    if(bracketsCheck(mathExpression)) {
        std::cout << "The brackets in the expression are placed correctly" << std::endl;
    } else {
        std::cout << "The brackets in the expression are placed incorrectly" << std::endl;
    }
    return 0;
}
