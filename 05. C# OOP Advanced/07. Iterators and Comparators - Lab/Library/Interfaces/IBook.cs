using System.Collections.Generic;

public interface IBook
{
    string Title { get; }

    int Year { get; }

    IReadOnlyList<string> Authors { get; }
}