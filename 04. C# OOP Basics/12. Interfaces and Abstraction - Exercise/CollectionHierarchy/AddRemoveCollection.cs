using System.Text;

public class AddRemoveCollection : Collection, IRemovable
{
    protected StringBuilder removedElements;

    public string RemovedElements
    {
        get
        {
            return this.removedElements.ToString().Trim();
        }
    }

    public AddRemoveCollection()
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

        string lastElement = elements.Last.Value;
        elements.RemoveLast();
        base.count--;
        removedElements.Append(lastElement + " ");
    }
}