/*
03
Write a program that enters the coefficients a, b and c of a quadratic equation a*x2 + b*x + c = 0 and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
*/
#include <iostream>
#include <cmath>

using namespace std;

int main (){
    float a, b, c, root1, root2, determinant, realPart, imagPart;
    cout << "Enter coefficients a: ";
    cin >> a;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> a;
    }
    cout << "Enter coefficients b: ";
    cin >> b;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : " ;
        cin >> b;
    }
    cout << "Enter coefficients c: ";
    cin >> c;
    while(!cin){
        cin.clear();
        cin.ignore();
        cout << "Bad input! Try again! : ";
        cin >> c;
    }
    determinant = b*b - 4*a*c;

    if (determinant > 0) {
        root1 = (-b + sqrt(determinant)) / (2*a);
        root2 = (-b - sqrt(determinant)) / (2*a);
        cout << "Roots are real and different." << endl;
        cout << "root1 = " << root1 << endl;
        cout << "root2 = " << root2 << endl;
    }

    else if (determinant == 0) {
        cout << "Roots are real and same." << endl;
        root1 = (-b + sqrt(determinant)) / (2*a);
        cout << "root1 = root2 =" << root1 << endl;
    }

    else {
        realPart = -b/(2*a);
        imagPart =sqrt(-determinant)/(2*a);
        cout << "Roots are complex and different."  << endl;
        cout << "root1 = " << realPart << "+" << imagPart << "i" << endl;
        cout << "root2 = " << realPart << "-" << imagPart << "i" << endl;
    }
    return 0;
}
