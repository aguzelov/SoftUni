

#include <sstream>
#include <stdexcept>
template<class T>
List<T>::Node::Node(T value, Node * prev, Node * next) :
    value(value),
    prev(prev),
    next(next) {
}
template<class T>
T List<T>::Node::getValue() const {
    return this->value;
}
template<class T>
void List<T>::Node::setValue(T value) {
    this->value = value;
}
template<class T>
List<T>::Node * List<T>::Node::getNext() const {
    return this->next;
}
template<class T>
void List<T>::Node::setNext(Node * next) {
    this->next = next;
}
template<class T>
List::Node * List::Node::getPrev() const {
    return this->prev;
}
template<class T>
void List<T>::Node::setPrev(Node * prev) {
    this->prev = prev;
}
template<class T>
List<T>::List() :
    head(nullptr),
    tail(nullptr),
    size(0) {
}
template<class T>
List<T>::List(const List& other) :
    head(nullptr),
    tail(nullptr),
    size(0) {
    this->addAll(other);
}
template<class T>
T List<T>::first() const {
    if (this->isEmpty()) {
        throw std::range_error("Cannot get first element of empty list");
    }

    return this->head->getValue();
}
template<class T>
void List<T>::add(T value) {
    if (this->isEmpty()) {
        this->head = new Node(value, nullptr, nullptr);
        this->tail = this->head;
    } else {
        Node * added = new Node(value, this->tail, nullptr);
        this->tail->setNext(added);
        this->tail = added;
    }

    this->size++;
}
template<class T>
void List<T>::addAll(const List& other) {
    for (Node * node = other.head; node != nullptr; node = node->getNext()) {
        this->add(node->getValue());
    }
}
template<class T>
void List<T>::removeFirst() {
    if (!this->isEmpty()) {
        Node * oldHeadElement = this->head;

        if (this->head != this->tail) {
            // we have more than 1 node
            this->head = this->head->getNext();
            this->head->setPrev(nullptr);
        } else {
            // we have only 1 node
            this->head = nullptr;
            this->tail = nullptr;
        }

        delete oldHeadElement;

        this->size--;
    }
}
template<class T>
void List<T>::removeAll() {
    while (!this->isEmpty()) {
        this->removeFirst();
    }
}
template<class T>
size_t List<T>::getSize() const {
    return this->size;
}
template<class T>
bool List<T>::isEmpty() const {
    return this->getSize() == 0;
}
template<class T>
List<T> List<T>::getReversed(List l) {
    List reversed;
    for (Node * node = l.tail; node != nullptr; node = node->getPrev()) {
        reversed.add(node->getValue());
    }

    return reversed;
}
template<class T>
std::string List<T>::toString() const {
    std::ostringstream output;

    for (Node * node = this->head; node != nullptr; node = node->getNext()) {
        output << node->getValue();

        // this check avoids adding a blankspace after the last element
        if (node->getNext() != nullptr) {
            output << " ";
        }
    }

    return output.str();
}
template<class T>
List<T>& List<T>::operator<<(const T& value) {
    this->add(value);
    return *this;
}
template<class T>
List<T>& List<T>::operator<<(const List& other) {
    this->addAll(other);
    return *this;
}
template<class T>
List<T>& List<T>::operator=(const List& other) {
    if (this != &other) {
        this->removeAll();
        this->addAll(other);
    }

    return *this;
}
template<class T>
List<T>::~List() {
    this->removeAll();
}
