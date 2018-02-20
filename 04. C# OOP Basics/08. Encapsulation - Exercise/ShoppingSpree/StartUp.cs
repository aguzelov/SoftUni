using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var persons = new List<Person>();
        var products = new Dictionary<string, Product>();
        try
        {
            GetPersons(persons);
            GetProductsPrice(products);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        while (GetPurchase(out string personName, out string productName))
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productName))
            {
                Console.WriteLine($"Name cannot be empty");
                return;
            }

            Person person = persons.FirstOrDefault(p => p.Name == personName);
            Product product = products[productName];

            if (person.TryAddProduct(product))
            {
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }

        persons.ForEach(p => Console.WriteLine(p.ToString()));
    }

    private static bool GetPurchase(out string personName, out string productName)
    {
        personName = null;
        productName = null;

        string input = Console.ReadLine();
        if (input == "END") return false;

        string[] purchaseData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        if (purchaseData.Length == 2)
        {
            personName = purchaseData[0];
            productName = purchaseData[1];
        }

        return true;
    }

    private static void GetPersons(List<Person> persons)
    {
        string[] personData = Console.ReadLine().Split(new string[] { ";", " " }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string data in personData)
        {
            string[] personInfo = data.Split("=", StringSplitOptions.RemoveEmptyEntries);

            if (personInfo.Length == 1) throw new ArgumentException($"Name cannot be empty");

            string name = personInfo[0];
            decimal money = decimal.Parse(personInfo[1]);
            try
            {
                Person person = new Person(name, money);
                persons.Add(person);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }
    }

    private static void GetProductsPrice(Dictionary<string, Product> products)
    {
        string[] productsData = Console.ReadLine().Split(new string[] { ";", " " }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string data in productsData)
        {
            string[] productInfo = data.Split("=", StringSplitOptions.RemoveEmptyEntries);

            if (productInfo.Length == 1) throw new ArgumentException($"Name cannot be empty");

            string name = productInfo[0];
            decimal cost = decimal.Parse(productInfo[1]);

            if (!products.ContainsKey(name))
            {
                products.Add(name, null);
            }

            try
            {
                products[name] = new Product(name, cost);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }
    }
}