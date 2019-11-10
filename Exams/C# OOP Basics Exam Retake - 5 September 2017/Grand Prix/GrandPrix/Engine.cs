using System;
using System.Linq;

public class Engine
{
    public Engine()
    { }

    public void Run()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        RaceTower raceTower = new RaceTower();

        raceTower.SetTrackInfo(lapsNumber, trackLength);

        while (!raceTower.IsRaceOver)
        {
            string[] commandArgs = Console.ReadLine().Split();

            Command commandType = Enum.Parse<Command>(commandArgs[0]);

            string result = string.Empty;

            switch (commandType)
            {
                case Command.RegisterDriver:
                    raceTower.RegisterDriver(commandArgs.Skip(1).ToList());
                    break;
                case Command.Leaderboard:
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case Command.CompleteLaps:
                    try
                    {
                        result = raceTower.CompleteLaps(commandArgs.Skip(1).ToList());
                    }
                    catch (RaceException rex)
                    {
                        result = rex.Message;
                    }

                    break;
                case Command.Box:
                    raceTower.DriverBoxes(commandArgs.Skip(1).ToList());
                    break;
                case Command.ChangeWeather:
                    raceTower.ChangeWeather(commandArgs.Skip(1).ToList());
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }
}