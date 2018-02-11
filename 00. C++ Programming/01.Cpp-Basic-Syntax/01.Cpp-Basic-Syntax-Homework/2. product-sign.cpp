/*
02
Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.
*/

#include <iostream>

using namespace std;

int main(){
    float a, b ,c;

    cout << "Enter the first real number! ";
    cin >> a;
    cout << endl;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> a;
    }

    cout << "Enter the second real number! ";
    cin >> b;
    cout << endl;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> b;
    }

    cout << "Enter the third real number! ";
    cin >> c;
    cout << endl;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> c;
    }
        //     true = +            false = -
    bool d = ((a < 0 && b < 0) ||(a> 0 && b > 0)) ? true : false;
    bool f = (d && c > 0)? true : false;
    if (f){
        cout << "The sign is  +" << endl;
    } else {
        cout << "The sign is  -" << endl;
    }

    return 0;
}
