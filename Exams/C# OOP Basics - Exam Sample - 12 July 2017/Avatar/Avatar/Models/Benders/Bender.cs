public abstract class Bender : Nameable, IBender
{
    private int power;
    private double secondaryParameter;

    protected Bender(string name, int power, double secondaryParameter) 
        : base(name)
    {
        this.Power = power;
        this.SecondaryParameter = secondaryParameter;
    }

    public int Power
    {
        get => this.power;
        protected set => this.power = value;
    }

    public double SecondaryParameter
    {
        get => this.secondaryParameter;
        protected set => this.secondaryParameter = value;
    }

    public override string ToString()
    {
        string type = this.GetType().Name;

        string result = string.Format("{0} Bender: {1}, Power: {2}, {3}: {4}",
            type.Substring(0, type.Length - nameof(Bender).Length),
            base.Name,
            this.Power,
            "{0}",
            $"{this.SecondaryParameter:f2}");

        return result;
    }
}