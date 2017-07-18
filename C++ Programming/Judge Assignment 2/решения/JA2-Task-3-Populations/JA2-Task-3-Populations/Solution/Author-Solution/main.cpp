#include<iostream>
#include<sstream>
#include "Populations.h"

typedef size_t ValueT;
typedef ValueT (*ValueGetter)(size_t);

size_t * cities = getPopulationsSorted();

size_t binarySearch(size_t low, size_t high, ValueT searched, ValueGetter getValueForPosition) {
    while (low != high) {
        size_t position = (low + high) / 2;

        ValueT valueForPosition = getValueForPosition(position);
        if (valueForPosition < searched) {
            // value at current position is LOWER than searched - we should go up - move the low index to ABOVE the current position
            low = position + 1;
        } else {
            // value at current position is HIGHER (or equal) than searched - we should go down - move the high index to the current position
            // note that if we have several equal elements, we want to return the first - this way we effectively slide left to reach it. That's
            // not necessary for the current task, but this binarySearch is written so it can be reused in other situations too
            high = position;
        }
    }

    return low;
}

ValueT getCityPopulation(size_t cityInd) {
    return cities[cityInd];
}

//#define SLOW

ValueT getCitiesWithPopulation(size_t fromInclusive, size_t toExclusive) {
    #ifndef SLOW
    return binarySearch(0, NumPopulations, toExclusive, getCityPopulation) - binarySearch(0, NumPopulations, fromInclusive, getCityPopulation);
    #else

    ValueT count = 0;
    size_t * populations = getPopulationsSorted();
    for (size_t i = 0; i < NumPopulations; i++) {
        if (populations[i] >= toExclusive) {
            break;
        }

        if (populations[i] >= fromInclusive) {
            count++;
        }
    }

    return count;

    #endif // SLOW
}

//#define SPEED_TEST

int main() {
    size_t * populations = getPopulationsSorted();

    size_t lowerRangeMultiplier, upperRangeMultiplier, minInRange;

    #ifndef SPEED_TEST
    std::cin >> lowerRangeMultiplier >> upperRangeMultiplier >> minInRange;
    #else
    lowerRangeMultiplier = 2;
    upperRangeMultiplier = 180;
    minInRange = 50;
    #endif // SPEED_TEST

    size_t numViablePopulations = 0;
    for (size_t i = 0; i < NumPopulations; i++) {
        size_t rangeLower = populations[i] * lowerRangeMultiplier,
            rangeUpper = (populations[i] * upperRangeMultiplier) + 1;

        size_t populationsInRange = getCitiesWithPopulation(rangeLower, rangeUpper);
        if (populationsInRange >= minInRange) {
            numViablePopulations++;
        }
    }

    std::cout << numViablePopulations << std::endl;

    return 0;
}
