/*
04
Write a program that prints all the numbers from 1 to N
*/
#include <iostream>
using namespace std;

int main(){
    int n;
    cout << "Enter N: ";
    cin >> n;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> n;
    }

    for (int i = 1; i <= n ; i++){
        cout << i <<", ";
    }
    cout << endl;
    return 0;
}
