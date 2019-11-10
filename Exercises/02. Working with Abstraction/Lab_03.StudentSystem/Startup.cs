using System;

public class Startup
{
    private static void CreateStudent(StudentSystem studentSystem, string[] args)
    {
        string name = args[1];
        int age = int.Parse(args[2]);
        double grade = double.Parse(args[3]);

        studentSystem.TryCreateStudent(name, age, grade);
    }

    private static void ParseCommand(StudentSystem studentSystem, string command)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            CreateStudent(studentSystem, args);
        }
        else if (args[0] == "Show")
        {
            string name = args[1];

            studentSystem.TryShowStudentInfo(name);
        }
    }

    public static void Main()
    {
        StudentSystem studentSystem = new StudentSystem();

        string command = null;

        while ((command = Console.ReadLine()) != "Exit")
        {
            ParseCommand(studentSystem, command);
        }
    }
}