using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    static Car GetCar(string[] parameters)
    {
        string model = parameters[0];

        int engineSpeed = int.Parse(parameters[1]);
        int enginePower = int.Parse(parameters[2]);

        int cargoWeight = int.Parse(parameters[3]);
        string cargoType = parameters[4];

        double tire1Pressure = double.Parse(parameters[5]);
        int tire1Age = int.Parse(parameters[6]);
        double tire2Pressure = double.Parse(parameters[7]);
        int tire2Age = int.Parse(parameters[8]);
        double tire3Pressure = double.Parse(parameters[9]);
        int tire3Age = int.Parse(parameters[10]);
        double tire4Pressure = double.Parse(parameters[11]);
        int tire4Age = int.Parse(parameters[12]);

        Engine engine = new Engine(engineSpeed, enginePower);
        Cargo cargo = new Cargo(cargoType, cargoWeight);
        Tire tire1 = new Tire(tire1Pressure, tire1Age);
        Tire tire2 = new Tire(tire2Pressure, tire2Age);
        Tire tire3 = new Tire(tire3Pressure, tire3Age);
        Tire tire4 = new Tire(tire4Pressure, tire4Age);

        return new Car(model, engine, cargo, tire1, tire2, tire3, tire4);
    }

    public static void Main()
    {
        List<Car> cars = new List<Car>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car car = GetCar(parameters);

            cars.Add(car);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            List<string> fragile = cars
                .Where(car => car.Cargo.Type == "fragile" && 
                    car.Tires.Any(tire => tire.Pressure < 1))
                .Select(car => car.Model)
                .ToList();

            fragile.ForEach(Console.WriteLine);
        }
        else
        {
            List<string> flamable = cars
                .Where(car => car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                .Select(car => car.Model)
                .ToList();

            flamable.ForEach(Console.WriteLine);
        }
    }
}