public class Truck : Vehicle
{
    private const double AdditionalFuelConsumptionInSummer = 1.6;

    public Truck(double fuelQuantity, double fuelConsumptionLnLitersPerKm) 
        : base(fuelQuantity, fuelConsumptionLnLitersPerKm + AdditionalFuelConsumptionInSummer)
    { }

    public override void Refuel(double liters)
    {
        base.Refuel(liters * 0.95);
    }
}