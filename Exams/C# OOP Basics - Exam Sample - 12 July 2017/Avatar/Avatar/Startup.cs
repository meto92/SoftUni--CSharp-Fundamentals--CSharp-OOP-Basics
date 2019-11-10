using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        NationsBuilder nationsBuilder = new NationsBuilder();

        while (true)
        {
            string[] command = Console.ReadLine().Split();

            Command commandType = (Command) Enum.Parse(typeof(Command), command[0]);
            List<string> commandArgs = command.Skip(1).ToList();
            string result = null;

            switch (commandType)
            {
                case Command.Bender:
                    nationsBuilder.AssignBender(commandArgs);
                    break;
                case Command.Monument:
                    nationsBuilder.AssignMonument(commandArgs);
                    break;
                case Command.Status:
                    result = nationsBuilder.GetStatus(commandArgs[0]);
                    break;
                case Command.War:
                    nationsBuilder.IssueWar(commandArgs[0]);
                    break;
                case Command.Quit:
                    result = nationsBuilder.GetWarsRecord();
                    break;
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }

            if (commandType == Command.Quit)
            {
                break;
            }
        }
    }
}