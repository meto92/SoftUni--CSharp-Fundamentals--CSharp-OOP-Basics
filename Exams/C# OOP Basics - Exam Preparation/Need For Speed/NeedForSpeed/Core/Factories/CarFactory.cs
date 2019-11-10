using System;
using System.Linq;
using System.Reflection;

public static class CarFactory
{
    private const string CarSuffix = "Car";

    public static ICar CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Type carType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.IsClass && t.Name == type + CarSuffix);

        if (carType == null)
        {
            throw new ArgumentNullException(nameof(carType), "Unknown car type");
        }

        ICar car = (ICar) Activator.CreateInstance(carType, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

        return car;
    }
}