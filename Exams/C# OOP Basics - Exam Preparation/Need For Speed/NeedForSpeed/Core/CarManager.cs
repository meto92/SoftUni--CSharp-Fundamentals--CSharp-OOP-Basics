using System;
using System.Text;
using System.Collections.Generic;

public class CarManager
{
    private const string NoParticipantsMessage = "Cannot start the race with zero participants.";

    private IDictionary<int, ICar> carById;
    private IDictionary<int, IRace> raceById;
    private IGarage garage;

    public CarManager()
    {
        this.carById = new Dictionary<int, ICar>();
        this.raceById = new Dictionary<int, IRace>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        ICar car = CarFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

        this.carById[id] = car;
    }

	public string Check(int id)
    {
        return this.carById[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        IRace race = RaceFactory.CreateRace(type, length, route, prizePool);

        this.raceById[id] = race;
    }
	
    public void Participate(int carId, int raceId)
    {
        ICar car = this.carById[carId];

        if (this.garage.ParkedCars.Contains(car))
        {
            return;
        }

        IRace race = this.raceById[raceId];

        if (!race.IsOver)
        {
            race.Participants.Add(car);
        }
    }
	
    public string Start(int id)
    {
        IRace race = this.raceById[id];

        if (race.Participants.Count == 0)
        {
            return NoParticipantsMessage;
        }

        if (race.IsOver)
        {
            return string.Empty;
        }

        StringBuilder result = new StringBuilder();

        result.AppendLine($"{race.Route} - {race.Length}");
        result.Append(string.Join(Environment.NewLine, race.GetWinnersInfo()));

        return result.ToString();
    }

    private bool IsRacerCar(ICar car)
    {
        foreach (IRace race in this.raceById.Values)
        {
            if (race.Participants.Contains(car) && !race.IsOver)
            {
                return true;
            }
        }
        
        return false;
    }

	public void Park(int id)
    {
        ICar car = this.carById[id];

        bool isRacerCar = IsRacerCar(car);

        if (!isRacerCar)
        {
            this.garage.ParkedCars.Add(car);
        }
    }

	public void Unpark(int id)
    {
        ICar car = this.carById[id];

        this.garage.ParkedCars.Remove(car);
    }

	public void Tune(int tuneIndex, string addOn)
    {
        this.garage.TuneParkedCars(tuneIndex, addOn);
    }
}