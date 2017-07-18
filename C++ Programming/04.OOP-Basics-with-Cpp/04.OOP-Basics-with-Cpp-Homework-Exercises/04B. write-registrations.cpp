/* 04A. write-registrations.cpp : Defines the entry point for the console application.
visual studio
*/

#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <fstream>
#include <iterator>
#include <iomanip>

using namespace std;

class Owner {
private:
    static vector<string> data;
    string name;
    short int age;
    int id;
    static int idCounter;
    void readData() {
        fstream read_file("personinfo.txt");
        stringstream buffer;
        buffer << read_file.rdbuf();
        string temp;
        int index = 0;
        if (this->data.size() == 0) {
            while (buffer >> temp) {
                this->data.push_back(temp);
                index++;
                if (index % 3 == 0) {
                    this->idCounter++;
                }
            }
        }
        read_file.close();
    }
public:
    Owner() {
        readData();
    }
    Owner(string name, short int age) :
        name(name), age(age), id(idCounter++) {
        setData();
    }
    void setName(string name) {
        this->name = name;
    }
    void setAge(short int age) {
        this->age = age;
    }
    void setData() {
        stringstream ss;
        //Push ID
        ss << this->id;
        data.push_back(ss.str());
        ss.str(string());
        ss.clear();
        //Push Name
        data.push_back(this->name);
        //Push age
        ss << this->age;
        data.push_back(ss.str());
        ss.str(string());
        ss.clear();
        writeOwnerData();
    }
    void changeName(string id, string newName) {
        int index = 0;
        for (vector<string>::const_iterator i = data.begin(); i != data.end(); i++) {
            if (*i == id) {
                this->data[index + 1] = newName;
            }
            index++;
        }
    }
    void changeAge(string id, string age) {
        int index = 0;
        for (vector<string>::const_iterator i = data.begin(); i != data.end(); i++) {
            if (*i == id) {
                this->data[index + 2] = age;
            }
            index++;
        }
    }
    string getName()const {
        return this->name;
    }
    string getAge() const {
        stringstream ss;
        ss << this->age;
        return ss.str();
    }
    string getId() const {
        stringstream ss;
        ss << this->id;
        return ss.str();
    }
    void getData() const {
        int index = 0;
        cout << setw(5) << left << "ID";
        cout << setw(15) << left << "Name";
        cout << setw(15) << left << "Age" << endl;
        cout << "=======================" << endl;
        for (vector<string>::const_iterator i = data.begin(); i != data.end(); i++) {
            if (index == 0 ) {
                cout << setw(5) << left << *i;
            } else {
                cout << setw(15) << left << *i;
            }
            index++;
            if (index == 3) {
                cout << endl;
                index = 0;
            }
        }
    }
    void writeOwnerData() const {
        ofstream output_file("personinfo.txt");
        ostream_iterator<string> output_iterator(output_file, " ");
        int index = 0;
        for (vector<string>::const_iterator i = data.begin(); i != data.end(); i += 3) {
            copy(data.begin() + index, data.begin() + (index + 3), output_iterator);
            output_file << endl;
            index += 3;
        }
        output_file.close();
    }
};
class Car : public Owner {
private:
    static vector<string> carData;
    string manufName;
    string modelName;
    int horsepower;
    string regNumber;
    Owner * owner;
    void readCarData() {
        fstream read_file("info.txt");
        stringstream buffer;
        buffer << read_file.rdbuf();
        if (this->carData.size() == 0) {
            string temp;
            while (buffer >> temp) {
                this->carData.push_back(temp);
            }
        }
        read_file.close();
    }
public:
    Car() {
        readCarData();
    }
    Car(string manufName, string modelName, int horsepower, string regNumber, int id)
        : manufName(manufName), modelName(modelName),
          horsepower(horsepower), regNumber(regNumber) {
        setCarData(id);
    }
    Car(string manufName, string modelName, int horsepower, string regNumber, Owner * owner) :
        manufName(manufName), modelName(modelName),
        horsepower(horsepower), regNumber(regNumber) {
        this->owner = owner;
        setCarData();
    }
    void changeRegistration(string oldReg, string newReg, string newId) {
        int index = 0;
        for (vector<string>::const_iterator i = carData.begin(); i != carData.end(); i++) {
            if (*i == oldReg) {
                this->carData[index] = newReg;
                this->carData[index - 4] = newId;
            }
            index++;
        }
    }
    string getHp() {
        stringstream ss;
        ss << this->horsepower;
        return ss.str();
    }
    void setCarData() {
        stringstream ss;
        carData.push_back(owner->getId());
        carData.push_back(this->manufName);
        carData.push_back(this->modelName);
        ss << this->horsepower;
        carData.push_back(ss.str());
        ss.str(string());
        ss.clear();
        carData.push_back(this->regNumber);
        writeCarData();
    }
    void setCarData(int id) {
        stringstream ss;
        ss << id;
        carData.push_back(ss.str());
        carData.push_back(this->manufName);
        carData.push_back(this->modelName);
        ss.str(string());
        ss.clear();
        ss << this->horsepower;
        carData.push_back(ss.str());
        ss.str(string());
        ss.clear();
        carData.push_back(this->regNumber);
        writeCarData();
    }
    void getCarData() const {
        int index = 0;
        cout << setw(10) << left << "ID";
        cout << setw(10) << left << "Manuf.";
        cout << setw(10) << left << "Model";
        cout << setw(10) << left << "hp";
        cout << setw(10) << left << "Reg.Num" << endl;
        cout << "====================================================" << endl;
        for (vector<string>::const_iterator i = carData.begin(); i != carData.end(); i++) {
            index++;
            cout << setw(10) << left << *i;
            if (index == 5) {
                cout << endl;
                index = 0;
            }
        }
    }
    void writeCarData() {
        ofstream output_file("info.txt");
        ostream_iterator<string> output_iterator(output_file, " ");
        int index = 0;
        for (vector<string>::const_iterator i = carData.begin(); i != carData.end(); i += 5) {
            copy(carData.begin() + index, carData.begin() + (index + 5), output_iterator);
            output_file << endl;
            index += 5;
        }
        index = 0;
        createRegistration();
    }

