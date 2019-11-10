using System.Collections.Generic;

public interface IRace
{
    int Length
    {
        get;
    }

    string Route
    {
        get;
    }

    int PrizePool
    {
        get;
    }

    ICollection<ICar> Participants
    {
        get;
    }

    bool IsOver
    {
        get;
    }

    IEnumerable<string> GetWinnersInfo();
}