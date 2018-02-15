using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        List<Cat> cats = new List<Cat>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputElements = input.Split(" ");
            string catBread = inputElements[0];
            string catName = inputElements[1];
            string specifiCharacteristic = inputElements[2];

            switch(catBread)
            {
                case "Siamese":
                    int size = int.Parse(specifiCharacteristic);
                    cats.Add(new Siamese(catBread, catName, size));
                    break;
                case "StreetExtraordinaire":
                    int decibels = int.Parse(specifiCharacteristic);
                    cats.Add(new StreetExtraordinaire(catBread, catName, decibels));
                    break;
                case "Cymric":
                    decimal furLength = decimal.Parse(specifiCharacteristic);
                    cats.Add(new Cymric(catBread, catName, furLength));
                    break;
            }
        }

        string name = Console.ReadLine();

        Console.WriteLine(cats.FirstOrDefault(c=> c.Name == name).ToString());
    }
}
