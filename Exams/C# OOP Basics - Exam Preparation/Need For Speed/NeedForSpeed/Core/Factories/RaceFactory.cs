using System;
using System.Linq;
using System.Reflection;

public static class RaceFactory
{
    private const string RaceSuffix = nameof(Race);

    public static IRace CreateRace(string type, int length, string route, int prizePool)
    {
        Type raceType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.IsClass && t.Name == type + nameof(Race));

        if (raceType == null)
        {
            throw new NotSupportedException($"Unknown race type {type}");
        }

        IRace race = (IRace) Activator.CreateInstance(raceType, length, route, prizePool);

        return race;
    }
}