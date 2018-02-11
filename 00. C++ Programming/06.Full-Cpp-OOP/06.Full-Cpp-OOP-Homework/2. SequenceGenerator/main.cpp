#include <iostream>
#include "FibonacciGenerator.h"
#include "SqrtGenerator.h"
#include "SequenceGenerator.h"

#define BIG_NUMBER  10000

int main(){
	/*
	for (int ind1 = 0; ind1 < BIG_NUMBER; ind1++){
		for (int ind2 = 0; ind2 < BIG_NUMBER; ind2++){
			Fib fib(3, 6);
			Fib copyConstructed(fib);
			Fib copyAssigned(1, 5);
			copyAssigned = fib;
		}
	}
	*/
	Fib fib(3, 6);
	SqrtGenerator sqr(4, 10);
	SequenceGenerator *pSeq = &fib;
	pSeq->write();
	pSeq = &sqr;

	pSeq->write();
	
	system("PAUSE");
	return 0;
}