using System;

public class Engine
{
    private const string EndCommand = "Cops Are Here";

    private CarManager carManager;
    private IInputReader inputReader;
    public IOutputWriter outputWriter;

    public Engine()
    {
        this.carManager = new CarManager();
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
    }

    public void Run()
    {
        while (true)
        {
            string command = this.inputReader.ReadLine();

            if (command == EndCommand)
            {
                break;
            }

            string[] commandArgs = command.Split();

            Command commandType = (Command) Enum.Parse(typeof(Command), commandArgs[0], true);

            string result = string.Empty;
            string type = string.Empty;
            int carId = 0,
                raceId = 0;

            switch (commandType)
            {
                case Command.Register:
                    carId = int.Parse(commandArgs[1]);
                    type = commandArgs[2];
                    string brand = commandArgs[3];
                    string model = commandArgs[4];
                    int year = int.Parse(commandArgs[5]);
                    int horsepower = int.Parse(commandArgs[6]);
                    int acceleration = int.Parse(commandArgs[7]);
                    int suspension = int.Parse(commandArgs[8]);
                    int durability = int.Parse(commandArgs[9]);

                    this.carManager.Register(carId, type, brand, model, year, horsepower, acceleration, suspension, durability);
                    break;
                case Command.Check:
                    carId = int.Parse(commandArgs[1]);

                    result = this.carManager.Check(carId);
                    break;
                case Command.Open:
                    raceId = int.Parse(commandArgs[1]);
                    type = commandArgs[2];
                    int length = int.Parse(commandArgs[3]);
                    string route = commandArgs[4];
                    int prizePool = int.Parse(commandArgs[5]);

                    this.carManager.Open(raceId, type, length, route, prizePool);
                    break;
                case Command.Participate:
                    carId = int.Parse(commandArgs[1]);
                    raceId = int.Parse(commandArgs[2]);

                    this.carManager.Participate(carId, raceId);
                    break;
                case Command.Start:
                    raceId = int.Parse(commandArgs[1]);

                    result = this.carManager.Start(raceId);
                    break;
                case Command.Park:
                    carId = int.Parse(commandArgs[1]);

                    this.carManager.Park(carId);
                    break;
                case Command.Unpark:
                    carId = int.Parse(commandArgs[1]);

                    this.carManager.Unpark(carId);
                    break;
                case Command.Tune:
                    int tuneIndex = int.Parse(commandArgs[1]);
                    string tuneAddOn = commandArgs[2];

                    this.carManager.Tune(tuneIndex, tuneAddOn);
                    break;
            }

            if (result != string.Empty)
            {
                this.outputWriter.WriteLine(result);
            }
        }
    }
}