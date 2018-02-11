/*
06
Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet)

    pseudocode
if m < n, swap(m,n)
while n does not equal 0
   r = m mod n
   m = n
   n = r
endwhile
output m
*/
#include <iostream>

using namespace std;

int main(){
    int a,b,temp=0;

    cout << "Enter first number: ";
    cin >> a;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> a;
    }

    cout << "Enter second number: ";
    cin >> b;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> b;
    }
    if(a<b){
        temp=a;
        a=b;
        b=temp;
    }
    while(b!=0){
        temp = a%b;
        a=b;
        b=temp;
    }
    cout << "Greatest common divisor: " << a << endl;

    return 0;
}
