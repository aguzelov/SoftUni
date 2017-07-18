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

istream& operator>>(istream& stream, Visitor& visitor) {
    stream >> visitor.id >> visitor.name >> visitor.age;
}

class IdComp {
public:
    bool operator()(const Visitor & a, const Visitor & b) const {
        return a.getId() < b.getId();
    }
};

int main() {
    typedef set<Visitor, IdComp> VisitorSet;
    VisitorSet visitors;

    string command;
    while (cin >> command) {
        if (command == "end") {
            break;
        } else if (command == "entry") {
            Visitor visitor;
            cin >> visitor;
            visitors.insert(visitor);
        } else if (command == "name") {
            string name;
            cin >> name;

            int result = 0;
            for (const Visitor& visitor : visitors) {
                if (visitor.getName() == name) {
                    result++;
                }
            }

            cout << result << endl;
        } else if (command == "age") {
            int startAge, endAge;
            cin >> startAge >> endAge;

            int result = 0;
            for (const Visitor& visitor : visitors) {
                if (visitor.getAge() >= startAge && visitor.getAge() < endAge) {
                    result++;
                }
            }

            cout << result << endl;
        }
    }

    return 0;
}
