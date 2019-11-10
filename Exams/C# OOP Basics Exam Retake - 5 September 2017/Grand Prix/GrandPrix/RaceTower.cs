using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class RaceTower
{
    private const int TimeInBox = 20;
    private const string InvalidLapsCountMessage = "There is no time! On lap {0}.";
    private const string LapMessage = "Lap {0}/{1}";
    private const string DriverInfo = "{0} {1} {2}";
    private const string OvertakeMessage = "{0} has overtaken {1} on lap {2}.";
    private const string WinnerMessage = "{0} wins the race for {1:f3} seconds.";
    private const string Refuel = nameof(Refuel);
    private const string Crashed = nameof(Crashed);
    private const string ChangeTyres = nameof(ChangeTyres);

    private int lapsNumber;
    private int trackLength;
    private int currentLapNumber;
    private Weather weather;
    private Dictionary<string, IDriver> racingDriverByName;
    private IDictionary<IDriver, string> failureReasonByDriver;
    private TyreFactory tyreFactory;
    private DriverFactory driverFactory;

    public RaceTower()
    {
        this.currentLapNumber = 0;
        this.weather = Weather.Sunny;
        this.racingDriverByName = new Dictionary<string, IDriver>();
        this.failureReasonByDriver = new Dictionary<IDriver, string>();
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
    }

    public bool IsRaceOver => this.currentLapNumber == this.lapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            IDriver driver = this.driverFactory.CreateDriver(commandArgs);

            this.racingDriverByName[driver.Name] = driver;
        }
        catch { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];

        IDriver driver = this.racingDriverByName[driverName];

        switch (reasonToBox)
        {
            case ChangeTyres:
                Tyre tyre = this.tyreFactory.CreateTyre(commandArgs.Skip(2).ToArray());

                driver.Car.ChangeTyres(tyre);
                break;
            case Refuel:
                double fuelAmount = double.Parse(commandArgs[2]);

                driver.Car.Refuel(fuelAmount);
                break;
        }

        driver.AddTime(TimeInBox);
    }

    private void CompleteLap()
    {
        List<IDriver> failedDriversOnCurrentLap = new List<IDriver>();

        foreach (IDriver driver in this.racingDriverByName.Values)
        {
            try
            {
                driver.CompleteLap(this.trackLength);
            }
            catch (RaceException rex)
            {
                failedDriversOnCurrentLap.Add(driver);
                this.failureReasonByDriver[driver] = rex.Message;
            }
        }

        this.currentLapNumber++;
        failedDriversOnCurrentLap
            .ForEach(driver => this.racingDriverByName.Remove(driver.Name));
    }

    private void Overtake(StringBuilder result)
    {
        List<IDriver> drivers = this.racingDriverByName
            .Values
            .OrderByDescending(driver => driver.TotalTime)
            .ToList();

        for (int i = 0; i < drivers.Count - 1; i++)
        {
            IDriver driver = drivers[i];
            IDriver driverAhead = drivers[i + 1];

            double timeDifference = driver.TotalTime - driverAhead.TotalTime;

            if (timeDifference > 3)
            {
                continue;
            }

            bool isAggressiveDriverOnUltrasoftTyre =
                driver.GetType() == typeof(AggressiveDriver) &&
                driver.Car.Tyre.GetType() == typeof(UltrasoftTyre);
            bool isEnduranceDriverOnHardTyre =
                driver.GetType() == typeof(EnduranceDriver) &&
                driver.Car.Tyre.GetType() == typeof(HardTyre);

            bool isCrashedAggressiveDriver =
                isAggressiveDriverOnUltrasoftTyre &&
                this.weather == Weather.Foggy;
            bool isCrashedEnduranceDriver =
                isEnduranceDriverOnHardTyre &&
                this.weather == Weather.Rainy;

            bool isAggressiveDriverOnUltrasoftTyreOrEnduranceDriverOnHardTyre =
                isAggressiveDriverOnUltrasoftTyre || isEnduranceDriverOnHardTyre;

            if (isCrashedAggressiveDriver || isCrashedEnduranceDriver)
            {
                this.failureReasonByDriver[driver] = Crashed;
                this.racingDriverByName.Remove(driver.Name);
            }
            else if (isAggressiveDriverOnUltrasoftTyreOrEnduranceDriverOnHardTyre ||
                timeDifference <= 2)
            {
                int interval = isAggressiveDriverOnUltrasoftTyreOrEnduranceDriverOnHardTyre ? 3 : 2;

                driver.AddTime(-interval);
                driverAhead.AddTime(interval);

                result.AppendLine(string.Format(
                    OvertakeMessage,
                    driver.Name,
                    driverAhead.Name,
                    this.currentLapNumber));

                i++;
            }
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int lapsToComplete = int.Parse(commandArgs[0]);

        if (this.currentLapNumber + lapsToComplete > this.lapsNumber)
        {
            string errorMessage = string.Format(InvalidLapsCountMessage, this.currentLapNumber);

            //throw new RaceException(errorMessage);
            return errorMessage;
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < lapsToComplete; i++)
        {
            this.CompleteLap();
            this.Overtake(result);
        }

        if (this.IsRaceOver)
        {
            IDriver winner = this.racingDriverByName
                .Values
                .OrderBy(driver => driver.TotalTime)
                .First();

            result.AppendFormat(WinnerMessage, winner.Name, winner.TotalTime);
        }

        return result.ToString().TrimEnd();
    }

    private string FormatDriverInfo(int position, string name, string parameter)
    {
        return string.Format(DriverInfo, position, name, parameter);
    }

    private void AppendRacingDriversInfo(StringBuilder result)
    {
        List<IDriver> drivers = this.racingDriverByName.Values
            .OrderBy(driver => driver.TotalTime)
            .ToList();

        for (int i = 0; i < drivers.Count; i++)
        {
            IDriver driver = drivers[i];

            result.AppendLine(this.FormatDriverInfo(
                i + 1,
                driver.Name,
                $"{driver.TotalTime:f3}"));
        }
    }

    private void AppendFailedDriversInfo(StringBuilder result)
    {
        int racingDriversCount = this.racingDriverByName.Count;

        this.failureReasonByDriver.Keys
            .Reverse()
            .Select((driver, index) => this.FormatDriverInfo(
                racingDriversCount + index + 1,
                driver.Name,
                this.failureReasonByDriver[driver]))
            .ToList()
            .ForEach(str => result.AppendLine(str));
    }

    public string GetLeaderboard()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(string.Format(
            LapMessage,
            this.currentLapNumber,
            this.lapsNumber));

        this.AppendRacingDriversInfo(result);
        this.AppendFailedDriversInfo(result);

        return result.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        Enum.TryParse(commandArgs[0], true, out this.weather);
    }
}