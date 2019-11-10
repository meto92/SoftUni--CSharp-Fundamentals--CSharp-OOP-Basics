using System;

public class Truck : Vehicle
{
    private const double RefuelingMultiplier = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionLnLitersPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionLnLitersPerKm, tankCapacity)
    { }

    public override void Refuel(double liters)
    {
        if (base.FuelQuantity + liters > base.TankCapacity)
        {
            throw new OverflowException(string.Format(Vehicle.TankOverflowMessage, liters));
        }

        base.Refuel(liters * RefuelingMultiplier);
    }
}