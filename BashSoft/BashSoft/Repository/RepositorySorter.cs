using BashSoft.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks,
                                        string comparison,
                                        int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudent(studentsWithMarks.OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudent(studentsWithMarks.OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        public void PrintStudent(Dictionary<string, double> studentsSorted)
        {
            foreach (var pair in studentsSorted)
            {
                OutputWriter.PrintStudent(pair);
            }
        }
    }
}