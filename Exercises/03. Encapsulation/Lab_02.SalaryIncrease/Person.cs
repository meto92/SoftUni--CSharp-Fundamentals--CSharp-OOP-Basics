public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public string FirstName => this.firstName;
    public string LastName => this.lastName;
    public int Age => this.age;
    public decimal Salary => this.salary;

    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age < 30)
        {
            this.salary *= 1 + percentage / 200;
        }
        else
        {
            this.salary *= 1 + percentage / 100;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
    }
}