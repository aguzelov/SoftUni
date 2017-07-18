#include<iostream>
#include<iomanip>

using namespace std;

int hexSymbolToDecimal(char hex) {
    if (hex >= 'a') {
        return 10 + (hex - 'a');
    } else {
        return hex - '0';
    }
}

int main() {
    const unsigned int NumHexDigitsPerNumber = 5;

    char input[NumHexDigitsPerNumber] = {};

    size_t xorred = 0;

    while (cin >> input[0]) {
        if (input[0] == '.') {
            break;
        }

        cin >> input[1] >> input[2] >> input[3] >> input[4];

        int value = 0;
        for (int i = 0; i < NumHexDigitsPerNumber; i++) {
            value = value << 4; // this is equivalent to value *= 16;, but works faster than multiplication
            value += hexSymbolToDecimal(input[i]);
        }

        xorred ^= value;
    }

    cout << hex << setfill('0') << setw(5) << xorred << endl;
}
