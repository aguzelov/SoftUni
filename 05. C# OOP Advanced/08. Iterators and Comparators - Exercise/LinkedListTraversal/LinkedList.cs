using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private class Node<T>
    {
        public Node<T> Next;
        public T Value;
    }

    private Node<T> head;
    private Node<T> current;
    public int Count;

    public LinkedList()
    {
        this.head = new Node<T>();
        this.current = this.head;
    }

    public void AddAtLast(T data)
    {
        Node<T> newNode = new Node<T> { Value = data };
        this.current.Next = newNode;
        this.current = newNode;
        this.Count++;
    }

    public void AddAtStart(T data)
    {
        Node<T> newNode = new Node<T>() { Value = data };
        newNode.Next = this.head.Next;
        this.head.Next = newNode;
        this.Count++;
    }

    public void RemoveFromStart(T element)
    {
        if (this.Count > 0)
        {
            Node<T> curr = this.head;
            Node<T> prev = curr;
            while (curr.Next != null)
            {
                curr = curr.Next;

                Node<T> next = curr.Next;

                if (curr.Value.Equals(element))
                {
                    prev.Next = next;
                    this.Count--;
                    return;
                }

                prev = curr;
            }
        }
        else
        {
            throw new InvalidOperationException("No element exist in this linked list.");
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> curr = this.head;
        while (curr.Next != null)
        {
            curr = curr.Next;
            yield return curr.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}