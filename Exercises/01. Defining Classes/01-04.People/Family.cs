using System.Linq;
using System.Collections.Generic;

public class Family
{
    private List<Person> members;

    public Family()
    {
        this.Members = new List<Person>();
    }

    public List<Person> Members
    {
        get => members;
        set => members = value;
    }

    public void AddMember(Person member)
    {
        this.Members.Add(member);
    }

    public Person GetOldestMember()
    {
        return members.OrderByDescending(person => person.Age).First();
    }
}