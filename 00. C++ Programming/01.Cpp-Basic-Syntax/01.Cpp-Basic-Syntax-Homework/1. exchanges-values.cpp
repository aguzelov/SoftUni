/*
01
Write a conditional statement that examines two integer variables and exchanges their values if the first one is greater than the second one.*/

#include <iostream>

using namespace std;

int main(){
    int a,b;

    cout << "Enter first integer value! ";
    cin >> a;
    cout << endl;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input!   Try again!" << endl;
        cin >> a;
    }

    cout << "Enter second integer value! ";
    cin >> b;
    cout << endl;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again!" << endl;
        cin >> b;
    }

    cout << "a= " << a << "   |   " << "b= " << b << endl;

    if(a>b){
        int c = a;
        a = b;
        b = c;
    }

    cout << "a= " << a << "   |   " << "b= " << b << endl;


    return 0;
}
