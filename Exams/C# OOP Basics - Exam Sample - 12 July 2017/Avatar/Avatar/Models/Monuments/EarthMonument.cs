public class EarthMonument : Monument, IEarthMonument
{
    public EarthMonument(string name, int earthAffinity) 
        : base(name, earthAffinity)
    { }

    public int EarthAffinity => base.Affinity;

    public override string ToString()
    {
        return string.Format(base.ToString(), this.EarthAffinity);
    }
}