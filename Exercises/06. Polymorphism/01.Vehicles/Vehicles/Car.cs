public class Car : Vehicle
{
    private const double AdditionalFuelConsumptionInSummer = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionLnLitersPerKm) 
        : base(fuelQuantity, fuelConsumptionLnLitersPerKm + AdditionalFuelConsumptionInSummer)
    { }
}