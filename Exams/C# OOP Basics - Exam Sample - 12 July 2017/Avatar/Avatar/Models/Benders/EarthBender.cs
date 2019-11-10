public class EarthBender : Bender, IEarthBender
{
    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power, groundSaturation)
    { }

    public double GroundSaturation => base.SecondaryParameter;

    public override string ToString()
    {
        return string.Format(base.ToString(), "Ground Saturation");
    }
}