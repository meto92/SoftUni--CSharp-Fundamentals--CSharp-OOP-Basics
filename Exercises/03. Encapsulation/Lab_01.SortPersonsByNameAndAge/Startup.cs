using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        int linesCount = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < linesCount; i++)
        {
            string[] personParams = Console.ReadLine().Split();

            string firstName = personParams[0];
            string lastName = personParams[1];
            int age = int.Parse(personParams[2]);

            Person person = new Person(firstName, lastName, age);

            people.Add(person);
        }

        people.OrderBy(person => person.FirstName)
            .ThenBy(person => person.Age)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}