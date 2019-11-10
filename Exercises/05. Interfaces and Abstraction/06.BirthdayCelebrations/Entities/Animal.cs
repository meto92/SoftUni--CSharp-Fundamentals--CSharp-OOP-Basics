public abstract class Animal : IAnimal
{
    private string name;
    private string birthdate;

    public Animal(string name, string birthdate)
    {
        this.Birthdate = birthdate;
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public string Birthdate
    {
        get => this.birthdate;
        set => this.birthdate = value;
    }

    public override string ToString()
    {
        return this.Birthdate;
    }
}