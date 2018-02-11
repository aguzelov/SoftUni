#include <iostream>
#include <unordered_map>
#include <map>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
	map<string, int> wordCounting;
	string word;
	cin>>word;
	while( word != "." )
	{
		wordCounting[word]++;
		cin>>word;
	}

	map<string, int>::iterator it = wordCounting.begin();
	map<int, vector<string> > queris;

	for(it; it!=wordCounting.end(); it++) {
		queris[it->second].push_back( it->first);
	}

	int numberOfQueris;
	cin>>numberOfQueris;
	
	
	map<int, bool> isSorted;
	for(int i = 0; i<numberOfQueris; i++) {
		int occurrenceCount, index;
		cin>>occurrenceCount>>index;

		
		if(queris.find(occurrenceCount)!=queris.end()) {
			if(!isSorted[occurrenceCount]) {
				sort( queris[occurrenceCount].begin(), queris[occurrenceCount].end() );
				isSorted[occurrenceCount] = true;
			}
			cout<<queris[occurrenceCount][index]<<endl;
		} else {
			cout<<"."<<endl;
		}
		
	}

	


	system( "PAUSE" );
	return 0;
}