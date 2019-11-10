public abstract class Person : IPerson, IBuyer
{
    private string name;
    private int age;
    private int food;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public int Food
    {
        get => this.food;
        set => this.food = value;
    }

    public abstract void BuyFood();
}