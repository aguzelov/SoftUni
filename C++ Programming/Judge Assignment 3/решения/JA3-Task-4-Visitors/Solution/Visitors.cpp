#include <iostream>
#include <string>
#include <sstream>
#include <set>
#include <map>

using namespace std;

class Visitor {
    string id;
    string name;
    unsigned int age;
public:
    string toString() {
        ostringstream s;
        s << this->id << " " << this->name << " " << this->age;
        return s.str();
    }

    string getId() const {
        return this->id;
    }

    string getName() const {
        return this->name;
    }

    unsigned int getAge() const {
        return this->age;
    }

    friend istream& operator>>(istream& stream, Visitor& visitor);
};

typedef Visitor * VisitorPtr;

class IdComp {
public:
    bool operator()(const VisitorPtr & a, const VisitorPtr & b) const {
        return a->getId() < b->getId();
    }
};

typedef set<VisitorPtr, IdComp> VisitorSet;

istream& operator>>(istream& stream, Visitor& visitor) {
    stream >> visitor.id >> visitor.name >> visitor.age;
}

int getInAgeRange(int startAge, int endAge, const map<int, VisitorSet> & byAge) {
    int inRange = 0;

    for (map<int, VisitorSet>::const_iterator i = byAge.lower_bound(startAge); i != byAge.lower_bound(endAge); i++) {
        inRange += i->second.size();
    }

    return inRange;
}

int main() {
    VisitorSet visitors;

    map<string, VisitorSet> visitorsByName;
    map<int, VisitorSet> visitorsByAge;

    string command;
    while (cin >> command) {
        if (command == "end") {
            break;
        } else if (command == "entry") {
            VisitorPtr visitor = new Visitor();
            cin >> *visitor;

            if (visitors.find(visitor) != visitors.end()) {
                delete visitor;
            } else {
                visitors.insert(visitor);
                visitorsByAge[visitor->getAge()].insert(visitor);
                visitorsByName[visitor->getName()].insert(visitor);
            }
        } else if (command == "name") {
            string name;
            cin >> name;

            cout << visitorsByName[name].size() << endl;
        } else if (command == "age") {
            int startAge, endAge;
            cin >> startAge >> endAge;

            cout << getInAgeRange(startAge, endAge, visitorsByAge) << endl;
        }
    }

    for (VisitorSet::iterator i = visitors.begin(); i != visitors.end(); i++) {
        VisitorPtr vPtr = *i;
        delete vPtr;
    }

    return 0;
}
