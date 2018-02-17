using System;

public class PriceCalculator
{
    private decimal pricePerDay;
    private int numberOfDays;
    private Season season;
    private Discount discount;
    private decimal price;

    public PriceCalculator(Func<string> readLine)
    {
        string[] argsArr = readLine().Split();
        pricePerDay = decimal.Parse(argsArr[0]);
        numberOfDays = int.Parse(argsArr[1]);
        season = Enum.Parse<Season>(argsArr[2]);
        discount = Discount.None;
        if(argsArr.Length == 4)
        {
            discount = Enum.Parse<Discount>(argsArr[3]);
        }

        Calculate();
    }

    private void Calculate()
    {
        decimal tempTotal = pricePerDay * numberOfDays * (int)season;
        price = tempTotal - (tempTotal * (int)discount) / 100;
    }

    public override string ToString()
    {
        return price.ToString("F2");
    }
}