#ifndef SQRTGENERATOR_H
#define SQRTGENERATOR_H
#include "SequenceGenerator.h"
#include <iostream>
#include <string>
#include <sstream>
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
		write();
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

	}
	std::string getInfo()const{
		std::ostringstream stream;
		for (int i = 0; i < length; i++){
			stream << "Sqrt(" << getName(i) << ")";
			stream << " -> " << getValue(i) << std::endl;
		}
		return stream.str();
	}
};

#endif // !SQRTGENERATOR_H
