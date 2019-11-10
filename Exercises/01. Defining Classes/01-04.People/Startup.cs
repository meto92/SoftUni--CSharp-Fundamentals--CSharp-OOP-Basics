using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static void OldestFamilyMember()
    {
        int membersCount = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < membersCount; i++)
        {
            string[] personParams = Console.ReadLine().Split();

            string name = personParams[0];
            int age = int.Parse(personParams[1]);

            Person member = new Person(name, age);

            family.AddMember(member);
        }

        Console.WriteLine(family.GetOldestMember());
    }

    private static void OpinionPoll()
    {
        int membersCount = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < membersCount; i++)
        {
            string[] personParams = Console.ReadLine().Split();

            string name = personParams[0];
            int age = int.Parse(personParams[1]);

            Person member = new Person(name, age);

            people.Add(member);
        }

        people.Where(person => person.Age > 30)
            .OrderBy(person => person.Name)
            .ToList()
            .ForEach(Console.WriteLine);
    }

    public static void Main()
    {
        OpinionPoll();
    }
}