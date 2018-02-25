public abstract class Food
{
    private int quantity;

    public int Quntity
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
        Quntity = quantity;
    }
}