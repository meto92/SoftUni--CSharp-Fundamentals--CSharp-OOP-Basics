using System;

public class Startup
{
    private static Vehicle GetVehicle(string[] vehicleParams)
    {
        double fuelQuantity = double.Parse(vehicleParams[1]);
        double fuelConsumptionInLitersPerKm = double.Parse(vehicleParams[2]);
        double tankCapacity = double.Parse(vehicleParams[3]);

        Vehicle vehicle = null;

        switch (vehicleParams[0])
        {
            case "Car":
                vehicle = new Car(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity);
                break;
            case "Truck":
                vehicle = new Truck(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity);
                break;
            case "Bus":
                vehicle = new Bus(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity);
                break;
        }

        return vehicle;
    }

    private static Action<Vehicle, double> GetAction(string[] commandParams)
    {
        Action<Vehicle, double> action = null;

        switch (commandParams[0])
        {
            case "Drive":
                action = (vehicle, distance) =>
                {
                    vehicle.DriveDistance(distance);
                };

                break;
            case "DriveEmpty":
                action = (vehicle, distance) =>
                {
                    vehicle.DriveDistance(distance, false);
                };

                break;
            case "Refuel":
                action = (vehicle, liters) =>
                {
                    vehicle.Refuel(liters);
                };

                break;
        }

        return action;
    }

    private static Vehicle GetVehicle(string vehicleTypeStr, Vehicle car, Vehicle truck, Vehicle bus)
    {
        Vehicle vehicle = null;

        switch (vehicleTypeStr)
        {
            case "Car":
                vehicle = car;
                break;
            case "Truck":
                vehicle = truck;
                break;
            case "Bus":
                vehicle = bus;
                break;
        }

        return vehicle;
    }

    public static void Main()
    {
        string[] carParams = Console.ReadLine().Split();
        string[] truckParams = Console.ReadLine().Split();
        string[] busParams = Console.ReadLine().Split();
        int commandsCount = int.Parse(Console.ReadLine());
        
        Vehicle car = GetVehicle(carParams);
        Vehicle truck = GetVehicle(truckParams);
        Vehicle bus = GetVehicle(busParams);

        for (int i = 0; i < commandsCount; i++)
        {
            string[] commandParams = Console.ReadLine().Split();

            double parameter = double.Parse(commandParams[2]);

            Action<Vehicle, double> action = GetAction(commandParams);
            Vehicle vehicle = GetVehicle(commandParams[1], car, truck, bus);

            try
            {
                action(vehicle, parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }
}