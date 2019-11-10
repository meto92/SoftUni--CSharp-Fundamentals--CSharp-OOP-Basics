public class WaterMonument : Monument, IWaterMonument
{
    public WaterMonument(string name, int waterAffinity) 
        : base(name, waterAffinity)
    { }

    public int WaterAffinity => base.Affinity;

    public override string ToString()
    {
        return string.Format(base.ToString(), this.WaterAffinity);
    }
}