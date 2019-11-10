using System;

public abstract class Human
{
    private const int FirstNameMinLength = 4;
    private const int LastNameMinLength = 3;

    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get => this.firstName;

        set
        {
            this.ValidateNameFirstLetter(value, "firstName");
            this.ValidateNameLength(value, FirstNameMinLength, "firstName");
            this.firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;

        set
        {
            this.ValidateNameFirstLetter(value, "lastName");
            this.ValidateNameLength(value, LastNameMinLength, "lastName");
            this.lastName = value;
        }
    }

    private string ValidateNameFirstLetter(string value, string nameType)
    {
        char firstChar = value[0];

        if (!char.IsLetter(firstChar) || char.IsLower(firstChar))
        {
            throw new NameFirstLetterUppercaseException(nameType);
        }

        return value;
    }

    private string ValidateNameLength(string value, int minLength, string nameType)
    {
        if (value.Length < minLength)
        {
            throw new NameLengthException(nameType, minLength);
        }

        return value;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}{Environment.NewLine}Last Name: {this.LastName}";
    }
}