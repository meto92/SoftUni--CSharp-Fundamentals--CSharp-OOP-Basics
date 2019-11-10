using System;
using System.Collections.Generic;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    { }

    public override IEnumerable<string> GetWinnersInfo()
    {
        Func<ICar, int> performancePointsFunc = car => car.Suspension + car.Durability;

        List<string> winners = base.GetWinners(performancePointsFunc);

        return winners;
    }
}