/*
Task 4
Named operations
avg 1
sum 0
min 2
max 3
max 0 5
sum 0 5
sum 0 1
min 0 5
avg 0 2
sum 0 5

*/
#include <iostream>
#include <string>
#include <sstream>
#include <string.h>
#include <vector>
#include <algorithm>

using namespace std;

int operationSum(vector<int>& arr, int startIndex, int endIndex) {
    int sum = 0;
    for (int i = startIndex; i < endIndex; i++) {
        sum += arr[i];
    }
    return sum;
}
int operationAverage(vector<int>& arr, int startIndex, int endIndex) {
    int counting = 0;
    int sum = 0;
    int average = 0;
    for (int i = startIndex; i < endIndex; i++) {
        sum += arr[i];
        counting++;
    }
    average = sum / counting;
    return average;
}
int operationMin(vector<int>& arr, int startIndex, int endIndex) {
    int min = arr[startIndex];
    for (int i = startIndex; i < endIndex ; i++) {
        if (arr[i] < min) {
            min = arr[i];
        }
    }
    return min;
}
int operationMax(vector<int>& arr, int startIndex, int ednIndex) {
    int max = arr[startIndex];
    for(int i = startIndex; i < ednIndex; i++) {
        if(arr[i] > max) {
            max = arr[i];
        }
    }
    return max;
}


int main() {
    vector<int> arr;
    string input;
    getline(cin, input);
    int number = 0;
    stringstream buffer(input);
    while(buffer >> number) {
        arr.push_back(number);
    }
    unsigned int numberOfOperation = 0;
    cin >> numberOfOperation;
    /* Operation name and number */
    input = "";
    vector<string> operationNameAndNumber;
    int index = 0;
    while(index < (numberOfOperation * 2)) {
        cin >> input;
        operationNameAndNumber.push_back(input);
        index++;
    }
    int startIndex, endIndex;
    index = 0;
    string userOperation;
    vector<string>::iterator found;
    stringstream stream;
    stream << "{";
    while(userOperation != "end") {
        cin >> userOperation;
        if(userOperation == "end") {
            break;
        } else {
            cin >> startIndex >> endIndex;
            index++;
            found = find(operationNameAndNumber.begin(), operationNameAndNumber.end(), userOperation);
            int indexOfOperation = distance(operationNameAndNumber.begin(), found);
            indexOfOperation++;
            if (operationNameAndNumber[indexOfOperation] == "0") {
                stream << userOperation << "(" << startIndex << "," << endIndex << ")=" << operationSum(arr, startIndex, endIndex);
            } else if (operationNameAndNumber[indexOfOperation] == "1") {
                stream << userOperation << "(" << startIndex << "," << endIndex << ")=" << operationAverage(arr, startIndex, endIndex);
            } else if (operationNameAndNumber[indexOfOperation] == "2") {
                stream << userOperation << "(" << startIndex << "," << endIndex << ")=" << operationMin(arr, startIndex, endIndex);
            } else if (operationNameAndNumber[indexOfOperation] == "3") {
                stream << userOperation << "(" << startIndex << "," << endIndex << ")=" << operationMax(arr, startIndex, endIndex);
            }
            stream << ",";
        }
    }
    string temp = stream.str();
    stream.seekp(0);
    stream << "[" << index << "]";
    stream << temp;
    temp = stream.str();
    string outputText = temp.substr(0, temp.length() - 1);
    outputText += "}";
    cout << outputText << endl;
    return 0;
}
