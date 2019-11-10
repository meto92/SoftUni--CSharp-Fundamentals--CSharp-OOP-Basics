public class AggressiveDriver : Driver
{
    private const double AggressiveDriverFuelConsumptionPerKm = 2.7;
    private const double SpeedMultiplier = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, AggressiveDriverFuelConsumptionPerKm)
    { }

    public override double Speed => base.Speed * SpeedMultiplier;
}