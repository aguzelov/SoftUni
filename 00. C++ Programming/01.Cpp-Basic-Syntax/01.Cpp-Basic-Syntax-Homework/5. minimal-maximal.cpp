/*
05
Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them
*/
#include <iostream>

using namespace std;

int main() {
    int n, currentNum,min, max = 0;
    cout << "Enter the length of sequence: ";
    cin >> n;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> n;
    }

    for(int i = 0; i < n; i++){
        cout << "Enter " << i+1 << " integer number: ";
        cin >> currentNum;
        while(!cin){
            cin.clear();
            cin.ignore();
            cout << "Bad input! Try again! : ";
            cin >> currentNum;
        }
        max = (currentNum > max)? currentNum : max;
        min =(currentNum < min) ? currentNum : min;
    }

    cout << "Maximal number: " << max << endl;
    cout << "Minimal number: " << min << endl;

    return 0;
}
