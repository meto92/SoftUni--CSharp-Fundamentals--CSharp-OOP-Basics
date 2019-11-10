public class AirMonument : Monument, IAirMonument
{
    public AirMonument(string name, int airAffinity) 
        : base(name, airAffinity)
    { }

    public int AirAffinity => base.Affinity;

    public override string ToString()
    {
        return string.Format(base.ToString(), this.AirAffinity);
    }
}