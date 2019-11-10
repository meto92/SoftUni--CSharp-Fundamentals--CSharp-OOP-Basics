public abstract class Nameable : INameable
{
    private string name;

    protected Nameable(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }
}