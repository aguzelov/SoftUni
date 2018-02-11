/*
08
Write a function that reverses the digits of given positive decimal number. Example: 256 to 652
*/
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>

using namespace std;

int reverseNum(int);

int main(){
    int a;
    cout << "Enter positive decimal number: ";
    cin >> a;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> a;
    }
    cout << "Reversed: " << reverseNum(a) << endl;
    return 0;
}
int reverseNum(int a){
    int b;
    stringstream ss;
    ss << a;
    string str = ss.str();
    reverse(str.begin(), str.end());
    b = atoi(str.c_str());
    return b;
}
