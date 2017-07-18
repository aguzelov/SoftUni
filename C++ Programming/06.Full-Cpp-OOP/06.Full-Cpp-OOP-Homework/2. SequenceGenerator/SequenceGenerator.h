#ifndef SEQUENCEGENERATOR_H
#define SEQUENCEGENERATOR_H

#include <vector>

typedef double DataType;

class SequenceGenerator{
public:
	std::vector<int> names;

	int length;
	DataType * data;

	SequenceGenerator() :
		length(0),
		data(new DataType[length]){
	}
	SequenceGenerator(int length) :
		length(length),
		data(new DataType[length]){
	}
	SequenceGenerator(const SequenceGenerator &other) :
		names(other.names),
		length(other.length),
		data(new DataType[other.length]){
		copyData(other.data, other.length, this->data, this->length);
	}
	SequenceGenerator& operator=(const SequenceGenerator &other){
		if (this != &other){
			delete[] this->data;

			this->length = other.length;
			this->data = new DataType[other.length];

			copyData(other.data, other.length, this->data, this->length);
		}
		return *this;
	}
	~SequenceGenerator(){
		delete[] data;
	}

	DataType& operator[](int index){
		ensureIndexBounds(index);
		return this->data[index];
	}
	void ensureIndexBounds(int index){
		if (index < 0 || index >= this->length){
			throw "index out of bounds";
		}
	}

	void copyData(DataType * source, int sourceLength, DataType * dest, int destLength){
		for (int i = 0; i < sourceLength && i < destLength; i++){
			dest[i] = source[i];
		}
	}
	void setElement(int index, DataType value){
		changeLengthByOne();
		ensureIndexBounds(index);

		this->data[index] = value;

	}
	void changeLengthByOne(){
		int newLength = this->length + 1;
		DataType * newData = new DataType[newLength]();

		copyData(this->data, this->length, newData, newLength);

		delete[] this->data;

		this->data = newData;
		this->length = newLength;
	}


	virtual void write() = 0;
	int getLength(){
		return this->length;
	}
	double getName(int index){
		return names[index];
	}
	double getValue(int index){
		ensureIndexBounds(index);
		return this->data[index];
	}
};

#endif // !SEQUENCEGENERATOR_H
