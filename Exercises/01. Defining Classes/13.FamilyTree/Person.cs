using System.Collections.Generic;

public class Person
{
    private string firstName;
    private string lastName;
    private string birthdate;
    private List<Person> parents;
    private List<Person> children;

    public Person(string birthdate)
        : this(null, null, birthdate)
    { }

    public Person(string firstName, string lastName)
        : this(firstName, lastName, null)
    { }

    public Person(string firstName, string lastName, string birthdate)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Birthdate = birthdate;
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public string FirstName
    {
        get => firstName;
        set => firstName = value;
    }

    public string LastName
    {
        get => lastName;
        set => lastName = value;
    }

    public string Birthdate
    {
        get => birthdate;
        set => birthdate = value;
    }

    public List<Person> Parents
    {
        get => parents;
        set => parents = value;
    }

    public List<Person> Children
    {
        get => children;
        set => children = value;
    }

    public string FullName => $"{this.FirstName} {this.LastName}";

    public override string ToString()
    {
        return $"{this.FullName} {this.Birthdate}";
    }
}