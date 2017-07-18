#include<iostream>
#include "Fraction.h"
#include "LowestTermsFraction.h"


int main() {

	LowestTermsFraction a, b;
	std::cin >> a >> b;
	std::cout << a << " " << b  << std::endl;


	LowestTermsFraction divByB = a * b;
	std::cout << "divByB : " << divByB << std::endl;
	LowestTermsFraction divBy3 = a * 5;
	std::cout << "divBy3 : " << divBy3 << std::endl;
	
	system("PAUSE");
    return 0;
}
