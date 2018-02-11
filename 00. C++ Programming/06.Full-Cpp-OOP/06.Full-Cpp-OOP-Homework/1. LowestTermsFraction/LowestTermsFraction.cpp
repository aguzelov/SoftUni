#include "LowestTermsFraction.h"

LowestTermsFraction::LowestTermsFraction(int nominator, int denominator) :
	Fraction(nominator / greatestCommonDivisor(nominator, denominator),
		denominator / greatestCommonDivisor(nominator, denominator)) {
}

LowestTermsFraction operator+(const LowestTermsFraction &a, const LowestTermsFraction &b) {
	int lcm = leastCommonMultiple(a.denominator, b.denominator);

	return LowestTermsFraction(a.nominator * (lcm / a.denominator) + b.nominator * (lcm / b.denominator), lcm);
} 
// a *= int
LowestTermsFraction& LowestTermsFraction::operator*=(const int &value){
	*this *= LowestTermsFraction(value, 1);
	return *this;
}
// a /= int
LowestTermsFraction& LowestTermsFraction::operator/=(const int &value){
	int lcm = greatestCommonDivisor(this->nominator, this->denominator * value);
	this->nominator /= lcm;
	this->denominator = (this->denominator * value) / lcm;
	return *this;
}
// a*=b
LowestTermsFraction& LowestTermsFraction::operator*=(const LowestTermsFraction &other){
	int lcm = greatestCommonDivisor((this->nominator * other.nominator), (this->denominator * other.denominator));
	this->nominator = (this->nominator * other.nominator)/lcm;
	this->denominator = (this->denominator * other.denominator)/lcm;

	return *this;
}
// a/=b
LowestTermsFraction& LowestTermsFraction::operator/=(const LowestTermsFraction &other){
	int lcm = greatestCommonDivisor((this->nominator * other.denominator), (this->denominator * other.nominator));
	this->nominator = (this->nominator * other.denominator) / lcm;
	this->denominator = (this->denominator * other.nominator) / lcm;

	return *this;
} 
// a*int
LowestTermsFraction operator*(const LowestTermsFraction &a, const int &value){
	LowestTermsFraction b = a;
	b *= value;
	return b;
}
// a/int
LowestTermsFraction operator/(const LowestTermsFraction &a, const int &value){
	LowestTermsFraction b = a;
	b /= value;
	return b;
}
// a*b
LowestTermsFraction operator*(const LowestTermsFraction &a, const LowestTermsFraction &b){
	LowestTermsFraction c = a;
	c *= b;
	return c;
}
// a/b
LowestTermsFraction operator/(const LowestTermsFraction &a, const LowestTermsFraction &b){
	LowestTermsFraction c = a;
	c /= b;
	return c;
}