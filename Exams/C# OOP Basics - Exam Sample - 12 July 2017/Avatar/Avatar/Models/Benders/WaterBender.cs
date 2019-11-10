public class WaterBender : Bender, IWaterBender
{
    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power, waterClarity)
    { }

    public double WaterClarity => base.SecondaryParameter;

    public override string ToString()
    {
        return string.Format(base.ToString(), "Water Clarity");
    }
}