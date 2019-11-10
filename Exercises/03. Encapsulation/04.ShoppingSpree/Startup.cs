using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static Dictionary<string, Person> GetPeople(string[] peopleParams)
    {
        Dictionary<string, Person> people = new Dictionary<string, Person>();

        foreach (string personParams in peopleParams)
        {
            string[] currentPersonParams = personParams.Split('=');

            string name = currentPersonParams[0];
            decimal money = decimal.Parse(currentPersonParams[1]);

            try
            {
                Person person = new Person(name, money);

                people[name] = person;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        return people;
    }

    private static Dictionary<string, Product> GetProducts(string[] productsParams)
    {
        Dictionary<string, Product> products = new Dictionary<string, Product>();

        foreach (string productParams in productsParams)
        {
            string[] currentProductParams = productParams.Split('=');

            string name = currentProductParams[0];
            decimal cost = decimal.Parse(currentProductParams[1]);

            try
            {
                Product product = new Product(name, cost);

                products[name] = product;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        return products;
    }

    public static void Main()
    {
       string[] peopleParams = Console.ReadLine().Split(';');

        Dictionary<string, Person> people = GetPeople(peopleParams);

        string[] productsParams = Console.ReadLine()
            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, Product> products = GetProducts(productsParams);

        string command = null;

        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandParams = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string personName = commandParams[0];
            string productName = commandParams[1];

            if (!people.ContainsKey(personName) || !products.ContainsKey(productName))
            {
                continue;
            }

            Person person = people[personName];
            Product product = products[productName];

            if (product.Cost > person.Money)
            {
                Console.WriteLine($"{personName} can't afford {productName}");
            }
            else
            {
                person.Bag.Add(product);
                person.Money -= product.Cost;

                Console.WriteLine($"{personName} bought {productName}");
            }
        }

        people.Values.ToList().ForEach(Console.WriteLine);
    }    
}