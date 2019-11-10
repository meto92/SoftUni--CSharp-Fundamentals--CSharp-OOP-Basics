using System;
using System.Collections.Generic;

public class Startup
{
    private static Dictionary<string, Car> GetCarsByModel()
    {
        Dictionary<string, Car> carsByModel = new Dictionary<string, Car>();

        int carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            string[] carParams = Console.ReadLine().Split();

            string model = carParams[0];
            double fuelAmount = double.Parse(carParams[1]);
            double fuelConsumptionFor1km = double.Parse(carParams[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

            carsByModel[model] = car;
        }

        return carsByModel;
    }

    private static void ReadAndProcessCommands(Dictionary<string, Car> carsByModel)
    {
        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();

            string model = tokens[1];
            int kmAmount = int.Parse(tokens[2]);

            Car car = carsByModel[model];

            if (car.CanTravelDistance(kmAmount))
            {
                car.FuelAmount -= car.FuelConsumptionForOneKilometer * kmAmount;
                car.TraveledDistance += kmAmount;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    public static void Main()
    {
        Dictionary<string, Car> carsByModel = GetCarsByModel();

        ReadAndProcessCommands(carsByModel);

        Console.WriteLine(string.Join(Environment.NewLine, carsByModel.Values));
    }
}