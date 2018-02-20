using System;

public class StartUp
{
    public static void Main()
    {
        Pizza pizza = null;
        try
        {
            SetPizza(out pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Dough dough = null;
        try
        {
            GetDough(out dough);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        pizza.Dough = dough;

        string toppingInput = string.Empty;
        while ((toppingInput = Console.ReadLine()) != "END")
        {
            string[] toppingData = toppingInput.Split();
            string toppingType = toppingData[1];
            int toppingWeight = int.Parse(toppingData[2]);

            Topping topping = null;
            try
            {
                topping = new Topping(toppingType, toppingWeight);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            pizza.AddTopping(topping);

            if (pizza.Toppings > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                return;
            }
        }

        Console.WriteLine(pizza);
    }

    private static void GetDough(out Dough dough)
    {
        string[] doughInput = Console.ReadLine().Split();
        string ingredientType = doughInput[0];
        string flourType = doughInput[1];
        string bakingTechnique = doughInput[2];
        int weight = int.Parse(doughInput[3]);
        dough = new Dough(flourType, bakingTechnique, weight);
    }

    private static void SetPizza(out Pizza pizza)
    {
        pizza = null;
        string name = Console.ReadLine().Split()[1];
        pizza = new Pizza(name);
    }
}