using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsWithMarks,
            string comparison,
            int studentsToTake);
    }
}