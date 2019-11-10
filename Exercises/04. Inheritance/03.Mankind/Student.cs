using System.Linq;
using System.Text;

public class Student : Human
{
    private const int FacultyNumberMinLength = 5;
    private const int FacultyNumberMaxLength = 10;

    private string facultyNumber;   

    public Student(string firstName, string lastName, string facultyNumber) 
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get => this.facultyNumber;

        set
        {
            if (value.Length < FacultyNumberMinLength ||
                value.Length > FacultyNumberMaxLength ||
                value.Any(c => !char.IsLetterOrDigit(c)))
            {
                throw new InvalidFacultyNumberException();
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.Append($"Faculty number: {this.FacultyNumber}");

        return sb.ToString();
    }
}