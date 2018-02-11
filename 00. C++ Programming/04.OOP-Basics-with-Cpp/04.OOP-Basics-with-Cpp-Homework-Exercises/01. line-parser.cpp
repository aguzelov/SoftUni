/* 01. linear-parser.cpp :
visual studio
*/

#include <iostream>
#include <string>
#include <vector>
#include <stdlib.h>
#include <sstream>

using namespace std;
typedef string DataType;
typedef vector<int> IntSmartArray;
typedef vector<char> CharSmartArray;
class LineParser{
private:
	DataType line;
public:
	LineParser(){

	}
	LineParser(DataType line) : line(line){

	}
	DataType getLine() const{
		return this->line;
	}
	void setLine(DataType line){
		this->line = line;
	}
	void printLine(){
		stringstream stream(this->line);
		cout << stream.str() << endl;
	}
	//return vector<int>
	IntSmartArray getNumbers() const{
		IntSmartArray numbers;
		stringstream stream;
		for (int i = 0; i < this->line.size(); i++){
			if (isdigit(this->line[i])){
				stream << this->line[i] << " ";
			}
		}
		int a=0;
		while (stream >> a)
		{
			numbers.push_back(a);
		}

		return numbers;
	}
	//return string
	string getStrings() const {
		stringstream stream;
		for (int i = 0; i < this->line.size(); i++){
			if (isalpha(this->line[i])){
				stream << this->line[i];
			}
			if ((!isalpha(this->line[i])) && (isalpha(this->line[i-1]))){
				stream << " ";
			}
		}
		return stream.str();
	}
	//return vector<char>
	CharSmartArray getChars() const{
		string newLine = this->line;
		int pos = 0;
		while ((pos = newLine.find(" ", pos)) != string::npos)
		{
			newLine.replace(pos, 1, "");
			pos += 1;
		}
		CharSmartArray chars;
		for (int i = 0; i < newLine.size(); i++){
			chars.push_back(newLine[i]);
		}
		return chars;
	}

	void printNumbers() const{
		IntSmartArray numbers = getNumbers();
		for (IntSmartArray::iterator it = numbers.begin(); it != numbers.end(); it++){
			cout << *it << " ";
		}
		cout << endl;
	}
	void printStrings() const{
		cout << getStrings() << endl;
	}
	void printChars() const{
		CharSmartArray chars = getChars();
		for (CharSmartArray::iterator it = chars.begin(); it != chars.end(); it++){
			cout << *it;
		}
		cout << endl;
	}

};

int main() {
	LineParser p;
	p.setLine("dasdasd as6dasda77 das8 das9d asd9 a7s37 423rfdffh1 387423 4rhf");
	p.printLine();
	p.printNumbers();
	p.printStrings();
	p.printChars();


	return 0;
}
