using System;

public class Startup
{
    private static Dough GetDough(string[] doughParams)
    {
        string flourType = doughParams[1];
        string bakingTechnique = doughParams[2];
        int weightInGrams = int.Parse(doughParams[3]);

        Dough dough = null;

        try
        {
            dough = new Dough(flourType, bakingTechnique, weightInGrams);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }

        return dough;
    }

    public static void Main()
    {
        string pizzaName = Console.ReadLine().Split()[1];

        Pizza pizza = null;

        try
        {
            pizza = new Pizza(pizzaName);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }

        string[] doughParams = Console.ReadLine().Split();

        Dough dough = GetDough(doughParams);

        pizza.Dough = dough;

        string input = null;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] toppingParams = input.Split();

            string toppingType = toppingParams[1];
            int toppingWeightInGrams = int.Parse(toppingParams[2]);

            Topping topping = null;

            try
            {
                topping = new Topping(toppingType, toppingWeightInGrams);
                pizza.AddTopping(topping);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        Console.WriteLine(pizza);
    }    
}