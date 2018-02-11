#ifndef FIBONACCIGENERATOR_H
#define FIBONACCIGENERATOR_H
#include "SequenceGenerator.h"
#include <iostream>
#include <string>
#include <sstream>
class FibonacciGenerator : public SequenceGenerator{
public:
	int startNum;
	int endNum;
	FibonacciGenerator(int startNum = 0, int endNum = 0) :
		startNum(startNum),
		endNum(endNum)
	{
		write();
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
	}
	std::string getInfo()const{
		std::ostringstream stream;
		for (int i = 0; i < length; i++){
			stream << "Fibonacci " << getName(i); 
			stream << " -> " << getValue(i) << std::endl;;
		}
		return stream.str();
	}


};
#endif // !FIBONACCIGENERATOR_H
