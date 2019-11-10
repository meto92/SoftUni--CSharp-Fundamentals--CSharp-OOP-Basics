using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static IIdentifiable GetIdentifiable(string[] identifiableParams)
    {
        IIdentifiable identifiable = null;

        if (identifiableParams.Length == 2)
        {
            string robotModel = identifiableParams[0];
            string robotId = identifiableParams[1];

            identifiable = new Robot(robotModel, robotId);
        }
        else
        {
            string citizenName = identifiableParams[0];
            int citizenAge = int.Parse(identifiableParams[1]);
            string citizenId = identifiableParams[2];

            identifiable = new Citizen(citizenName, citizenAge, citizenId);
        }

        return identifiable;
    }

    public static void Main()
    {
        List<IIdentifiable> identifiablesTriedToEnterTheCity = new List<IIdentifiable>();

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] identifiableParams = input.Split();

            IIdentifiable identifiable = GetIdentifiable(identifiableParams);            

            identifiablesTriedToEnterTheCity.Add(identifiable);
        }

        string fakeIdLastDigits = Console.ReadLine();

        identifiablesTriedToEnterTheCity.Where(identifiable => identifiable.Id.EndsWith(fakeIdLastDigits))
            .ToList()
            .ForEach(Console.WriteLine);
    }
}