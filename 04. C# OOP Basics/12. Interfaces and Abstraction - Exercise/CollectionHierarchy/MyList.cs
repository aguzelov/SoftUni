using System.Text;

public class MyList : Collection, IRemovable
{
    protected StringBuilder removedElements;

    public string RemovedElements
    {
        get
        {
            return this.removedElements.ToString().Trim();
        }
    }

    public int Used
    {
        get
        {
            return this.count;
        }
    }

    public MyList()
        : base()
    {
        this.removedElements = new StringBuilder();
    }

    public override void Add(string element)
    {
        base.elements.AddFirst(element);
        base.count++;
        base.addIndexes.Append(0 + " ");
    }

    public void Remove()
    {
        if (base.count == 0)
        {
            return;
        }
        string firstElement = elements.First.Value;
        base.elements.RemoveFirst();
        base.count--;
        removedElements.Append(firstElement + " ");
    }
}