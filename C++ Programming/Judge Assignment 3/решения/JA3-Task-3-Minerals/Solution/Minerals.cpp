#include<iostream>
#include<cmath>
#include<queue>

using namespace std;

int main() {
    priority_queue<int> closestDistances;

    int mineralsNeeded;
    cin >> mineralsNeeded;
    int centerX, centerY;
    cin >> centerX >> centerY;

    int numMinerals;
    cin >> numMinerals;

    size_t totalDistance = 0;
    for (int i = 0; i < numMinerals; i++) {
        int mineralX, mineralY;
        cin >> mineralX >> mineralY;

        int distance = abs(mineralX - centerX) + abs(mineralY - centerY);
        closestDistances.push(distance);

        totalDistance += distance;

        if (closestDistances.size() > mineralsNeeded) {
            totalDistance -= closestDistances.top();
            closestDistances.pop();
        }
    }

    size_t totalTime = totalDistance * 2;

    cout << totalTime << endl;

    return 0;
}
