public class Threeuple<T,V,M> : Truple<T,V>
{
    private M item3;

    public Threeuple(T item1, V item2, M item3)
    :base(item1,item2)
    {
        this.Item3 = item3;
    }

    public M Item3 { get; set; }

    public override string ToString()
    {
        
        return $"{base.ToString()} -> {this.Item3}";
    }
}