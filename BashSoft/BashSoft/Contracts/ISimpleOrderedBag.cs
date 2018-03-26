using System;
using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface ISimpleOrderedBag<T> : IEnumerable<T>
    where T : IComparable<T>
    {
        void Add(T element);

        void AddAll(ICollection<T> collection);

        bool Remove(T element);

        int Capacity { get; }

        int Size { get; }

        string JoinWith(string joiner);
    }
}