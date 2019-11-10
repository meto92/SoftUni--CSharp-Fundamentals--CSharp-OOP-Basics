using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static IBuyer GetBuyer(string[] buyerParams)
    {
        IBuyer buyer = null;

        if (buyerParams.Length == 3)
        {
            string rebelName = buyerParams[0];
            int rebelAge = int.Parse(buyerParams[1]);
            string rebelGroup = buyerParams[2];

            buyer = new Rebel(rebelName, rebelAge, rebelGroup);
        }
        else
        {
            string citizenName = buyerParams[0];
            int citizenAge = int.Parse(buyerParams[1]);
            string citizenId = buyerParams[2];
            string citizenBirthdate = buyerParams[3];

            buyer = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
        }

        return buyer;
    }

    public static void Main()
    {
        int buyersCount = int.Parse(Console.ReadLine());

        Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

        for (int i = 0; i < buyersCount; i++)
        {
            string[] buyerParams = Console.ReadLine().Split();

            IBuyer buyer = GetBuyer(buyerParams);

            string personName = buyerParams[0];

            buyersByName[personName] = buyer;
        }

        string buyerName = null;

        while ((buyerName = Console.ReadLine()) != "End")
        {
            if (buyersByName.ContainsKey(buyerName))
            {
                buyersByName[buyerName].BuyFood();
            }
        }

        int totalAmountOfFoodPurchased = buyersByName.Sum(person => person.Value.Food);

        Console.WriteLine(totalAmountOfFoodPurchased);
    }   
}