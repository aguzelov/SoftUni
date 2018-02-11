/* 02. string-formatter.cpp :
visual studio
*/

#include <iostream>
#include <string>
#include <vector>

using namespace std;

class StringFormatter{
private:
	string& stringToFormat;
	string formatPrefix;
public:
	StringFormatter(string& stringToFormat, string formatPrefix): stringToFormat(stringToFormat), formatPrefix(formatPrefix) {}

	void format(vector<string> insertArr){
		int index = 0;
		int vectorIndex = 0;
		while (true)
		{
			index = this->stringToFormat.find(this->formatPrefix, index);
			if (index == string::npos){
				break;
			}

			this->stringToFormat.replace(index, (this->formatPrefix.size()+1), insertArr.at(vectorIndex));
			vectorIndex++;
			index += (this->formatPrefix.size())+1;
		}
	}
};


int main(){
	string s = "Dear *:0, Our company *:1 wants to make you a Donation Of *:2 Million *:3 in good faith.Please send us a picture of your credit card";
	StringFormatter formatter(s, "*:");
	formatter.format(vector<string> {"Ben Dover", "Totally Legit NonSpam Ltd", "13", "Leva"});
	cout << s << endl;
	return 0;
}

