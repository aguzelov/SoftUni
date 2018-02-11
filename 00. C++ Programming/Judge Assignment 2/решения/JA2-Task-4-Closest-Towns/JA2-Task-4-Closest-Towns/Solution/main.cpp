#include<iostream>
#include<string>
#include<sstream>

#include "Vector2D.h"

using namespace std;

class NamedVector : public Vector2D {
    string name;
public:
    NamedVector() {
    }

    NamedVector(string name, double x, double y) :
        Vector2D(x, y),
        name(name) {
    }

    friend istream& operator>>(istream& stream, NamedVector& v);

    string getName() const {
        return this->name;
    }
};

istream& operator>>(istream& stream, NamedVector& v) {
    stream >> v.name >> v.x >> v.y;
    return stream;
}

class TownPairDistance {
private:
    double distSq;
public:
    NamedVector townA;
    NamedVector townB;

    TownPairDistance(NamedVector townA, NamedVector townB) :
        townA(townA),
        townB(townB),
        distSq((townA - townB).getLengthSq()) {
    }

    bool operator<(const TownPairDistance & other) const {
        return this->distSq < other.distSq;
    }

    friend ostream& operator<<(ostream& stream, const TownPairDistance& v);
};

ostream& operator<<(ostream& stream, const TownPairDistance& townPair) {
    stream << townPair.townA.getName() << "-" << townPair.townB.getName();
    return stream;
}

int main() {
    int numTowns;
    cin >> numTowns;

    NamedVector towns[numTowns];

    for (int i = 0; i < numTowns; i++) {
        cin >> towns[i];
    }

    // NOTE: there is a more efficient algorithm for this problem, but it isn't necessary here given this tasks's constraints: https://en.wikipedia.org/wiki/Closest_pair_of_points_problem#Planar_case
    TownPairDistance closest(towns[0], towns[1]);
    for (int townIndexA = 0; townIndexA < numTowns - 1; townIndexA++) {
        for (int townIndexB = townIndexA + 1; townIndexB < numTowns; townIndexB++) {
            TownPairDistance current(towns[townIndexA], towns[townIndexB]);
            if (current < closest) {
                closest = current;
            }
        }
    }

    cout << closest << endl;

    return 0;
}
