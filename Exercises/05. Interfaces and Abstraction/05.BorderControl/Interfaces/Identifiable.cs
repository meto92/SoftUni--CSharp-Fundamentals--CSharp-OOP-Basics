public abstract class Identifiable : IIdentifiable
{
    private string id;

    public Identifiable(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }

    public override string ToString()
    {
        return this.Id;
    }
}