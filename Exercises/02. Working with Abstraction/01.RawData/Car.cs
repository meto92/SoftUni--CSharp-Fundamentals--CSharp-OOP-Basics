public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;

        this.Tires = new Tire[4];
        this.Tires[0] = tire1;
        this.Tires[1] = tire2;
        this.Tires[2] = tire3;
        this.Tires[3] = tire4;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public Engine Engine
    {
        get => engine;
        set => engine = value;
    }

    public Cargo Cargo
    {
        get => cargo;
        set => cargo = value;
    }

    public Tire[] Tires
    {
        get => tires;
        set => tires = value;
    }
}