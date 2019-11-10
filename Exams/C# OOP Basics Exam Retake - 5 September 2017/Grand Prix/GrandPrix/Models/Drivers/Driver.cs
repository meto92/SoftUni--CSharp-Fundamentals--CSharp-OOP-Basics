public abstract class Driver : IDriver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }

    public double TotalTime
    {
        get => this.totalTime;
        protected set => this.totalTime = value;
    }

    public Car Car
    {
        get => this.car;
        protected set => this.car = value;
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        private set => this.fuelConsumptionPerKm = value;
    }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void CompleteLap(int trackLength)
    {
        this.AddTime(60 / (trackLength / this.Speed));
        this.Car.ReduceFuel(trackLength * this.FuelConsumptionPerKm);
        this.Car.Tyre.Degradate();
    }

    public void AddTime(double time)
    {
        this.TotalTime += time;
    }
}