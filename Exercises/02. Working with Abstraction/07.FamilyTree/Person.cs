using System.Collections.Generic;

public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> children;

    public Person()
    {
        this.Children = new List<Person>();
        this.Parents = new List<Person>();
    }

    public string Name
    {
        get => name; 
        set => name = value;
    }

    public string Birthday
    {
        get => birthday;
        set => birthday = value;
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

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}