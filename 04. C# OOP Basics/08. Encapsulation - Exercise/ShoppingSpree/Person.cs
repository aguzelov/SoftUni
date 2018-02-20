using System;
using System.Collections.Generic;

internal class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public Person()
    {
        this.products = new List<Product>();
    }

    public Person(string name, decimal money) : this()
    {
        Name = name;
        Money = money;
    }

    public bool TryAddProduct(Product product)
    {
        if (product.Cost <= this.money)
        {
            products.Add(product);
            this.money -= product.Cost;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        string productToPrint = products.Count == 0 ? "Nothing bought" : $"{string.Join(", ", products)}";

        return $"{this.name} - {productToPrint}";
    }
}