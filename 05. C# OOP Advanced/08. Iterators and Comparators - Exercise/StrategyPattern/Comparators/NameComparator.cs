using System.Collections.Generic;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int xNameLength = x.Name.Length;
        int yNameLength = y.Name.Length;

        int result = xNameLength.CompareTo(yNameLength);

        if (result == 0)
        {
            char xFirstLetter = x.Name.ToLower()[0];
            char yFirstLetter = y.Name.ToLower()[0];

            result = xFirstLetter.CompareTo(yFirstLetter);
        }

        return result;
    }
}