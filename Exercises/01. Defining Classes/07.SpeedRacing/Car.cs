public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionForOneKilometer;
    private int traveledDistance;

    public Car(string model, double fuelAmount, double fuelConsumptionForOneKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionForOneKilometer = fuelConsumptionForOneKilometer;
        this.TraveledDistance = 0;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public double FuelAmount
    {
        get => fuelAmount;
        set => fuelAmount = value;
    }

    public double FuelConsumptionForOneKilometer
    {
        get => fuelConsumptionForOneKilometer;
        set => fuelConsumptionForOneKilometer = value;
    }

    public int TraveledDistance
    {
        get => traveledDistance;
        set => traveledDistance = value;
    }

    public bool CanTravelDistance(double kmAmount)
    {
        double requiredFuel = this.FuelConsumptionForOneKilometer * kmAmount;

        return this.fuelAmount - requiredFuel >= 0;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:f2} {this.TraveledDistance}";
    }
}