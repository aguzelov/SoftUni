#ifndef SEQUENCEPRINTER_H
#define SEQUENCEPRINTER_H
#include "SequenceGenerator.h"
#include <string>
class SequencePrinter{
public:
	std::string sequence;
	virtual void print() = 0;
	virtual void setSequence(const SequenceGenerator &sequence) = 0;
	void changeSequence(const SequenceGenerator &sequence){
		this->sequence = sequence.getInfo();
	}
};

#endif // !SEQUENCEPRINTER_H
