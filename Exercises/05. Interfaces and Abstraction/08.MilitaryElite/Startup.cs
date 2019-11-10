using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<ISoldier> soldiers = new List<ISoldier>();
        Dictionary<string, Private> privatesById = new Dictionary<string, Private>();

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] soldierParams = input.Split();

            Enums.SoldierType soldierType = Enum.Parse<Enums.SoldierType>(soldierParams[0]);

            ISoldier soldier = SoldierFactory.GetSoldier(soldierType, soldierParams.Skip(1).ToArray(), privatesById);

            if (soldier != null)
            {
                soldiers.Add(soldier);
            }
        }

        soldiers.ForEach(Console.WriteLine);
    }
}