    void createRegistration() {
        string filename = "registrations.txt";
        fstream out_file;
        out_file.open(filename, fstream::in | fstream::out | fstream::app);
        if (!out_file) {
            out_file.open(filename, fstream::in | fstream::out | fstream::trunc);
            out_file << '\n';
        }
        out_file.close();
        out_file.open(filename, ios::app);
        out_file << "==========================" << endl;
        out_file << "Reg. number: ";
        out_file << this->regNumber << endl;
        out_file << "Manufacturer: ";
        out_file << this->manufName << endl;
        out_file << "Model: ";
        out_file << this->modelName << endl;
        out_file << "Horsepower: ";
        out_file << getHp() << endl;
        out_file << "............................" << endl;
        out_file << "Name: ";
        out_file << this->owner->getName() << endl;
        out_file << "Age: ";
        out_file << this->owner->getAge() << endl;
        out_file << "ID: ";
        out_file << this->owner->getId() << endl;
        out_file << "==========================" << endl;
        out_file.close();
    }

};

vector<string> Car::carData;
vector<string> Owner::data;
int Owner::idCounter = 0;

void printMenu() {
    cout << endl;
    cout << "1 - List all persons" << endl;
    cout << "2 - List all registrations" << endl;
    cout << "3 - Change person name" << endl;
    cout << "4 - Change person age" << endl;
    cout << "5 - Change car registration" << endl;
    cout << "6 - Create a new person" << endl;
    cout << "7 - Create a new registration" << endl;
    cout << "0 - Exit" << endl;
}


int main() {
    //from 04A
    //Owner frank{ "Frank", 24 };
    //Owner mike{ "Mike", 50 };
    //Owner aleks{ "Aleksandur", 32 };
    //Car audi{ "Audi", "A3", 150, "A3423MK", &frank };
    //Car vw{ "VW", "Golf", 95, "A1234MK", &mike };
    //Car fiat{ "Fiat", "Stilo", 115, "A6489MK", &aleks };
    //fiat.createRegistration();
    Owner owner;
    Car car;
    int input = 1;
    while (input != 0) {
        printMenu();
        cin >> input;
        switch (input) {
        case 0:
            return 0;
        case 1:
            owner.getData();
            break;
        case 2:
            car.getCarData();
            break;
        case 3: {
            cout << "Enter person ID: ";
            int idNumber;
            string id, newName;
            cin >> idNumber;
            stringstream ss;
            ss << idNumber;
            id = ss.str();
            cout << "Enter person new name: ";
            cin.clear();
            cin.ignore();
            getline(cin, newName);
            owner.changeName(id, newName);
        }
        break;
        case 4: {
            cin.clear();
            cin.ignore();
            cout << "Enter person ID: ";
            string id, age;
            getline(cin, id);
            cout << "Enter person new age: ";
            getline(cin, age);
            owner.changeAge(id, age);
        }
        break;
        case 5: {
            cin.clear();
            cin.ignore();
            cout << "Enter old registration number: ";
            string regNum;
            getline(cin, regNum);
            cout << "Enter new registration number: ";
            string newRegNum;
            getline(cin, newRegNum);
            cout << "Enter new person ID: ";
            string newID;
            getline(cin, newID);
            car.changeRegistration(regNum, newRegNum, newID);
        }
        break;
        case 6: {
            cin.clear();
            cin.ignore();
            cout << "Enter new person name: ";
            string name;
            getline(cin, name);
            cout << "Enter new person age: ";
            short int age;
            cin >> age;
            owner = {name, age};
        }
        break;
        case 7: {
            cin.clear();
            cin.ignore();
            cout << "Enter new car manufacturer name: ";
            string manufName;
            getline(cin, manufName);
            cout << "Enter new car model: ";
            string model;
            getline(cin, model);
            cout << "Enter new car horsepower: ";
            int hp;
            cin >> hp;
            cin.clear();
            cin.ignore();
            cout << "Enter new car registration number: ";
            string regNum;
            getline(cin, regNum);
            cout << "Enter new car owner ID: ";
            int id;
            cin >> id;
            car = { manufName, model, hp, regNum, id };
        }
        break;
        }
    }
    return 0;
}
