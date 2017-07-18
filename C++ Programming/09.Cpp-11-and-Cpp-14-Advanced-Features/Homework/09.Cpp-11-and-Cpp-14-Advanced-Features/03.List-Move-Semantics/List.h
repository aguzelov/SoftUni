#ifndef LIST_H
#define LIST_H

#include <string>
#include <iostream>
#include <stdexcept>
template<typename T>
class List {
private:
    class Node {
	private:
		T value;
		Node * prev;
		Node * next;

	public:
		Node( T value, Node * prev, Node * next ) :
			value( value ),
			prev( prev ),
			next( next ) {
		}

		T getValue() const {
			return this->value;
		}
        void setValue(T value) {
			this->value = value;
		}

		Node * getNext() const {
			return this->next;
		}
		void setNext( Node * next ) {
			this->next = next;
		}

		Node * getPrev() const {
			return this->prev;
		}
		void setPrev( Node * prev ) {
			this->prev = prev;
		}
    };

	Node * head;
	Node * tail;
	size_t size;
public:
	class Iterator {
	private:
		Node * currend;
	public:
		Iterator( Node * start ) :
			currend( start ) {}

		Iterator& operator++() {
			this->currend = this->currend->getNext();
			return *this;
		}

		bool operator==( const Iterator& other ) const {
			return this->currend==other->currend;
		}

		bool operator!=( const Iterator& other ) const {
			return this->currend!=other.currend;
		}

		T operator*() {
			return currend->getValue();
		}
	};
    List () :
		head( nullptr ),
		tail( nullptr ),
		size( 0 ) {
	}
    List(const List& other) :
		head( nullptr ),
		tail( nullptr ),
		size( 0 ) {
		this->addAll( other );
	}
	List( List &&other ) {
		this->removeAll();
		this->addAll( other );
		other.removeAll();
	}

	List( std::initializer_list<T> initList ) {
		for(T item : initList) {
			this->add( item );
		}
	}

    T first() const {
		if(this->isEmpty()) {
			throw std::range_error( "Cannot get first element of empty list" );
		}

		return this->head->getValue();
	}
    void add(T value) {
		if(this->isEmpty()) {
			this->head = new Node( value, nullptr, nullptr );
			this->tail = this->head;
		} else {
			Node * added = new Node( value, this->tail, nullptr );
			this->tail->setNext( added );
			this->tail = added;
		}

		this->size++;
	}
    void addAll(const List& other) {
		for(Node * node = other.head; node!=nullptr; node = node->getNext()) {
			this->add( node->getValue() );
		}
	}
    void removeFirst() {
		if(!this->isEmpty()) {
			Node * oldHeadElement = this->head;

			if(this->head!=this->tail) {
				// we have more than 1 node
				this->head = this->head->getNext();
				this->head->setPrev( nullptr );
			} else {
				// we have only 1 node
				this->head = nullptr;
				this->tail = nullptr;
			}

			delete oldHeadElement;

			this->size--;
		}
	}
    void removeAll() {
		while(!this->isEmpty()) {
			this->removeFirst();
		}
	}

    size_t getSize() const {
		return this->size;
	}
    bool isEmpty() const {
		return this->getSize()==0;
	}

    static List getReversed(List l) {
		List reversed;
		for(Node * node = l.tail; node!=nullptr; node = node->getPrev()) {
			reversed.add( node->getValue() );
		}

		return reversed;
	}
    std::string toString() const {
		std::ostringstream output;

		for(Node * node = this->head; node!=nullptr; node = node->getNext()) {
			output<<node->getValue();

			// this check avoids adding a blankspace after the last element
			if(node->getNext()!=nullptr) {
				output<<" ";
			}
		}

		return output.str();
	}

	Iterator begin()const {
		return Iterator(this->head);
	}
	Iterator end() const {
		return Iterator( nullptr );
	}

    List& operator<<(const T& value) {
		this->add( value );
		return *this;
	}
    List& operator<<(const List& other) {
		this->addAll( other );
		return *this;
	}

    List& operator=(const List& other) {
		if(this!=&other) {
			this->removeAll();
			this->addAll( other );
		}

		return *this;
	}
	List& operator=( List && other ) {
		if(this!=&other) {
			this->removeAll();
			this->addAll( other );
			other.removeAll();
		}

		return *this;
	}

    ~List() {
		this->removeAll();
	}
};

#endif // LIST_H
