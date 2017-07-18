#include "Fraction.h"

Fraction::Fraction() :
    nominator(0),
    denominator(0) {
}

Fraction::Fraction(int nominator, int denominator) :
    nominator(nominator),
    denominator(denominator) {
}

// NOTE: this is the prefix ++, i.e. ++f
Fraction& Fraction::operator++() {
    (*this) = (*this) + Fraction(1, 1);
    return *this;
}

Fraction Fraction::operator++(int) {
    Fraction valueBeforeIncrement = *this;
    ++(*this);
    return valueBeforeIncrement;
}

Fraction operator+(const Fraction &a, const Fraction &b) {
    if (a.denominator == b.denominator) {
        return Fraction(a.nominator + b.nominator, a.denominator);
    } else {
        int commonDenominator = a.denominator * b.denominator;
        return Fraction(a.nominator * b.denominator + b.nominator * a.denominator, commonDenominator);
    }
}

std::ostream& operator<<(std::ostream& stream, const Fraction &fraction) {
    if (fraction.nominator == 0 && fraction.denominator == 0) {
        stream << "NaN";
    } else {
        stream << fraction.nominator << "/" << fraction.denominator;
    }

    return stream;
}

std::istream& operator>>(std::istream& stream, Fraction &fraction) {
    stream >> fraction.nominator;
    char slash;
    stream >> slash;
    stream >> fraction.denominator;

    return stream;
}

