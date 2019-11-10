public class Private : Soldier, IPrivate
{
    private decimal salary;

    public Private(Soldier soldier, decimal salary)
        : this(soldier.Id, soldier.FirstName, soldier.LastName, salary)
    { }

    public Private(string id, string firstName, string lastName, decimal salary) 
        : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public decimal Salary
    {
        get => this.salary;
        set => this.salary = value;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {this.Salary:f2}";
    }
}