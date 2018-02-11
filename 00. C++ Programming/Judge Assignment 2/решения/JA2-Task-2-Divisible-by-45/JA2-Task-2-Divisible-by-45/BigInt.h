#ifndef BIG_INT_H
#define BIG_INT_H

#include<string>
#include<sstream>
#include<cmath>

class BigInt {
protected:
    std::string digits;
public:
    BigInt() :
        digits("0") {
    }

    BigInt(std::string digits) :
        digits(trimLeadingZeroes(digits)) {
    }

    BigInt(int number) :
        digits(intToString(number)) {
    }

    std::string getDigits() const {
        return this->digits;
    }

    BigInt& operator+=(const BigInt & other) {
        *this = *this + other;
        return *this;
    }

    BigInt operator+(const BigInt & other) const {
        int maxTotalDigits = 1 + std::max(this->digits.size(), other.digits.size());

        std::string thisDigits = getPaddedWithZeroes(this->digits, maxTotalDigits);
        std::string otherDigits = getPaddedWithZeroes(other.digits, maxTotalDigits);

        std::string resultDigits(maxTotalDigits, '0');

        int carry = 0;
        for (int i = resultDigits.size() - 1; i >= 0; i--) {
            int thisDigit = thisDigits[i] - '0';
            int otherDigit = otherDigits[i] - '0';

            int sum = thisDigit + otherDigit + carry;
            carry = sum / 10;
            int sumDigit = sum - carry * 10;

            resultDigits[i] = sumDigit + '0';
        }

        return BigInt(resultDigits);
    }

    friend std::ostream& operator<<(std::ostream& stream, const BigInt &number);

    bool operator<(const BigInt& other) const {
        std::string thisStr = this->digits;
        std::string otherStr = other.digits;

        if (thisStr.size() < otherStr.size()) {
            thisStr = getPaddedWithZeroes(thisStr, otherStr.size());
        } else if (thisStr.size() > otherStr.size()) {
            otherStr = getPaddedWithZeroes(otherStr, thisStr.size());
        }

        return thisStr < otherStr;
    }

private:
    static std::string trimLeadingZeroes(std::string number) {
        std::string resultDigitsTrimmed;
        for (size_t i = 0; i < number.size(); i++) {
            if (number[i] != '0') {
                resultDigitsTrimmed = number.substr(i);
                break;
            }
        }

        return resultDigitsTrimmed.empty() ? "0" : resultDigitsTrimmed;
    }


    static std::string intToString(int number) {
        std::ostringstream str;
        str << number;
        return str.str();
    }

    static std::string getPaddedWithZeroes(std::string s, size_t widthNeeded) {
        if(s.size() < widthNeeded) {
            return std::string(widthNeeded - s.size(), '0') + s;
        } else {
            return s;
        }
    }
};

inline std::ostream& operator<<(std::ostream& stream, const BigInt &number) {
    stream << number.digits;
    return stream;
}

#endif // BIG_INT_H
