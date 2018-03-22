public class Truple<T,V>
{
    private T item1;
    private V item2;

    public Truple(T item1, V item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public T Item1 { get; set; }    
    public V Item2 { get; set; }

    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2}";
    }
}