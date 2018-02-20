public class GoldenEditionBook : Book
{
    public override decimal Price
    {
        get
        {
            return base.Price * (decimal)1.3;
        }
    }

    public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
    {
    }
}