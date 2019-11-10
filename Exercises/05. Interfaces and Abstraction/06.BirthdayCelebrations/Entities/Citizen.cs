public class Citizen : Animal, IIdentifiable
{
    private int age;
    string id;

    public Citizen(string name, int age, string id, string birthdate)
        : base(name, birthdate)
    {
        this.Age = age;
        this.Id = id;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }
}