#ifndef SQRTGENERATOR_H
#define SQRTGENERATOR_H
#include "SequenceGenerator.h"
#include <iostream>
#include <math.h>
class SqrtGenerator : public SequenceGenerator{
private:
	int startInteger;
	int endInteger;
public:
	SqrtGenerator(int startInteger = 0, int endInteger = 0) :
		startInteger(startInteger),
		endInteger(endInteger)
	{

	}
	void write(){
		double s;
		int counter = 0;
		for (int index = startInteger; index < endInteger; index++){

			s = sqrt(index);
			setElement(counter, s);

			names.push_back(index);
			counter++;
		}

		for (int i = 0; i < length; i++){

			std::cout << "Sqrt(" << getName(i) << ")";
			std::cout << " -> " << getValue(i) << std::endl;
		}
	}
};

#endif // !SQRTGENERATOR_H
