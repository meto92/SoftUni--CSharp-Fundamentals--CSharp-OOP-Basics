using System;

public class InvalidInputException : Exception
{
    private const string InvalidInputExceptionMessage = "Invalid input!";

    public InvalidInputException()
        : base(InvalidInputExceptionMessage)
    { }
}