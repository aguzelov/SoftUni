#include <iostream>
#include <fstream>
#include "SequenceGenerator.h"
#include "FibonacciGenerator.h"
#include "SqrtGenerator.h"
#include "SequencePrinter.h"

class SeqeuncePrinterToConsole : public SequencePrinter{
public:
	void setSequence(const SequenceGenerator &sequence){
		this->sequence = sequence.getInfo();
		print();
	}
	void print(){
		std::cout<<sequence << std::endl;
	}
};

class SeqeuncePrinterToFile :public SequencePrinter{
	std::ofstream fileStream;
public:
	SeqeuncePrinterToFile(std::string filename) :
		fileStream(filename){

	}
	void setSequence(const SequenceGenerator &sequence){
		this->sequence = sequence.getInfo();
		print();
	}
	void print(){
		fileStream << sequence << std::endl;
	}
};

class SeqeuncePrinterToString : public SequencePrinter{
	void setSequence(const SequenceGenerator &sequence){
		this->sequence = sequence.getInfo();
		return print();
	}
	void print(){
		std::cout << sequence << std::endl;
	}
};

SequencePrinter * getWriter(){
	return new SeqeuncePrinterToConsole();
}

int main(){
	using std::cout;
	using std::endl;

	typedef SequenceGenerator *SequenceGeneratorPtr;
	SequenceGeneratorPtr seqenGen = new FibonacciGenerator(3, 6);
	SequenceGeneratorPtr seqenGen2 = new SqrtGenerator(4, 10);


	SequencePrinter * writer = getWriter();
	writer->setSequence(*seqenGen);
	writer->setSequence(*seqenGen2);
	
	
	
	delete seqenGen;
	delete seqenGen2;



	system("PAUSE");
	return 0;
}