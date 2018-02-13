using System;

public class DateModifier
{
    private DateTime firstDate;
    private DateTime secondDate;

    public DateModifier()
    {
    }

    public DateModifier(string firstDate , string secondDate)
    {
        this.firstDate = DateTime.ParseExact(firstDate, "yyyy MM dd",
            System.Globalization.CultureInfo.InvariantCulture);

        this.secondDate = DateTime.ParseExact(secondDate, "yyyy MM dd",
            System.Globalization.CultureInfo.InvariantCulture);
    }

    public int DateDifference(string firstDate, string secondDate)
    {
        this.firstDate = DateTime.ParseExact(firstDate, "yyyy MM dd",
            System.Globalization.CultureInfo.InvariantCulture);

        this.secondDate = DateTime.ParseExact(secondDate, "yyyy MM dd",
            System.Globalization.CultureInfo.InvariantCulture);

        return Math.Abs((this.secondDate - this.firstDate).Days);
    }
}