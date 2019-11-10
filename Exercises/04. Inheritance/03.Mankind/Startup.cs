using System;

public class Startup
{
    public static void Main()
    {
        string[] studentParams = Console.ReadLine().Split();
        string[] workerParams = Console.ReadLine().Split();

        string studentFirstName = studentParams[0];
        string studentLastName = studentParams[1];
        string studentFacultyNumber = studentParams[2];

        string workerFirstName = workerParams[0];
        string workerLastName = workerParams[1];
        decimal workerWeekSalary = decimal.Parse(workerParams[2]);
        decimal workerDailyWorkingHours = decimal.Parse(workerParams[3]);

        try
        {
            Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerDailyWorkingHours);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}