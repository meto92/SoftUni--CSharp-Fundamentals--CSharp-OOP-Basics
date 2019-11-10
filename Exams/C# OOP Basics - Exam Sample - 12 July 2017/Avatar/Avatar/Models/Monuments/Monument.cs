public abstract class Monument : Nameable, IMonument
{
    private int affinity;

    protected Monument(string name, int affinity) 
        : base(name)
    {
        this.Affinity = affinity;
    }

    public int Affinity
    {
        get => this.affinity;
        protected set => this.affinity = value;
    }

    public override string ToString()
    {
        string fullTypeName = this.GetType().Name;
        string type = fullTypeName.
            Substring(0, fullTypeName.Length - nameof(Monument).Length);

        string result = string.Format("{0} Monument: {1}, {0} Affinity: {2}",
            type,
            base.Name,
            "{0}");

        return result;
    }
}