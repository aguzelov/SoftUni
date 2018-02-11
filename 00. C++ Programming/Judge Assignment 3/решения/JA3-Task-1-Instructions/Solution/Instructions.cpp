#include<iostream>
#include<stack>
#include<string>
#include<sstream>
#include<vector>
using namespace std;

int parseInt(const string & str) {
    int parsed;
    istringstream(str) >> parsed;
    return parsed;
}

string toString(int number) {
    ostringstream s;
    s << number;
    return s.str();
}

int extractTop(stack<int> & s) {
    int top = s.top();
    s.pop();
    return top;
}

int main() {
    stack<int> valuesStack;

    string input;
    while(cin >> input) {
        if (input == "sum") {
            valuesStack.push(extractTop(valuesStack) + extractTop(valuesStack));
        } else if (input == "subtract") {
            valuesStack.push(extractTop(valuesStack) - extractTop(valuesStack));
        } else if (input == "concat") {
            string second = toString(extractTop(valuesStack));
            string first = toString(extractTop(valuesStack));
            valuesStack.push(parseInt(first + second));
        } else if (input == "discard") {
            valuesStack.pop();
        } else if (input == "end") {
            break;
        } else {
            valuesStack.push(parseInt(input));
        }
    }

    vector<int> valuesReversed;
    while(!valuesStack.empty()) {
        valuesReversed.push_back(extractTop(valuesStack));
    }

    for (int i = valuesReversed.size() - 1; i >=0; i--) {
        cout << valuesReversed[i] << endl;
    }

    return 0;
}
