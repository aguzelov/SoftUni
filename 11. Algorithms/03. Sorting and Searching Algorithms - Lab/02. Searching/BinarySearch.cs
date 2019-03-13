using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Searching
{
    public class BinarySearch<T> where T : IComparable
    {
        public static int Search(List<T> items, T searcheItem)
        {
            var low = 0;
            var high = items.Count - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                if (items[mid].CompareTo(searcheItem) == 0)
                {
                    return mid;
                }
                else if (items[mid].CompareTo(searcheItem) < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
    }
}