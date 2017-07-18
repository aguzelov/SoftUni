#include "Matrix.h"
#include <sstream>


Matrix::Matrix( unsigned int rows, unsigned int columns ) : rows(rows), columns(columns), data(initRowsCols(rows,columns))
{
	
}

Matrix::Matrix( const Matrix & other ): rows(other.getRows()), columns(other.getColumns()), data(initRowsCols(other.getRows(), other.getColumns()))
{
	if(this!=&other) {
		for(int i = 0; i<other.getRows(); i++) {
			for(int j = 0; j<other.getColumns(); j++) {
				this->data[i][j] = other.get( i, j );
			}
		}
		
	}
}

unsigned int Matrix::getRows() const
{
	
	return this->rows;
}

unsigned int Matrix::getColumns() const
{
	return this->columns;
}

void Matrix::changeSize( unsigned int rows, unsigned int columns )
{
	
	DataType ** newData = new DataType*[rows]();
	for(int i = 0; i<rows; i++) {
		newData[i] = new DataType[columns]();
	}

	if(this->rows<rows || this->columns < columns) {

		for(int i = 0; i<this->rows; i++) {
			for(int j = 0; j<this->columns; j++) {
				newData[i][j] = data[i][j];
			}	
		}
		
	} else {

		for(int i = 0; i<rows; i++) {
			for(int j = 0; j<columns; j++) {
				newData[i][j] = data[i][j];
			}
		}
	}
	
	this->rows = rows;
	this->columns = columns;
	delete[] data;
	this->data = newData;
	
}

DataType Matrix::get( unsigned int row, unsigned int column ) const
{
	ensureInBounds( row, column );
	return this->data[row][column];
}

void Matrix::set( unsigned int row, unsigned int column, DataType value )
{
	ensureInBounds( row, column );
	this->data[row][column] = value;
}

std::string Matrix::toString() const
{
	std::stringstream ss;
	for(int i = 0; i<this->rows; i++) {
		for(int j = 0; j<this->columns; j++) {
			ss<<this->data[i][j]<<" ";
		}
		ss<<std::endl;
	}
	return ss.str();
}

Matrix & Matrix::operator=( const Matrix & other )
{
	
	if(this!=&other) {
		for(int i = 0; i<rows; i++) {
			delete[] data[i];
		}
		delete[] data;
		this->rows = other.getRows();
		this->columns = other.getColumns();

		DataType ** newData = new DataType*[rows];
		for(int i = 0; i<rows; i++) {
			newData[i] = new DataType[columns];
		}

		for(int i = 0; i<other.getRows(); i++) {
			for(int j = 0; j<other.getColumns(); j++) {
				newData[i][j] = other.get( i, j );
			}
		}
		this->data = newData;
	}
	return *this;
}

Matrix::~Matrix()
{
	for(int i = 0; i<rows; i++) {
		delete[] data[i];
	}
	delete[] data;
}

void Matrix::ensureInBounds( unsigned int row, unsigned int column ) const
{
	if(row>=this->rows || column >=this->columns) {
		throw std::range_error( "Out of bounds" );
	}
}

void Matrix::freeRowsCols( RowsCols data, unsigned int rows )
{
}

RowsCols Matrix::initRowsCols( unsigned int rows, unsigned int columns )
{
	DataType ** newData = new DataType*[rows];
	for(int i = 0; i<rows; i++) {
		newData[i] = new DataType[columns];
	}
	return newData;
}

void Matrix::copyData( RowsCols source, unsigned int sourceRows, unsigned int sourceColumns, RowsCols dest, unsigned int destRows, unsigned int destColumns )
{
}
