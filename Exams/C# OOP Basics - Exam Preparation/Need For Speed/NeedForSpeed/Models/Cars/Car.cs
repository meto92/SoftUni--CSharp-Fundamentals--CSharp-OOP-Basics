using System.Text;

public abstract class Car : ICar
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(
        string brand,
        string model, 
        int yearOfProduction,
        int horsepower, 
        int acceleration, 
        int suspension, 
        int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand
    {
        get => this.brand;
        set => this.brand = value;
    }

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public int YearOfProduction
    {
        get => this.yearOfProduction;
        set => this.yearOfProduction = value;
    }

    public int Horsepower
    {
        get => this.horsepower;
        set => this.horsepower = value;
    }

    public int Acceleration
    {
        get => this.acceleration;
        set => this.acceleration = value;
    }

    public int Suspension
    {
        get => this.suspension;
        set => this.suspension = value;
    }

    public int Durability
    {
        get => this.durability;
        set => this.durability = value;
    }

    public virtual void Tune(int tuneIndex, string tuneAddon)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        result.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        result.Append($"{this.suspension} Suspension force, {this.Durability} Durability");

        return result.ToString();
    }
}