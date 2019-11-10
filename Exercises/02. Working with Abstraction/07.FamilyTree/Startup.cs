using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }

    private static Person GetPerson(List<Person> familyTree, string personInfo)
    {
        Person person = null;

        if (IsBirthday(personInfo))
        {
            person = familyTree.Find(p => p.Birthday == personInfo);

            if (person == null)
            {
                person = new Person();
                person.Birthday = personInfo;
                familyTree.Add(person);
            }
        }
        else
        {
            person = familyTree.Find(p => p.Name == personInfo);

            if (person == null)
            {
                person = new Person();
                person.Name = personInfo;
                familyTree.Add(person);
            }
        }

        return person;
    }

    private static void MergePersnInfo(ref List<Person> familyTree, string name, string birthday)
    {
        Person person = familyTree.Find(p => p.Name == name || p.Birthday == birthday);

        if (person == null)
        {
            person = new Person();
            familyTree.Add(person);
        }

        person.Name = name;
        person.Birthday = birthday;

        Person copyPerson = familyTree.FindLast(p => p.Name == name || p.Birthday == birthday);

        if (copyPerson != person)
        {
            familyTree.Remove(copyPerson);

            person.Parents.AddRange(copyPerson.Parents);
            person.Parents = person.Parents.Distinct().ToList();

            person.Children.AddRange(copyPerson.Children);
            person.Children = person.Children.Distinct().ToList();

            copyPerson.Name = person.Name;
            copyPerson.Birthday = person.Birthday;
            copyPerson.Parents = person.Parents;
            copyPerson.Children = person.Children;
        }
    }

    public static void Main()
    {
        List<Person> familyTree = new List<Person>();
        string personInput = Console.ReadLine();
        Person mainPerson = new Person();

        if (IsBirthday(personInput))
        {
            mainPerson.Birthday = personInput;
        }
        else
        {
            mainPerson.Name = personInput;
        }

        familyTree.Add(mainPerson);

        string command = null;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" - ");

            if (tokens.Length > 1)
            {
                string firstPerson = tokens[0];
                string secondPerson = tokens[1];

                Person parentPerson = GetPerson(familyTree, firstPerson);
                Person childPerson = GetPerson(familyTree, secondPerson);

                parentPerson.Children.Add(childPerson);
                childPerson.Parents.Add(parentPerson);
            }
            else
            {
                tokens = tokens[0].Split();
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];

                MergePersnInfo(ref familyTree, name, birthday);
            }
        }

        Console.WriteLine(mainPerson);
        Console.WriteLine("Parents:");
        mainPerson.Parents.ForEach(Console.WriteLine);
        Console.WriteLine("Children:");
        mainPerson.Children.ForEach(Console.WriteLine);
    }
}