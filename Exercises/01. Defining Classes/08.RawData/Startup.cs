using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static Car GetCar(string[] carParams)
    {
        string model = carParams[0];

        int engineSpeed = int.Parse(carParams[1]);
        int enginePower = int.Parse(carParams[2]);

        int cargoWeight = int.Parse(carParams[3]);
        string cargoType = carParams[4];

        double tire1Pressure = double.Parse(carParams[5]);
        int tire1Age = int.Parse(carParams[6]);
        double tire2Pressure = double.Parse(carParams[7]);
        int tire2Age = int.Parse(carParams[8]);
        double tire3Pressure = double.Parse(carParams[9]);
        int tire3Age = int.Parse(carParams[10]);
        double tire4Pressure = double.Parse(carParams[11]);
        int tire4Age = int.Parse(carParams[12]);

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
        int carsCount = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] carParams = Console.ReadLine().Split();

            Car car = GetCar(carParams);

            cars.Add(car);
        }

        string command = Console.ReadLine();

        Predicate<Car> predicate = null;

        if (command == "fragile")
        {
            predicate = car => car.Cargo.Type == command &&
                car.Tires.Any(tire => tire.Pressure < 1);
        }
        else if (command == "flamable")
        {
            predicate = car => car.Cargo.Type == command &&
                car.Engine.Power > 250;
        }

        cars.Where(car => predicate(car))
            .ToList()
            .ForEach(car => Console.WriteLine(car.Model));
    }
}