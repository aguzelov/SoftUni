public abstract class Food
{
    private int quantity;

    public int Quantity
    {
        get
        {
            return this.quantity;
        }
        protected set
        {
            this.quantity = value;
        }
    }

    protected Food(int quantity)
    {
        Quantity = quantity;
    }
}