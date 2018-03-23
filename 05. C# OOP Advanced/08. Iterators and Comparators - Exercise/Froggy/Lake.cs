using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private List<int> stones;

    public Lake(params int[] strones)
    {
        this.stones = new List<int>(strones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int index = 1; index <= this.stones.Count; index++)
        {
            if (index % 2 != 0)
                yield return this.stones[index - 1];
        }

        for (int index = this.stones.Count; index >= 1; index--)
        {
            if (index % 2 == 0)
                yield return this.stones[index - 1];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}