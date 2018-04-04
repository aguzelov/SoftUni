using System;
using System.Collections.Generic;

namespace BubbleSort
{
    public class Bubble
    {
        public Bubble()
        {
        }

        public List<T> Sort<T>(List<T> collection)
            where T : IComparable<T>
        {
            bool hasSwap = true;

            while (hasSwap)
            {
                hasSwap = false;
                int countOfSwap = 0;
                for (int i = 0; i < collection.Count - 1; i++)
                {
                    T left = collection[i];
                    T right = collection[i + 1];

                    if (Swap(ref left, ref right))
                    {
                        countOfSwap++;
                        collection[i] = left;
                        collection[i + 1] = right;
                    }
                }

                hasSwap = countOfSwap > 0;
            }

            return collection;
        }

        private bool Swap<T>(ref T first, ref T second)
            where T : IComparable<T>
        {
            if ((first.CompareTo(second)) <= 0)
            {
                return false;
            }

            T temp = first;
            first = second;
            second = temp;

            return true;
        }
    }
}