/* 03. Car.cpp:
visual studio
*/

#include <iostream>
#include <string>
#include <sstream>

using namespace std;


class Owner{


private:
	string name;
	short int age;
	int id;
	static int idCounter;
public:
	Owner(){}
	Owner(string name, short int age) :
		name(name), age(age), id(idCounter++)
			{
	}
	void changeName(string name){
		this->name = name;
	}
	void changeAge(short int age){
		this->age = age;
	}

	string print()const{
		ostringstream print;
		print << endl;
		print << "Name: " << this->name << endl;
		print << "Age: " << this->age << endl;
		print << "ID: " << this->id << endl;
		print << "==============================" << endl;
		return print.str();
	}
};
class Car :public Owner{
public:
	string manufName;
	string modelName;
	int horsepower;
	string regNumber;
	Owner * owner;

	Car(string manufName, string modelName, int horsepower, string regNumber, Owner * owner) :
		manufName(manufName), modelName(modelName),
		horsepower(horsepower), regNumber(regNumber){
		this->owner = owner;
	}

	void changeOwnerAndRegistracion(Owner *owner, string regNumber){
		this->owner = owner;
		this->regNumber = regNumber;
	}
	string printCar() const{
		ostringstream print;
		print << "Car manufacturer name: " << this->manufName << endl;
		print << "Car model name: " << this->modelName << endl;
		print << "Car horsepower: " << this->horsepower << endl;
		print << "Car registration number: " << this->regNumber << endl;
		print << "Owner : " << owner->print();
		return print.str();
	}
};


int Owner::idCounter = 0;

void printList(){
	cout << "1 - Create a new person" << endl;
	cout << "2 - Create a new car" << endl;
	cout << "1 - Create a new person" << endl;
	cout << "1 - Create a new person" << endl;
}

int main()
{

	Owner frank{ "Frank", 24 };
	Owner Mike{ "Mike", 50 };
	Owner aleks{ "Aleksandur", 32 };

	Car audi {"Audi", "A3", 150, "A3423MK", &frank };
	Car vw{"VW", "Golf", 95, "A1234MK", &frank };
	Car fiat{ "Fiat", "Stilo", 115, "A6489MK", &Mike };
	cout << audi.printCar() << endl;
	cout << vw.printCar() << endl;
	cout << fiat.printCar() << endl;

	vw.changeOwnerAndRegistracion(&aleks, "B4455KK");
	cout << vw.printCar() << endl;
	vw.changeOwnerAndRegistracion(&Mike, "Fss41");
	cout << vw.printCar() << endl;
	return 0;
}

