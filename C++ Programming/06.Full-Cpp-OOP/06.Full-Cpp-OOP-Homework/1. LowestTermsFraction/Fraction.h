#ifndef FRACTION_H
#define FRACTION_H

#include<ostream>
#include<istream>

class Fraction {
protected:
    int nominator;
    int denominator;

public:
    Fraction();

    Fraction(int nominator, int denominator);

    friend std::ostream& operator<<(std::ostream& stream, const Fraction &fraction);
    friend std::istream& operator>>(std::istream& stream, Fraction &fraction);

    friend Fraction operator+(const Fraction &a, const Fraction &b);

	

    // NOTE: this is the prefix ++, i.e. ++f
    Fraction& operator++();
    Fraction operator++(int);
};
#endif FRACTION_H