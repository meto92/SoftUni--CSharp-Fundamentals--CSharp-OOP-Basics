using System;
using System.Collections.Generic;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    { }

    public override IEnumerable<string> GetWinnersInfo()
    {
        Func<ICar, int> performancePointsFunc = car => car.Horsepower / car.Acceleration;

        List<string> winners = base.GetWinners(performancePointsFunc);

        return winners;
    }
}