using System;

public class Startup
{
    public static void Main()
    {
        int linesCount = int.Parse(Console.ReadLine());

        Team team = new Team("Team");

        for (int i = 0; i < linesCount; i++)
        {
            string[] personParams = Console.ReadLine().Split(' ');

            string firstName = personParams[0];
            string lastName = personParams[1];
            int age = int.Parse(personParams[2]);
            decimal salary = decimal.Parse(personParams[3]);

            try
            {
                Person person = new Person(firstName, lastName, age, salary);

                team.AddPlayer(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}