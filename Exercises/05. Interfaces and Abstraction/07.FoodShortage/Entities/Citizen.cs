public class Citizen : Person
{
    private string id;
    private string birthdate;

    public Citizen(string name, int age, string id, string birthdate)
        : base(name, age)
    {
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }

    public string Birthdate
    {
        get => this.birthdate;
        set => this.birthdate = value;
    }

    public override void BuyFood()
    {
        base.Food += 10;
    }
}