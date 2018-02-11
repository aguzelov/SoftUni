using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double significanceThreshold = double.Parse(Console.ReadLine());

        double prevPrices = double.Parse(Console.ReadLine());

        for (int i = 0; i < n-1; i++)
        {
            double newPrice = double.Parse(Console.ReadLine());

            double threshold = CalculateThreshold(prevPrices, newPrice);
            bool isSignificantDifference = IsDifferent(threshold, significanceThreshold);
            
            string message = GetMessage(newPrice, prevPrices, threshold, isSignificantDifference);
            Console.WriteLine(message);

            prevPrices = newPrice;
        }
    }

    private static string GetMessage(double newPrice, double prevPrices, 
                                     double threshold, bool isSignificantDifference)
    {
        string text = "";

        if (threshold == 0)
        {
            text = string.Format("NO CHANGE: {0}", newPrice);
        }
        else if (!isSignificantDifference)
        {
            text = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", prevPrices, newPrice, threshold*100);
        }
        else if (isSignificantDifference && (threshold > 0))
        {
            text = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", prevPrices, newPrice, threshold*100);
        }
        else if (isSignificantDifference && (threshold < 0))
        {
            text = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", prevPrices, newPrice, threshold*100);
        }

        return text;
    }

    private static bool IsDifferent(double significanceThreshold, double currThreshold)
    {
        if (Math.Abs(significanceThreshold) >= currThreshold)
        {
            return true;
        }
        return false;
    }

    private static double CalculateThreshold(double prevPrice, double newPrice)
    {
        double threshold = (newPrice - prevPrice) / prevPrice;
        return threshold;
    }
}
