/*
09
Write a bool function that tests the function from task 8 with different values. It should call the function from 8 for a value and check the result against the expected answer. Make the function check at least 10 numbers of different length and return true if all were correct or false if any of them was wrong. Call that this checking function from main() and print it’s result
*/
#include <iostream>
#include <sstream>
#include <string>
#include <algorithm>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <iomanip>
using namespace std;

int reverseNum(int);
bool test();
int main(){
    int a;
    cout << "Enter positive decimal number: ";
    cin >> a;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again!" << endl;
        cin >> a;
    }
    cout << "Reversed: ";
    cout << setw(10);
    cout << reverseNum(a) << endl;
    bool t = test();
    cout <<"| Total :";
    cout << setw(10);
    cout << boolalpha << t << endl;
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

bool test(){
    bool t;
    int temp1, temp2, count=0;
    for(int i = 0 ; i < 10; i++){
        srand (time(NULL));
        int random = rand() % 1000 + i*51;
        temp1 = reverseNum(random);
        temp2 = reverseNum(temp1);
        if(random == temp2){
            t = true;
            count++;
        }else {
            t = false;
            count--;
        }
        cout << "| Test "<< i+1 << " with number "<< random << " : ";
        cout << boolalpha <<  t << endl;
    }
    if(count == 10){
        t = true;
    }else {
        t = false;
    }
    return t;
}
