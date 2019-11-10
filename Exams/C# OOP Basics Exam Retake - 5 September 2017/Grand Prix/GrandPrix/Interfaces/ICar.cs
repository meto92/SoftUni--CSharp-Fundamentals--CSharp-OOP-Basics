public interface ICar
{
    int Hp { get; }

    double FuelAmount { get; }

    Tyre Tyre { get; }

    void ChangeTyres(Tyre newTyres);

    void Refuel(double fuelAmount);

    void ReduceFuel(double fuelAmount);
}