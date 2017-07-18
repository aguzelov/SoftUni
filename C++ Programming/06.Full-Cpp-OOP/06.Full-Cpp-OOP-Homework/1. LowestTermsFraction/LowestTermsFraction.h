#ifndef LOWESTERMSFRACTION_H
#define LOWESTERMSFRACTION_H
#include "Fraction.h"

static int greatestCommonDivisor(const int &a, const int &b) {
	int divisorCand = a < b ? a : b;

	// NOTE: there is a better algorithm for gcd, but we're trying to keep things simple
	while ((a % divisorCand != 0) || (b % divisorCand != 0)) {
		divisorCand--;
	}

	return divisorCand;
}

static int leastCommonMultiple(const int &a, const int &b) {
	return (a * b) / greatestCommonDivisor(a, b);
}

class LowestTermsFraction : public Fraction {
public:
	LowestTermsFraction(){}
	LowestTermsFraction(int, int);


	friend LowestTermsFraction operator+(const LowestTermsFraction &a, const LowestTermsFraction &b);
	// a *= int
	LowestTermsFraction& operator*=(const int&);
	// a /= int
	LowestTermsFraction& operator/=(const int&);
	// a*=b
	LowestTermsFraction& operator*=(const LowestTermsFraction&);
	// a/=b
	LowestTermsFraction& operator/=(const LowestTermsFraction&);
	// a*int
	friend LowestTermsFraction operator*(const LowestTermsFraction&, const int&);
	// a/int
	friend LowestTermsFraction operator/(const LowestTermsFraction&, const int&);
	//a*b
	friend LowestTermsFraction operator*(const LowestTermsFraction&, const LowestTermsFraction&);
	//a/b
	friend LowestTermsFraction operator/(const LowestTermsFraction&, const LowestTermsFraction&);
};

#endif // !LOWESTERMSFRACTION_H
