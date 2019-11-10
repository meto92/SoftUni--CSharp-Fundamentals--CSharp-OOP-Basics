public class AirBender : Bender, IAirBender
{
    public AirBender(string name, int power, double aerialIntegrity) 
        : base(name, power, aerialIntegrity)
    { }

    public double AerialIntegrity => base.SecondaryParameter;

    public override string ToString()
    {
        return string.Format(base.ToString(), "Aerial Integrity");
    }
}