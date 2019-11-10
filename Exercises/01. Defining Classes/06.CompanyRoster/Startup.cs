using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static void GetEmailAndAge(string[] employeeParams, out string email, out int? age)
    {
        string employeeEmail = null;
        int? employeeAge = null;

        if (employeeParams.Length == 5)
        {
            if (int.TryParse(employeeParams[4], out int personAge))
            {
                employeeAge = personAge;
            }
            else
            {
                employeeEmail = employeeParams[4];
            }
        }
        else if (employeeParams.Length == 6)
        {
            if (int.TryParse(employeeParams[4], out int personAge))
            {
                employeeAge = personAge;
                employeeEmail = employeeParams[5];
            }
            else
            {
                employeeEmail = employeeParams[4];
                employeeAge = int.Parse(employeeParams[5]);
            }
        }

        email = employeeEmail;
        age = employeeAge;
    }

    private static Dictionary<string, List<Employee>> GetEmployeesByDepartments()
    {
        Dictionary<string, List<Employee>> employeesByDepartments =
            new Dictionary<string, List<Employee>>();
        int employeesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < employeesCount; i++)
        {
            string[] employeeParams = Console.ReadLine().Split();

            string name = employeeParams[0];
            decimal salary = decimal.Parse(employeeParams[1]);
            string position = employeeParams[2];
            string department = employeeParams[3];

            GetEmailAndAge(employeeParams, out string email, out int? age);

            Employee employee = new Employee(name, salary, position, department, email, age);

            if (!employeesByDepartments.ContainsKey(department))
            {
                employeesByDepartments[department] = new List<Employee>();
            }

            employeesByDepartments[department].Add(employee);
        }

        return employeesByDepartments;
    }

    public static void Main()
    {

        Dictionary<string, List<Employee>> employeesByDepartments = GetEmployeesByDepartments();            
        string departmentWithWithHighestAverageSalary
            = employeesByDepartments.OrderByDescending(p => p.Value.Sum(e => e.Salary) / p.Value.Count)
            .First()
            .Key;

        Console.WriteLine($"Highest Average Salary: {departmentWithWithHighestAverageSalary}");

        employeesByDepartments[departmentWithWithHighestAverageSalary]
            .OrderByDescending(employee => employee.Salary)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}