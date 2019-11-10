using System;
using System.Collections.Generic;

public class Startup
{
    private static Dictionary<string, Engine> GetEnginesByModel()
    {
        int enginesCount = int.Parse(Console.ReadLine());

        Dictionary<string, Engine> enginesByModel = 
            new Dictionary<string, Engine>(enginesCount);

        for (int i = 0; i < enginesCount; i++)
        {
            string[] engineParams = Console.ReadLine().Split();

            string model = engineParams[0];
            int power = int.Parse(engineParams[1]);
            int? displacement = null;
            string efficiency = null;

            if (engineParams.Length == 3)
            {
                if (int.TryParse(engineParams[2], out int displ))
                {
                    displacement = displ;
                }
                else
                {
                    efficiency = engineParams[2];
                }
            }
            else if (engineParams.Length == 4)
            {
                displacement = int.Parse(engineParams[2]);
                efficiency = engineParams[3];
            }

            Engine engine = new Engine(model, power, displacement, efficiency);

            enginesByModel[model] = engine;
        }

        return enginesByModel;
    }

    private static List<Car> GetCars(Dictionary<string, Engine> enginesByModel)
    {
        int carsCount = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] carParams = Console.ReadLine().Split();

            string model = carParams[0];
            Engine engine = enginesByModel[carParams[1]];
            int? weight = null;
            string color = null;

            if (carParams.Length == 3)
            {
                if (int.TryParse(carParams[2], out int carWeight))
                {
                    weight = carWeight;
                }
                else
                {
                    color = carParams[2];
                }
            }
            else if (carParams.Length == 4)
            {
                weight = int.Parse(carParams[2]);
                color = carParams[3];
            }

            Car car = new Car(model, engine, weight, color);

            cars.Add(car);
        }

        return cars;
    }

    public static void Main()
    {
        Dictionary<string, Engine> enginesByModel = GetEnginesByModel();
        List<Car> cars = GetCars(enginesByModel);

        cars.ForEach(Console.WriteLine);
    }
}