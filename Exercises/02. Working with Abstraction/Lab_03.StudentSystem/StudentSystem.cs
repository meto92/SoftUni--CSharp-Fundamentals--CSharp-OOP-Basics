using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> Repo
    {
        get => repo;
        private set => repo = value;
    }

    public void TryCreateStudent(string name, int age, double grade)
    {
        if (!this.Repo.ContainsKey(name))
        {
            Student student = new Student(name, age, grade);

            this.Repo[name] = student;
        }
    }

    public void TryShowStudentInfo(string name)
    {
        if (this.Repo.ContainsKey(name))
        {
            Student student = this.Repo[name];

            Console.WriteLine(student);
        }
    }
}