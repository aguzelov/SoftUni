/*
01
Write a program that reads two integer arrays from the console and compares them element by element. The comparing should be done in a function bool compArr(int arr1, int arr2), which returns true if they are equal and false if not
*/
#include <iostream>

using namespace std;

void enterElementsInArray(int arr[], int length);
void printElementsInArray(int arr[], int length);
void checkInput(int & );
bool compArr(int arr1[], int arr2[]);



int main() {
    int firstArrayLegth;
    cout << "Enter legth first in array :";
    cin >> firstArrayLegth;
    int arr1[firstArrayLegth] = {};
    enterElementsInArray(arr1, firstArrayLegth);

    int secondArrayLegth;
    cout << "Enter legth first in array :";
    cin >> secondArrayLegth;
    int arr2[secondArrayLegth] = {};
    enterElementsInArray(arr2, secondArrayLegth);
    if(firstArrayLegth != secondArrayLegth){
        cout << "Arrays is not equal!";
        return 1;
    }

    cout << boolalpha << compArr(arr1, arr2) << endl;
    return 0;
}

bool compArr(int arr1[], int arr2[]) {
    int counter = 0;
    bool compResult = false;
    int arrLegth = sizeof(arr1)/sizeof(arr1[0]);
    for(int i = 0; i < arrLegth ; i++) {
        if(arr1[i] == arr2[i]) {
            counter++;
        }
    }
    if(counter == arrLegth) {
        compResult = true;
    }
    return compResult;
}

void checkInput(int & input ) {
    while(!cin) {
        cin.clear();
        cin.ignore();
        cout << "Bad Input!" << endl;
        cin >> input;
    }
}

void enterElementsInArray(int arr[], int length) {
    cout << "Enter " << length << " elements in array: ";
    for (int i = 0 ; i < length ; i++) {
        cin >> arr[i];
        if(!cin) {
            checkInput(arr[i]);
        }
    }
}

void printElementsInArray(int arr[], int length) {
    for(int i = 0 ; i < length ; i++) {
        if(i == (length - 1)) {
            cout << arr[i] << endl;
        } else {
            cout << arr[i] << ", ";
        }
    }
}
