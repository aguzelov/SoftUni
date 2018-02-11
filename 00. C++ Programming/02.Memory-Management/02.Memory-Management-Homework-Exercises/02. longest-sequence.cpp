/*
02
Write a program that finds the longest sequence of equal elements in an integer array and then prints that sequence on the console (integers separated by space or newline)
*/
#include <iostream>

using namespace std;

void enterElementsInArray(int arr[], int length);
void checkInput(int & input );
void calm();
void printElementsInArray(int arr[], int length);
int enterArraySize ();
int maxSequence (int arr[], int arrLength, int & starIndex);

int main(){
    int arraySize = enterArraySize();
    int array[arraySize];
    enterElementsInArray(array, arraySize);
    int startIndex = 0;
    int longest = maxSequence(array, arraySize, startIndex);
    if(longest > 1){
    cout << "Longest sequence: " << longest << " ---> ";
    for(int i = 0; i < longest ; i++) {
        if(i == (longest - 1)) {
            cout << array[startIndex + i] << endl;
        } else {
            cout << array[startIndex + i] << " ";
        }
    }
    }else {
        cout << "Program no find sequence in array!" << endl;
    }
    return 0;
}

int maxSequence (int arr[], int arrLength, int & starIndex) {
    int longest = 0;
    int length = 1;
    for(int i = 1; i < arrLength ; i++) {
        if(arr[i] == arr[i - 1]) {
            length++;
        } else {
            if(length > longest) {
                longest = length;
                starIndex = i - longest;
            }
            length = 1;
        }
    }
    return longest;
}
void enterElementsInArray(int arr[], int length) {
    cout << "Enter " << length << " elements in array" << endl;
    for (int i = 0 ; i < length ; i++) {
        cout << "Element " << i + 1 << " : ";
        cin >> arr[i];
        if(!cin) {
            checkInput(arr[i]);
        }
    }
}
void checkInput(int & input ) {
    int counter = 0;
    while(!cin) {
        cout << "Bad Input! Try again :";
        cin.clear();
        cin.ignore(256, '\n');
        cin >> input;
        counter++;
        if(counter == 5) {
            calm();
            counter = 0;
        }
    }
}
void calm() {
    cout.width(10);
    cout << "Keep" << endl;
    cout.width(10);
    cout << "Calm" << endl;
    cout.width(9);
    cout << "and" << endl;
    cout.width(10);
    cout << "ENTER" << endl;
    cout.width(10);
    cout << "POSITIVE INTEGER!" << endl;
}
int enterArraySize () {
    int a = 0;
    cout << "Enter array size: " ;
    cin >> a;
    if(!cin) {
        checkInput(a);
    }
    return a;
}
