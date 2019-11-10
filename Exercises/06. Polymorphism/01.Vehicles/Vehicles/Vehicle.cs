using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionLnLitersPerKm;

    public Vehicle(double fuelQuantity, double fuelConsumptionLnLitersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionLnLitersPerKm = fuelConsumptionLnLitersPerKm;
    }

    public double FuelQuantity
    {
        get => this.fuelQuantity;
        set => this.fuelQuantity = value;
    }

    public double FuelConsumptionLnLitersPerKm
    {
        get => this.fuelConsumptionLnLitersPerKm ;
        set => this.fuelConsumptionLnLitersPerKm  = value;
    }

    public virtual void DriveDistance(double distance)
    {
        double neededFuel = distance * this.FuelConsumptionLnLitersPerKm;

        if (neededFuel <= this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuel;

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }
}