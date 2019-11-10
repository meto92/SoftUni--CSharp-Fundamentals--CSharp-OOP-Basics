using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, Cat> cats = new Dictionary<string, Cat>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] catParams = input.Split();

            string breed = catParams[0];
            string name = catParams[1];
            double parameter = double.Parse(catParams[2]);

            Cat cat = null;

            switch (breed)
            {
                case "Siamese":
                    cat = new Siamese(name, parameter);
                    break;
                case "Cymric":
                    cat = new Cymric(name, parameter);
                    break;
                case "StreetExtraordinaire":
                    cat = new StreetExtraordinaire(name, parameter);
                    break;
            }

            cats[name] = cat;
        }

        string requestedName = Console.ReadLine();

        Console.WriteLine(cats[requestedName]);
    }
}