using System;

public class Startup
{
    private static Vehicle GetVehicle(string[] vehicleParams)
    {
        double fuelQuantity = double.Parse(vehicleParams[1]);
        double fuelConsumptionLnLitersPerKm = double.Parse(vehicleParams[2]);

        Vehicle vehicle = null;

        if (vehicleParams[0] == "Car")
        {
            vehicle = new Car(fuelQuantity, fuelConsumptionLnLitersPerKm);
        }
        else
        {
            vehicle = new Truck(fuelQuantity, fuelConsumptionLnLitersPerKm);
        }

        return vehicle;
    }

    private static Action<Vehicle, double> GetAction(string[] commandParams)
    {
        Action<Vehicle, double> action = null;

        if (commandParams[0] == "Drive")
        {
            action = (vehicle, distance) =>
            {
                vehicle.DriveDistance(distance);
            };
        }
        else
        {
            action = (vehicle, liters) =>
            {
                vehicle.Refuel(liters);
            };
        }

        return action;
    }

    public static void Main()
    {
        string[] carParams = Console.ReadLine().Split();
        string[] truckParams = Console.ReadLine().Split();
        int commandsCount = int.Parse(Console.ReadLine());

        Vehicle car = GetVehicle(carParams);
        Vehicle truck = GetVehicle(truckParams);

        for (int i = 0; i < commandsCount; i++)
        {
            string[] commandParams = Console.ReadLine().Split();

            double parameter = double.Parse(commandParams[2]);

            Action<Vehicle, double> action = GetAction(commandParams);

            if (commandParams[1] == "Car")
            {
                action(car, parameter);
            }
            else
            {
                action(truck, parameter);
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }
}