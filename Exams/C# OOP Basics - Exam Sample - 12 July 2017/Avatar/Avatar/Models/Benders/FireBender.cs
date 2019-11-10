public class FireBender : Bender, IFireBender
{
    public FireBender(string name, int power, double heatAggression)
        : base(name, power, heatAggression)
    { }

    public double HeatAggression => base.SecondaryParameter;

    public override string ToString()
    {
        return string.Format(base.ToString(), "Heat Aggression");
    }
}