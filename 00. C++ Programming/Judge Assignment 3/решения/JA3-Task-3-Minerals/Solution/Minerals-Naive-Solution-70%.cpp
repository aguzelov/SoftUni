#include<iostream>
#include<cmath>
#include<queue>

using namespace std;

class Mineral {
public:
    int x;
    int y;

    Mineral() : x(0), y(0) {}
    Mineral(int x, int y) : x(x), y(y) {}

    int distance(int x, int y) const {
        return abs(this->x - x) + abs(this->y - y);
    }
};

int manhattanDistance(int ax, int ay, int bx, int by) {
    return abs(ax - bx) + abs(ay - by);
}

int getClosestIndex(int x, int y, Mineral minerals[], bool collected[], int numMinerals) {
    int minDist = 2 * 1000 + 1; // initialize with larger than max distance
    int closestInd = -1;
    for (int i = 0; i < numMinerals; i++) {
        if (!collected[i]) {
            int currentDist = minerals[i].distance(x, y);
            if (currentDist < minDist) {
                minDist = currentDist;
                closestInd = i;
            }
        }
    }

    return closestInd;
}

int main() {
    int mineralsNeeded;
    cin >> mineralsNeeded;
    int centerX, centerY;
    cin >> centerX >> centerY;

    int numMinerals;
    cin >> numMinerals;

    bool * collected = new bool[numMinerals];
    Mineral * minerals = new Mineral[numMinerals];

    for (int i = 0; i < numMinerals; i++) {
        int mineralX, mineralY;
        cin >> mineralX >> mineralY;
        collected[i] = false;
        minerals[i] = Mineral(mineralX, mineralY);
    }

    size_t totalDistance = 0;
    for (int i = 0; i < mineralsNeeded; i++) {
        int closestInd = getClosestIndex(centerX, centerY, minerals, collected, numMinerals);

        if (closestInd != -1) {
            totalDistance += minerals[closestInd].distance(centerX, centerY);
            collected[closestInd] = true;
        } else {
            cout << "debug: closest was not found for mineral " << i << endl;
        }
    }

    size_t totalTime = totalDistance * 2;

    cout << totalTime << endl;

    return 0;
}
