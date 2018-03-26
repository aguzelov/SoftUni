using BashSoft.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.DataStructures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T>
    where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        public SimpleSortedList(IComparer<T> comparer, int capacity)
        {
            this.comparison = comparer;
            InitializeInnerCollection(capacity);
            this.size = 0;
        }

        public SimpleSortedList(int capacity)
        : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparer)
            : this(comparer, DefaultSize)
        {
        }

        public SimpleSortedList()
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public int Size
        {
            get { return this.size; }
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size == this.innerCollection.Length)
            {
                Resize();
            }

            this.innerCollection[this.Size] = element;
            this.size++;
            Sort(this.innerCollection, 0, this.Size - 1);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + collection.Count >= this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var element in collection)
            {
                if (element == null)
                {
                    throw new ArgumentNullException();
                }

                this.innerCollection[this.Size] = element;
                this.size++;
            }

            Sort(this.innerCollection, 0, this.Size - 1);
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }
                this.size--;
                this.innerCollection[this.Size] = default(T);
            }

            return hasBeenRemoved;
        }

        public int Capacity
        {
            get { return this.innerCollection.Length; }
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;
            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Size);

            this.innerCollection = newCollection;
        }

        private void Resize()
        {
            T[] newCollection = new T[this.Size * 2];

            Array.Copy(this.innerCollection, newCollection, Size);

            this.innerCollection = newCollection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder sb = new StringBuilder();
            foreach (var element in this.innerCollection)
            {
                if (element != null)
                {
                    sb.Append(element);
                    sb.Append(joiner);
                }
            }

            sb.Remove(sb.Length - joiner.Length, joiner.Length);
            return sb.ToString();
        }

        private void Sort(T[] elements, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            T num = elements[left];

            int i = left, j = right;

            while (i < j)
            {
                while (i < j && this.comparison.Compare(elements[j], num) > 0)
                {
                    j--;
                }

                elements[i] = elements[j];

                while (i < j && this.comparison.Compare(num, elements[i]) > 0)
                {
                    i++;
                }

                elements[j] = elements[i];
            }

            elements[i] = num;
            Sort(elements, left, i - 1);
            Sort(elements, i + 1, right);
        }
    }
}