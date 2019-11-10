using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static Person GetPerson(string[] personParams, List<Person> people)
    {
        Person person = null;
        Person foundPerson = null;

        if (personParams.Length == 1)
        {
            string birthdate = personParams[0];

            person = new Person(birthdate);
            foundPerson = people.Find(p => p.Birthdate == birthdate);
        }
        else
        {
            string firstName = personParams[0];
            string lastName = personParams[1];
            string fullName = $"{firstName} {lastName}";

            person = new Person(firstName, lastName);
            foundPerson = people.Find(p => p.FullName == fullName);
        }

        return foundPerson ?? person;
    }

    private static List<Person> GetPeople(List<string> peopleNamesAndBirthdates)
    {
        List<Person> people = new List<Person>();

        foreach (string personData in peopleNamesAndBirthdates)
        {
            string[] personParams = personData.Split();

            string firstName = personParams[0];
            string lastName = personParams[1];
            string birthdate = personParams[2];

            Person person = new Person(firstName, lastName, birthdate);

            people.Add(person);
        }

        return people;
    }

    private static void FillPeopleData(List<Person> people, List<string> peoplePiecesOfData)
    {
        foreach (string peoplePieceOfData in peoplePiecesOfData)
        {
            string[] peopleParams = peoplePieceOfData.Split(" - ");

            string[] firstPersonParams = peopleParams[0].Split();
            string[] secondPersonParams = peopleParams[1].Split();

            Person firstPerson = GetPerson(firstPersonParams, people);
            Person secondPerson = GetPerson(secondPersonParams, people);

            firstPerson.Children.Add(secondPerson);
            secondPerson.Parents.Add(firstPerson);
        }
    }

    private static void PrintPersonInfo(Person person)
    {
        Console.WriteLine(person);
        Console.WriteLine("Parents:{0}",
            person.Parents.Count == 0
                ? string.Empty
                : Environment.NewLine + string.Join(Environment.NewLine, person.Parents));
        Console.WriteLine("Children:");
        Console.WriteLine(string.Join(Environment.NewLine, person.Children));
    }

    public static void Main()
    {
        Person person = GetPerson(Console.ReadLine().Split(), new List<Person>());

        List<string> peoplePiecesOfData = new List<string>();
        List<string> peopleNamesAndBirthdates = new List<string>();

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            if (!input.Contains('-'))
            {
                peopleNamesAndBirthdates.Add(input);
            }
            else
            {
                peoplePiecesOfData.Add(input);
            }
        }

        List<Person> people = GetPeople(peopleNamesAndBirthdates);

        FillPeopleData(people, peoplePiecesOfData);

        if (person.Birthdate != null)
        {
            person = people.Find(p => p.Birthdate == person.Birthdate);
        }
        else
        {
            person = people.Find(p => p.FullName == person.FullName);
        }

        PrintPersonInfo(person);
    }
}