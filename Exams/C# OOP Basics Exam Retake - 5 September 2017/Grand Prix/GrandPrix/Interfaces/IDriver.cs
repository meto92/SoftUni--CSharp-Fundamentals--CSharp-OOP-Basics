public interface IDriver : INameable
{
    double TotalTime { get; }

    Car Car { get; }

    double FuelConsumptionPerKm { get; }

    double Speed { get; }

    void CompleteLap(int trackLength);

    void AddTime(double timeDifferenceToNext);
}