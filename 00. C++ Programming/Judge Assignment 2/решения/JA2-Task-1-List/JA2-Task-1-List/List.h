#ifndef LIST_H
#define LIST_H

#include <string>

typedef int T;
class List {
private:
    class Node {
    private:
        T value;
        Node * prev;
        Node * next;

    public:
        Node(T value, Node * prev, Node * next);

        T getValue() const;
        void setValue(T value);

        Node * getNext() const;
        void setNext(Node * next);

        Node * getPrev() const;
        void setPrev(Node * prev);
    };

    Node * head;
    Node * tail;
    size_t size;
public:
    List();
    List(const List& other);

    T first() const ;
    void add(T value);
    void addAll(const List& other);
    void removeFirst();
    void removeAll();

    size_t getSize() const;
    bool isEmpty() const;

    static List getReversed(List l);
    std::string toString() const;

    List& operator<<(const T& value);
    List& operator<<(const List& other);

    List& operator=(const List& other);

    ~List();
};

#endif // LIST_H
