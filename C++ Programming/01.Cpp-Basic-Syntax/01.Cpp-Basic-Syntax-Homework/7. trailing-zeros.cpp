/*
07
Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples N = 10, N! = 3628800, answer 2; N! = 2432902008176640000, answer: 4. Make sure your program works for N up to 50 000
*/
#include <iostream>
#include <climits>

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
    unsigned long long int factorial = 1;
    for (int i = 1; i <= n ; i++){
        factorial *= i;
    }
    cout << "factorial: " << factorial << endl;
    int count=0;
    while(factorial % 10 ==0){
        factorial = factorial / 10;
        count++;
    }
    cout << "Trailing zeros: " << count << endl;
    return 0;
}

