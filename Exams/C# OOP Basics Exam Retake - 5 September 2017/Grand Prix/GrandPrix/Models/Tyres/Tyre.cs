public abstract class Tyre : ITyre
{
    private const double InitialDegradation = 100;

    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = InitialDegradation;
    }

    public string Name
    {
        get
        {
            string type = this.GetType().Name;

            return type.Substring(0, type.Length - nameof(Tyre).Length);
        }
    }

    public double Hardness
    {
        get => this.hardness;
        protected set => this.hardness = value;
    }

    public double Degradation
    {
        get => this.degradation;

        protected set
        {
            this.degradation = value;

            if (value < this.DegradationLowerBound)
            {
                throw new BlownTyreException();
            }
        }
    }

    public virtual double DegradationLowerBound => 0;

    public virtual void Degradate()
    {
        this.Degradation -= this.Hardness;
    }
}