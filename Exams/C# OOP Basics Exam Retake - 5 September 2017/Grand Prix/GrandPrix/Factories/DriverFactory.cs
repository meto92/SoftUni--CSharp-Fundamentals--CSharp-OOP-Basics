using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

public class DriverFactory
{
    private const string DriverSuffix = "Driver";

    private TyreFactory tyreFactory;

    public DriverFactory()
    {
        this.tyreFactory = new TyreFactory();
    }

    public Driver CreateDriver(List<string> driverArgs )
    {
        string type = driverArgs[0];
        string name = driverArgs[1];
        int hp = int.Parse(driverArgs[2]);
        double fuelAmount = double.Parse(driverArgs[3]);

        Type driverType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.IsClass && t.Name == type + DriverSuffix);

        if (driverType == null)
        {
            throw new ArgumentNullException("driverType", "Unknown driver type");
        }

        Tyre tyre = this.tyreFactory.CreateTyre(driverArgs.Skip(4).ToArray());
        
        Car car = new Car(hp, fuelAmount, tyre);

        Driver driver = (Driver) Activator.CreateInstance(driverType, name, car);

        return driver;
    }
}