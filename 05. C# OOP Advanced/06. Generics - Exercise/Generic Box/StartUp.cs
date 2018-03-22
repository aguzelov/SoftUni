using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        int numberOfBoxInputs = int.Parse(Console.ReadLine());

        List<Box<double>> boxs = new List<Box<double>>();
        for (int i = 0; i < numberOfBoxInputs; i++)
        {
            double input = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>(input);
            boxs.Add(box);
        }

        double element = double.Parse(Console.ReadLine());
        Console.WriteLine(Compare(boxs, element));
    }

    public static int Compare<T>(List<Box<T>> boxs, T elemen)
    where T : IComparable<T>
    {
        int counter = 0;

        foreach (var box in boxs)
        {
            if (box.CompareTo(elemen) > 0) counter++;
        }

        return counter;
    }
}