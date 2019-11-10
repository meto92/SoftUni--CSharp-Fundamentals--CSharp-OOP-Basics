public abstract class Cat
{
    private string name;
    private double parameter;

    public Cat(string name, double parameter)
    {
        this.Name = name;
        this.Parameter = parameter;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public double Parameter
    {
        get => parameter;
        set => parameter = value;
    }

    public override string ToString()
    {
        return $"{this.GetType()} {this.Name} {this.Parameter}";
    }
}