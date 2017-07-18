/*
10
For this task, you are NOT allowed to use any type of loop. Write a function that calculates the Nth Fibonacci number.
*/
#include <iostream>

using namespace std;

int fib(int);

int main(){
    int n;
    cout << "Enter the N: ";
    cin >> n;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> n;
    }
    cout << "The "<< n << "th Fibonacci number: " << fib(n)<< endl;
    return 0;
}
int fib(int x){
    if(x == 0){
        return 0;
    } else if(x == 1){
        return 1;
    } else {
        return fib(x-1)+fib(x-2);
    }
}
