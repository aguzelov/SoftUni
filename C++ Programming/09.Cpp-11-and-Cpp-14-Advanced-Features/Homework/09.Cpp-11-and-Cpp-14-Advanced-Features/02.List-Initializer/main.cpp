#include <iostream>
#include <string>
#include <sstream>

#include "List.h"

int main() {
	List<int> numbers{ 1, -2, 42 };
	for(int n : numbers) {
		std::cout<<n<<" ";
	}
	std::cout<<std::endl;

	List<std::string> words{ "Guardians", "galaxy" };
	for(auto word:words) {
		std::cout<<word<<" ";
	}
	std::cout<<std::endl;


	system( "PAUSE" );
    return 0;
}
