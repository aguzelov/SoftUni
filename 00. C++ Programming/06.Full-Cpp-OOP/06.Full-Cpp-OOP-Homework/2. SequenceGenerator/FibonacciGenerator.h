#ifndef FIBONACCIGENERATOR_H
#define FIBONACCIGENERATOR_H
#include "SequenceGenerator.h"
#include <iostream>
class Fib : public SequenceGenerator{
public:
	int startNum;
	int endNum;
	Fib(int startNum = 0, int endNum = 0) :
		startNum(startNum),
		endNum(endNum)
	{

	}

	void write(){
		double total;
		double alpha(0), beta(1);
		int counter = 0;
		for (int index = 0; index < this->endNum; index++){
			if (index == 0){
				total = 0;
			}
			else if (index == 1){
				total = 1;
			}
			else{
				total = alpha + beta;
				alpha = beta;
				beta = total;
			}

			if (index >= this->startNum && index < this->endNum){
				setElement(counter, total);
				counter++;
				names.push_back(index);
			}

		}
		std::cout << "Fibonacci N -> number" << std::endl;
		for (int i = 0; i < length; i++){

			std::cout << "Fibonacci " << getName(i);

			std::cout << " -> " << getValue(i) << std::endl;
		}
	}


};
#endif // !FIBONACCIGENERATOR_H
