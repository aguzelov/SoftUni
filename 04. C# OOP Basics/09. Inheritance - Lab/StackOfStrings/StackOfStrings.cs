using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        if (!string.IsNullOrWhiteSpace(item))
        {
            this.data.Add(item);
        }
    }

    public string Pop()
    {
        if (!this.IsEmpty())
        {
            int index = this.data.Count - 1;
            string element = this.data[index];
            this.data.RemoveAt(index);
            return element;
        }
        return null;
    }

    public string Peek()
    {
        if (!this.IsEmpty())
        {
            int index = this.data.Count - 1;
            string element = this.data[index];
            return element;
        }
        return null;
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }
}