using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    static Engine GetEngine(string[] parameters)
    {
        Engine engine = null;

        string model = parameters[0];
        int power = int.Parse(parameters[1]);
        int displacement = -1;

        if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
        {
            engine = new Engine(model, power, displacement);
        }
        else if (parameters.Length == 3)
        {
            string efficiency = parameters[2];

            engine = new Engine(model, power, efficiency);
        }
        else if (parameters.Length == 4)
        {
            string efficiency = parameters[3];

            engine = new Engine(model, power, int.Parse(parameters[2]), efficiency);
        }
        else
        {
            engine = new Engine(model, power);
        }

        return engine;
    }

    private static Car GetCar(string[] parameters, List<Engine> engines)
    {
        Car car = null;

        string model = parameters[0];
        string engineModel = parameters[1];
        Engine engine = engines.FirstOrDefault(x => x.model == engineModel);

        int weight = -1;

        if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
        {
            car = new Car(model, engine, weight);
        }
        else if (parameters.Length == 3)
        {
            string color = parameters[2];

            car = new Car(model, engine, color);
        }
        else if (parameters.Length == 4)
        {
            string color = parameters[3];

            car = new Car(model, engine, int.Parse(parameters[2]), color);
        }
        else
        {
            car = new Car(model, engine);
        }

        return car;
    }

    public static void Main()
    {
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        int engineCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < engineCount; i++)
        {
            string[] parameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Engine engine = GetEngine(parameters);

            engines.Add(engine);
        }

        int carCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carCount; i++)
        {
            string[] parameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car car = GetCar(parameters, engines);

            cars.Add(car);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}