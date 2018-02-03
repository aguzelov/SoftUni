using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData,
                                        string comparison,
                                        int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudent(wantedData.OrderBy(x => x.Value.Sum())
                    .Take(studentsToTake)
                .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudent(wantedData.OrderByDescending(x => x.Value.Sum())
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        public static void PrintStudent(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var pair in studentsSorted)
            {
                OutputWriter.PrintStudent(pair);
            }
        }
    }
}
