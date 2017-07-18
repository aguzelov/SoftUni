#include <iostream>
#include <ctime>
#include <string>
#include <sstream>

#include "Matrix.h"

#include <vector>
#include <time.h>
#include <stdio.h>

time_t start, endt;

void startTime() {
	time( &start );
}
void endTime() {
	time( &endt );
	double dif = difftime( endt, start );
	printf( "Elasped time is %.21f seconds.", dif );
}



using namespace std;

// you can change this to true for testing locally
#define DEBUG_MODE true

typedef vector<vector<int> > M;

vector<vector<int> > readTestData();
void testEmptyMatrix();
void testNormalMatrix(M testData);
void testChangeSize(M testData);
void testToString(M testData);
void loadTest(M testData);

M getTestData() {
    M data;
    #if DEBUG_MODE == true
    data.push_back(vector<int>());
    data[0].push_back(11);
    data[0].push_back(12);
    data[0].push_back(13);
    data.push_back(vector<int>());
    data[1].push_back(21);
    data[1].push_back(22);
    data[1].push_back(23);
    #else
    data = readTestData();
    #endif // DEBUG_MODE

    return data;
}

void wrap(string name, void (*fn)()) {
    try {
        fn();
    } catch(const char * err) {
        cout << "-- failure in " << name << ": " << err << endl;
        throw err;
    }
}

int main() {

    string test;
    #if DEBUG_MODE == false
    cin >> test;
    #endif // DEBUG_MODE

    try {
        if (DEBUG_MODE || test == "empty") {
            wrap("testEmptyMatrix", testEmptyMatrix);
        }
		
        if (DEBUG_MODE || test == "normal") {
            wrap("testNormalMatrix", [](){testNormalMatrix(getTestData());});
        }
		
        if (DEBUG_MODE || test == "changeSize") {
            wrap("testChangeSize", [](){testChangeSize(getTestData());});
        }
		
        if (DEBUG_MODE || test == "toString") {
            wrap("testToString", [](){testToString(getTestData());});
        }

        if (DEBUG_MODE || test == "load") {
            wrap("loadTest", [](){loadTest(getTestData());});
        }
		
        cout << "tests passed" << endl;
    } catch (const char*) {
        cout << "one or more tests failed" << endl;
    }
	system( "PAUSE" );
    return 0;
}

unsigned int getRows(const M& m) {
    return m.size();
}

unsigned int getCols(const M& m) {
    if(getRows(m) > 0) {
        return m[0].size();
    }

    return 0;
}

template <typename T>
void assertEquals(T expected, T actual, string message) {
    if (expected != actual) {
        cout << message << " (expected " << expected << ", but was " << actual << ")" << endl;

        throw "assert error";
    }
}

void assertOutOfBounds(Matrix & m, int row, int col) {
    try {
        m.get(row, col);
        cout << "Bad get() access handling - expected exception on out of bounds access" << endl;
        throw "exception expected";
    } catch(exception& e) {
    }

    try {
        m.set(row, col, 42);
        cout << "Bad set() access handling - expected exception on out of bounds access" << endl;
        throw "exception expected";
    } catch(exception& e) {
    }
}

void assertMatrix(const M& expected, const Matrix& actual) {
    unsigned int actualRows = actual.getRows(),
        actualCols = actual.getColumns();
    assertEquals(getRows(expected), actualRows, "Rows differ");
    assertEquals(getCols(expected), actualCols, "Columns differ");
	
    for (unsigned int row = 0; row < actualRows; row++) {
        for (unsigned int col = 0; col < actualCols; col++) {
            assertEquals(expected[row][col], actual.get(row, col), "Cells differ");
        }
    }
}

M readTestData() {
    unsigned int rows, cols;
    cin >> rows >> cols;

    M matrix;

    for (unsigned int row = 0; row < rows; row++) {
        matrix.push_back(vector<int>());
        for (unsigned int col = 0; col < cols; col++) {
            int cell;
            cin >> cell;
            matrix[row].push_back(cell);
        }
    }

    return matrix;
}

void testEmptyMatrix() {
    Matrix m(0, 0);
	
    assertEquals((unsigned)0, m.getRows(), "Bad rows");
    assertEquals((unsigned)0, m.getColumns(), "Bad columns");
	
    assertOutOfBounds(m, 0, 0);
	
}

void testNormalMatrix(M expected) {
    unsigned int rows = getRows(expected),
        cols = getCols(expected);

    Matrix actual(rows, cols);
	
    for (unsigned int row = 0; row < rows; row++) {
        for (unsigned int col = 0; col < cols; col++) {
            actual.set(row, col, expected[row][col]);
        }
    }
	
    assertMatrix(expected, actual);
	
    assertOutOfBounds(actual, rows + 1, 0);
	
    assertOutOfBounds(actual, 0, cols + 1);
	
}

void testToString(M expected) {
    unsigned int rows = getRows(expected),
        cols = getCols(expected);

    Matrix actual(rows, cols);
	
    for (unsigned int row = 0; row < rows; row++) {
        for (unsigned int col = 0; col < cols; col++) {
            actual.set(row, col, expected[row][col]);
        }
    }

    assertMatrix(expected, actual);
	
    M parsed;
    istringstream linesStream(actual.toString());

    string line;
    while(getline(linesStream, line)) {
        istringstream valuesStream(line);
        int number;
        vector<int> lineValues;
        while(valuesStream >> number) {
            lineValues.push_back(number);
        }
        parsed.push_back(lineValues);
    }
	
    assertMatrix(parsed, actual);
	
    assertOutOfBounds(actual, rows + 1, 0);
    assertOutOfBounds(actual, 0, cols + 1);
	
}

void testChangeSize(M expected) {
    unsigned int rows = getRows(expected),
        cols = getCols(expected);

    Matrix actual(rows, cols);

    for (unsigned int row = 0; row < rows; row++) {
        for (unsigned int col = 0; col < cols; col++) {
            actual.set(row, col, expected[row][col]);
        }
    }

    assertOutOfBounds(actual, rows + 1, 0);
    assertOutOfBounds(actual, 0, cols + 1);

    actual.changeSize(rows * 2, cols * 3);

    assertEquals(rows * 2, actual.getRows(), "Bad changed rows");
    assertEquals(cols * 3, actual.getColumns(), "Bad changed columns");
	
    M expecedChangedSize = expected;
    while(expecedChangedSize.size() < actual.getRows()) {
        expecedChangedSize.push_back(vector<int>());
    }
	
    for(unsigned int i = 0; i < expecedChangedSize.size(); i++) {
        while(expecedChangedSize[i].size() < actual.getColumns()) {
            expecedChangedSize[i].push_back(0);
        }
    }
	
    int setValue = clock() % 100;
    expecedChangedSize[rows + 1][cols + 1] = setValue,
    actual.set(rows + 1, cols + 1, setValue);
	
    assertMatrix(expecedChangedSize, actual);
	
    actual.changeSize(rows, cols);
    assertMatrix(expected, actual);
	
}

void loadTest(M expected) {
    unsigned int rows = getRows(expected),
        cols = getCols(expected);
	
    Matrix actual(rows, cols);
    cout <<"a";
    for (unsigned int row = 0; row < rows; row++) {
        for (unsigned int col = 0; col < cols; col++) {
            actual.set(row, col, expected[row][col]);
        }
    }
	
    cout <<"b";

    Matrix copyAssigned(1, 1);
	
    for (unsigned int i = 0; i < 1000; i++) {
        Matrix copyConstructed(actual);
        cout <<"c";
        copyAssigned = copyConstructed;
        cout <<"d";
    }
	
    assertMatrix(expected, copyAssigned);
}

