#include <iostream>
#include <string>
#include <sstream>
#include <memory>
#include <unordered_set>

#include "List.h"
List<int> f( List<int> & a ) {
	return { a };
}

typedef std::shared_ptr<List<int>> ListPtr;
int main() {

	std::unordered_set<ListPtr> lists;
	lists.insert( std::make_shared<List>( &first ) );

	List<int> numbers{ 1, -2, 42 };
	while(true)
	{
		numbers = f( numbers );
	}
	

	system( "PAUSE" );
    return 0;
}
