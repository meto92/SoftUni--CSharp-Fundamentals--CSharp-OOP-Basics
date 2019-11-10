using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static void AddPlayer(Dictionary<string, FootballTeam> footballTeamsByName, string teamName, string[] playerParams)
    {
        if (!footballTeamsByName.ContainsKey(teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        string playerName = playerParams[0];
        int endurance = int.Parse(playerParams[1]);
        int sprint = int.Parse(playerParams[2]);
        int drible = int.Parse(playerParams[3]);
        int passing = int.Parse(playerParams[4]);
        int shooting = int.Parse(playerParams[5]);

        try
        {
            FootballPlayer player = new FootballPlayer(playerName, endurance, sprint, drible, passing, shooting);

            footballTeamsByName[teamName].AddPlayer(player);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void RemovePlayer(Dictionary<string, FootballTeam> footballTeamsByName, string teamName, string playerName)
    {
        if (!footballTeamsByName.ContainsKey(teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        try
        {
            footballTeamsByName[teamName].RemovePlayer(playerName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintTeamRating(Dictionary<string, FootballTeam> footballTeamsByName, string teamName)
    {
        if (!footballTeamsByName.ContainsKey(teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
        }
        else
        {
            Console.WriteLine($"{teamName} - {footballTeamsByName[teamName].Rating}");
        }
    }

    public static void Main()
    {
        Dictionary<string, FootballTeam> footballTeamsByName =
            new Dictionary<string, FootballTeam>();
        
        string input = null;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputParams = input.Split(';');

            string command = inputParams[0];
            string teamName = inputParams[1];

            switch (command)
            {
                case "Team":
                    footballTeamsByName[teamName] = new FootballTeam(teamName);
                    break;
                case "Add":
                    AddPlayer(footballTeamsByName, teamName, inputParams.Skip(2).ToArray());
                    break;
                case "Remove":
                    string playerName = inputParams[2];
                    RemovePlayer(footballTeamsByName, teamName, playerName);
                    break;
                case "Rating":
                    PrintTeamRating(footballTeamsByName, teamName);
                    break;
            }
        }
    }
}