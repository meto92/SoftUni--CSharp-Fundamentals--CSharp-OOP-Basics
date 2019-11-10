using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Race : IRace
{
    private int length;
    private string route;
    private int prizePool;
    private List<ICar> participants;
    private bool isOver;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new List<ICar>();
        this.isOver = false;
    }

    public int Length
    {
        get => this.length;
        set => this.length = value;
    }

    public string Route
    {
        get => this.route;
        set => this.route = value;
    }

    public int PrizePool
    {
        get => this.prizePool;
        set => this.prizePool = value;
    }

    public ICollection<ICar> Participants => this.participants;

    public bool IsOver => this.isOver;

    public abstract IEnumerable<string> GetWinnersInfo();

    private int GetMoneyWon(int position)
    {
        int money = 0;

        switch (position)
        {
            case 1:
                money = (this.PrizePool * 50) / 100;
                break;
            case 2:
                money = (this.PrizePool * 30) / 100;
                break;
            case 3:
                money = (this.PrizePool * 20) / 100;
                break;
        }

        return money;
    }

    protected List<string> GetWinners(Func<ICar, int> performancePointsFunc)
    {
        List<string> winners = this.Participants
            .ToDictionary(car => car, car => performancePointsFunc(car))
            .OrderByDescending(pair => pair.Value)
            .Take(3)
            .Select(pair => $"{pair.Key.Brand} {pair.Key.Model} {pair.Value}PP")
            .ToList();

        for (int i = 0; i < winners.Count; i++)
        {
            int moneyWon = GetMoneyWon(i + 1);

            winners[i] = $"{i + 1}. {winners[i]} - ${moneyWon}";
        }

        this.isOver = true;

        return winners;
    }
}