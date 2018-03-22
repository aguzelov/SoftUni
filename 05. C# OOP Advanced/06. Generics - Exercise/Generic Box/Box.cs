using System;

public class Box<T> : IComparable where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public T Value
    {
        get { return this.value; }
        private set { this.value = value; }
    }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }

    public int CompareTo(object obj)
    {
        var item = obj is T ? (T) obj : default(T);

        var result = this.Value.CompareTo(item);

        return result;
    }
}