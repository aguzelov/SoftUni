using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sorting
{
    public class MergeSort<T> where T : IComparable
    {
        public static List<T> Sort(List<T> unsorted)
        {
            List<T> sorted = Merge(unsorted);

            return sorted;
        }

        private static List<T> Merge(List<T> unsorted)
        {
            if (unsorted.Count <= 1)
            {
                return unsorted;
            }

            int middle = unsorted.Count / 2;

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }

            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = Merge(left);
            right = Merge(right);
            return Merge(left, right);
        }

        private static List<T> Merge(List<T> left, List<T> right)
        {
            var result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (IsLess(left.First(), right.First()))
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return result;
        }

        private static bool IsLess(T left, T right)
        {
            return left.CompareTo(right) < 0;
        }
    }
}