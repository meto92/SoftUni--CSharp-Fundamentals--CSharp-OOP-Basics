using System.Text;

public class Worker : Human
{
    private const int MinWorkingHours = 1;
    private const int MaxWorkingHours = 12;
    private const int WeeklyWorkingDays = 5;
    private const decimal MinWeeklySalary = 10m;

    private decimal weekSalary;
    private decimal workingHours;    

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours) 
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
    }

    public decimal WeekSalary
    {
        get => this.weekSalary;

        set
        {
            if (value <= MinWeeklySalary)
            {
                throw new WorkerException("weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public decimal WorkingHours
    {
        get => this.workingHours;

        set
        {
            if (value < MinWorkingHours || value > MaxWorkingHours)
            {
                throw new WorkerException("workHoursPerDay");
            }

            this.workingHours = value;
        }
    }

    public decimal SalaryPerHour => this.WeekSalary / WeeklyWorkingDays / this.WorkingHours;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.WorkingHours:f2}");
        sb.Append($"Salary per hour: {this.SalaryPerHour:f2}");

        return sb.ToString();
    }
}