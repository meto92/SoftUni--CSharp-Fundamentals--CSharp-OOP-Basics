using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    protected static IReadOnlyDictionary<string, double> AirConditionerFuelConsumptionByVehicle = new Dictionary<string, double>()
    {
        ["Bus"] = 1.4,
        ["Car"] = 0.9,
        ["Truck"] = 1.6
    };

    protected const string TankOverflowMessage = "Cannot fit {0} fuel in the tank";
    private const string InvalidFuelMessage = "Fuel must be a positive number";
    private const string InsufficientFuelMessage = "{0} needs refueling";
    private const string DistanceTravveledMessage = "{0} travelled {1} km";

    protected double airConditionerFuelConsumption;
    private double fuelQuantity;
    private double fuelConsumptionLnLitersPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumptionLnLitersPerKm, double tankCapacity)
    {
        this.FuelConsumptionLnLitersPerKm = fuelConsumptionLnLitersPerKm;
        this.TankCapacity = tankCapacity;
        this.airConditionerFuelConsumption = AirConditionerFuelConsumptionByVehicle[this.GetType().Name];

        if (fuelQuantity > this.TankCapacity)
        {
            this.FuelQuantity = 0;
        }
        else
        {
            this.FuelQuantity = fuelQuantity;
        }
    }

    public double FuelQuantity
    {
        get => this.fuelQuantity;

        set
        {
            if (value > this.TankCapacity)
            {
                throw new OverflowException(string.Format(TankOverflowMessage, value - this.FuelQuantity));
            }

            this.fuelQuantity = value;
        }
    }

    public double FuelConsumptionLnLitersPerKm
    {
        get => this.fuelConsumptionLnLitersPerKm;
        set => this.fuelConsumptionLnLitersPerKm = value;
    }

    public double TankCapacity
    {
        get => this.tankCapacity;
        set => this.tankCapacity = value;
    }

    public virtual void DriveDistance(double distance, bool useAirConditioner = true)
    {
        double fuelConsumption = this.FuelConsumptionLnLitersPerKm;

        if (useAirConditioner)
        {
            fuelConsumption += this.airConditionerFuelConsumption;
        }

        double neededFuel = distance * fuelConsumption;

        if (neededFuel > this.FuelQuantity)
        {
            throw new Exception(string.Format(InsufficientFuelMessage, this.GetType().Name));
        }

        this.FuelQuantity -= neededFuel;

        Console.WriteLine(string.Format(DistanceTravveledMessage, this.GetType().Name, distance));
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException(InvalidFuelMessage);
        }

        this.FuelQuantity += liters;
    }
}