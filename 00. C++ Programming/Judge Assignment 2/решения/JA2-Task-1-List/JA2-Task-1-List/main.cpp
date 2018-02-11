#include <iostream>
#include <string>
#include <sstream>

#include "List.h"

List mergeSortedLists(List a, List b) {
    List merged;

    while(!a.isEmpty() || !b.isEmpty()) {
        List * listToTakeFrom;
        if (a.isEmpty()) {
            listToTakeFrom = &b;
        } else if (b.isEmpty()) {
            listToTakeFrom = &a;
        } else {
            if (a.first() < b.first()) {
                listToTakeFrom = &a;
            } else {
                listToTakeFrom = &b;
            }
        }

        merged.add(listToTakeFrom->first());
        listToTakeFrom->removeFirst();
    }

    return merged;
}

int main() {
    using namespace std;

    List sorted;

    string listLine;
    getline(cin, listLine);

    while(listLine != "end") {
        istringstream lineStream(listLine);

        List currentList;
        int value;
        while (lineStream >> value) {
            currentList << value;
        }

        sorted = mergeSortedLists(sorted, currentList);

        getline(cin, listLine);
    }

    cout << sorted.toString() << endl;

    return 0;
}
