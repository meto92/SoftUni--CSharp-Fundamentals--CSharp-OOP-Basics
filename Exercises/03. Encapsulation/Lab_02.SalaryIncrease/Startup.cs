using System;
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

            string firstame = personParams[0];
            string lastName = personParams[1];
            int age = int.Parse(personParams[2]);
            decimal salary = decimal.Parse(personParams[3]);

            Person person = new Person(firstame, lastName, age, salary);

            people.Add(person);
        }

        decimal bonus = decimal.Parse(Console.ReadLine());

        people.ForEach(p => p.IncreaseSalary(bonus));

        people.ForEach(Console.WriteLine);
    }
}