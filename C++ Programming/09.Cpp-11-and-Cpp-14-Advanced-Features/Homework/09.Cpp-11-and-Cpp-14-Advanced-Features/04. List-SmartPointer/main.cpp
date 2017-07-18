#include <iostream>
#include <string>
#include <sstream>

#include "List.h"
List<int> f( List<int> & a ) {
	return { a };
}

int main() {
	List<int> numbers{ 1, -2, 42 };
	while(true)
	{
		numbers = f( numbers );
	}
	

	system( "PAUSE" );
    return 0;
}
