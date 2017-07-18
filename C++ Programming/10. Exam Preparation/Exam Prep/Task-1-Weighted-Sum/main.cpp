#include <iostream>
#include <sstream>
#include <vector>

using namespace std;

int main() {
	int numberOfArray, elementInArray;
	cin>>numberOfArray>>elementInArray;
	vector<vector<int > > arrays;
	
	string line;
	int element = 0;

	for(int i = 0; i<numberOfArray; i++) {
		vector<int> arraysRow;
		for(int j = 0; j<elementInArray; j++) {
			cin>>element;
			arraysRow.push_back( element );
		}
		arrays.push_back( arraysRow );
	}
	
	for(int i = 0; i<numberOfArray; i++) {
		int weight;
		cin>>weight;
		for(int j = 0; j<elementInArray; j++) {
			arrays[i][j] = arrays[i][j]*weight;
		}
	}


	vector<int> result;
	result.reserve( 4 );
	
	for(int i = 0; i<elementInArray; i++) {
		int r = 0;
		for(int j = 0; j<numberOfArray; j++) {
			r += arrays[j][i] ;
		}
		result.push_back( r );
	}

	for(int i = 0; i<result.size(); i++) {
		cout<<result[i]<< " ";
	}

	system( "PAUSE" );
	return 0;
}