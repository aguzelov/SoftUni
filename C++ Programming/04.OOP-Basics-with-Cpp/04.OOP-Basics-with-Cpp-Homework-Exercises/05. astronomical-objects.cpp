/* 05. astronomical-objects.cpp :
visual studio
*/

#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

using namespace std;
enum Type {
    unknown,
    star,
    rockyPlanet,
    gasGiant
};

class Astronomical {
private:
    string solarSystem;
    int posInSystem;
    double mass;
    int radius;
    Type type;
    string nickname;
public:
    Astronomical() {}
    Astronomical(string solarSystem, int posInSystem, double mass, int radius, Type type, string nickname = "") : solarSystem(solarSystem), posInSystem(posInSystem),
        mass(mass), radius(radius), type(type), nickname(nickname) {	}
    void changeSolarSystem(string solarSystem) {
        this->solarSystem = solarSystem;
    }
    void changePosition(int pos) {
        this->posInSystem = pos;
    }
    void changeType(Type type) {
        if (this->type < type) {
            this->type = type;
            if (type == star) {
                this->posInSystem = 1;
            }
        }
    }
    void setSolarSystem(string ss) {
        this->solarSystem = ss;
    }
    void setPosInSystem(int pos) {
        this->posInSystem = pos;
    }
    void setMass(double mass) {
        this->mass = mass;
    }
    void setRadius(int rad) {
        this->radius = rad;
    }
    void setType(Type type) {
        this->type = type;
        if (type == star) {
            this->posInSystem = 1;
        }
    }
    void setNickname(string nick) {
        this->nickname = nick;
    }
    string print() {
        ostringstream stream;
        stream << "======================================" << endl;
        stream << "Solar system:" << this->solarSystem << endl;
        stream << "Position in solar system:" << this->posInSystem << endl;
        stream << "Mass in kg:" << this->mass << endl;
        stream << "Radius in meters:" << this->radius << endl;
        stream << "Type:" << this->type << endl;
        stream << "Nickname:" << this->nickname << endl;
        stream << "======================================" << endl;
        return stream.str();
    }
    string designation() {
        ostringstream stream;
        stream << " " << this->solarSystem << "-" << this->posInSystem;
        if (this->nickname != "") {
            stream << " (" << this->nickname << ")";
        }
        stream << " { mass: " << this->mass << ", radius: " << this->radius << " } " << endl;
        return stream.str();
    }
};

istream& operator>>(istream& is, Astronomical& obj) {
    is >> obj.designation();
    return is;
}
ostream& operator<<(ostream& os, Astronomical& obj) {
    os << obj.designation();
    return os;
}
void printMenu() {
    cout << endl;
    cout << "|==========================================================" << endl;
    cout << "| 1. Creat astronomical object." << endl;
    cout << "|    Create info:" << endl;
    cout << "| 2. Create info about astronomical objects of stat system." << endl;
    cout << "| 3. Create info of a specific object of a system" << endl;
    cout << "| 0. Exit" << endl;
    cout << "|==========================================================" << endl;
}
string previouslyObjects(string filename) {
    ifstream in(filename.c_str());
    stringstream buffer;
    buffer << in.rdbuf();
    in.close();
    return buffer.str();
}
bool compare(string userIn, string fileIn) {
    int a = userIn.size();
    int b = fileIn.size();
    if ((a + 2) != b) {
        return false;
    }
    int counter = 0;
    for (int i = 0; i < a; i++) {
        if (userIn[i] == fileIn[i]) {
            counter++;
        }
    }
    if (counter == a) {
        return true;
    }
    return (counter == a);
}


int main() {
    string solarSystem;
    int posInSystem;
    double mass;
    int radius;
    int t;
    Type type;
    string nickname;
    int input = 1;
    string filename = "info.txt";
    fstream fileStream;
    fileStream.open(filename, fstream::in | fstream::out | fstream::app);
    if (!fileStream) {
        cout << "Cannot open file, file does not exit. Creating new file..";
        fileStream.open(filename, fstream::in | fstream::out | fstream::trunc);
        fileStream << '\n';
        fileStream.close();
    }
    cout << previouslyObjects(filename);
    while (input != 0) {
        printMenu();
        cin >> input;
        if (input == 0) {
            return 0;
        }
        // create and write object in file
        if (input == 1) {
            fileStream.open(filename.c_str(), ofstream::out | ofstream::app);
            Astronomical obj;
            cout << "Enter solar system name! ";
            cin >> solarSystem;
            obj.setSolarSystem(solarSystem);
            cout << "Enter position in the system! ";
            cin >> posInSystem;
            obj.setPosInSystem(posInSystem);
            cout << "Enter mass in kg! ";
            cin >> mass;
            obj.setMass(mass);
            cout << "Enter radius in meters! ";
            cin >> radius;
            obj.setRadius(radius);
            cout << "Enter type! " << endl;
            cout << "0 - unknown" << endl;
            cout << "1 - star" << endl;
            cout << "2 - rocky planet" << endl;
            cout << "3- gas giant" << endl;
            cin >> t;
            switch (t) {
            case 0:
                type = unknown;
                break;
            case 1:
                type = star;
                break;
            case 2:
                type = rockyPlanet;
                break;
            case 3:
                type = gasGiant;
                break;
            }
            obj.setType(type);
            cin.clear();
            cin.ignore();
            cout << "Enter nickname! ";
            getline(cin, nickname);
            obj.setNickname(nickname);
            fileStream << obj;
            fileStream.close();
        }
        cin.clear();
        // search and write user info for planets of a star system
        if (input == 2) {
            string systemName;
            string readContent;
            cin.clear();
            cin.ignore();
            cout << "Enter a system name! ";
            getline(cin, systemName);
            fileStream.open(filename.c_str(), ios_base::in);
            fileStream.seekg(0, ios::beg);
            if (!fileStream.is_open()) {
                cout << "Error reading file!" << endl;
                return 0;
            } else {
                while (fileStream >> readContent) {
                    if (compare(systemName, readContent)) {
                        long pos = (long)fileStream.tellp();
                        pos -= readContent.size();
                        fileStream.seekp(pos);
                        string str;
                        stringstream stream;
                        while (fileStream >> str) {
                            stream << str;
                            if (str == "}") {
                                break;
                            }
                        }
                        cout << stream.str() << endl;
                    }
                }
            }
            fileStream.close();
        }
        if (input == 3) {
            string systemName, positionInSystem, readContent;
            fileStream.open(filename.c_str(), ios_base::in);
            fileStream.seekg(0, ios::beg);
            cout << "Enter name and position (Name-position)! ";
            cin.clear();
            cin.ignore();
            getline(cin, systemName);
            if (!fileStream.is_open()) {
                cout << "Error reading file!" << endl;
                return 0;
            } else {
                while (fileStream >> readContent) {
                    if (systemName == readContent) {
                        long pos = (long)fileStream.tellp();
                        pos -= systemName.size();
                        fileStream.seekp(pos);
                        string str;
                        stringstream stream;
                        while (fileStream >> str) {
                            stream << str;
                            if (str == "}") {
                                break;
                            }
                        }
                        cout << stream.str() << endl;
                    }
                }
            }
        }
    }
    return 0;
}

