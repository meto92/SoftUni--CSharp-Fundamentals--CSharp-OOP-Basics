public class Student
{
    private string name;
    private int age;
    private double grade;

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.grade = grade;
    }

    public double Grade
    {
        get => grade; 
        set => grade = value;
    }

    public int Age
    {
        get => age; 
        set => age = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    private string GetStudentSuccess()
    {
        if (this.Grade >= 5.00)
        {
            return "Excellent student.";
        }

        if (this.Grade < 5.00 && this.Grade >= 3.50)
        {
            return "Average student.";
        }

        return "Very nice person.";
    }

    public override string ToString()
    {
        return $"{this.Name} is {this.Age} years old. {GetStudentSuccess()}";
    }
}