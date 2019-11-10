public class FireMonument : Monument, IFireMonument
{
    public FireMonument(string name, int fireAffinity) 
        : base(name, fireAffinity)
    { }

    public int FireAffinity => base.Affinity;

    public override string ToString()
    {
        return string.Format(base.ToString(), this.FireAffinity);
    }
}