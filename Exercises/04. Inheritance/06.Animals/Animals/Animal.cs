using System.Text;

public abstract class Animal : ISoundProducable
{
    public enum SupportedAnimals
    {
        Dog, Frog, Cat, Kitten, Tomcat
    }

    private string name;
    private int age;
    private string gender;

    public Animal(string name, string ageStr, string gender)
    {
        this.Name = name;
        this.AgeStr = ageStr;
        this.Gender = gender;
    }

    public string Name
    {
        get => this.name;

        set
        {
            this.Validate(value);
            this.name = value;
        }
    }

    public string AgeStr
    {
        get => this.age.ToString();

        set
        {
            this.Validate(value);

            if (!int.TryParse(value, out this.age) || int.Parse(value) < 0)
            {
                throw new InvalidInputException();
            }
        }
    }

    private void Validate(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Trim() == string.Empty)
        {
            throw new InvalidInputException();
        }
    }

    public string Gender
    {
        get => this.gender;

        set
        {
            this.Validate(value);
            this.gender = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(this.GetType().Name);
        sb.Append($"{this.Name} {this.AgeStr} {this.Gender}");

        return sb.ToString();
    }

    public abstract void ProduceSound();
}