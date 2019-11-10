public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int? age;

    public Employee(string name, decimal salary, string position, string department, string email, int? age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = age;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public decimal Salary
    {
        get => salary;
        set => salary = value;
    }

    public string Position
    {
        get => position;
        set => position = value;
    }

    public string Department
    {
        get => department;
        set => department = value;
    }

    public string Email
    {
        get => email ?? "n/a";
        set => email = value;
    }

    public int? Age
    {
        get
        {
            if (age == null)
            {
                return -1;
            }

            return age;
        }

        set => age = value;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
    }
}