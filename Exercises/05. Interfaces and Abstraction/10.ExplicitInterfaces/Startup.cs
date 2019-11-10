using System;

public class Startup
{
    public static void Main()
    {
        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] citizenParams = input.Split();

            string name = citizenParams[0];
            string country = citizenParams[1];
            int age = int.Parse(citizenParams[2]);

            Citizen citizen = new Citizen(name, country, age);

            IPerson person = citizen;
            IResident resident = citizen;

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());
        }
    }
}