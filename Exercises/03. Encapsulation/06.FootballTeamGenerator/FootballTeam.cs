using System;
using System.Linq;
using System.Collections.Generic;

public class FootballTeam
{
    private string name;
    private Dictionary<string, FootballPlayer> players;

    public FootballTeam(string name)
    {
        this.Name = name;
        this.players = new Dictionary<string, FootballPlayer>();
    }

    public string Name
    {
        get => name;
        private set => this.name = Utility.ValidateName(value);
    }

    public int Rating => this.GetRating();

    private int GetRating()
    {
        return
            this.players.Count == 0
            ? 0
            : (int)Math.Round(this.players.Values.Average(footballPlayer => footballPlayer.AverageSkillLevel));
    }

    public void AddPlayer(FootballPlayer player)
    {
        this.players[player.Name] = player;
    }

    public void RemovePlayer(string playerName)
    {
        if (!this.players.ContainsKey(playerName))
        {
            throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
        }

        this.players.Remove(playerName);
    }
}