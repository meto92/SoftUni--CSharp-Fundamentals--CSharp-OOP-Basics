using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        int linesCunt = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < linesCunt; i++)
        {
            string[] personParams = Console.ReadLine().Split(' ');

            string firstName = personParams[0];
            string lastName = personParams[1];
            int age = int.Parse(personParams[2]);
            decimal salary = decimal.Parse(personParams[3]);

            try
            {
                Person person = new Person(firstName, lastName, age, salary);

                people.Add(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        decimal bonus = decimal.Parse(Console.ReadLine());

        people.ForEach(p => p.IncreaseSalary(bonus));

        people.ForEach(Console.WriteLine);
    }
}