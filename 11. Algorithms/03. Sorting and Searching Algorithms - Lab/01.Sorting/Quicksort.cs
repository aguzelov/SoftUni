using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Sorting
{
    public class Quicksort<T> where T : IComparable
    {
        public static List<T> Sort(List<T> unsorted)
        {
            var sortes = Sort(unsorted, 0, unsorted.Count - 1);
            return sortes;
        }

        private static List<T> Sort(List<T> unsorted, int left, int right)
        {
            var result = new List<T>();
            if (left < right)
            {
                int pivot = Partition(unsorted, left, right);

                if (pivot > 1)
                {
                    result = Sort(unsorted, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    result = Sort(unsorted, pivot + 1, right);
                }
            }
            else
            {
                result = unsorted;
            }
            return result;
        }

        private static int Partition(List<T> unsorted, int left, int right)
        {
            T pivot = unsorted[left];
            while (true)
            {
                while (unsorted[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (unsorted[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left < right)
                {
                    T temp = unsorted[left];
                    unsorted[left] = unsorted[right];
                    unsorted[right] = temp;

                    if (unsorted[left].CompareTo(unsorted[right]) == 0)
                    {
                        left++;
                    }
                }
                else
                {
                    return right;
                }
            }
        }
    }
}