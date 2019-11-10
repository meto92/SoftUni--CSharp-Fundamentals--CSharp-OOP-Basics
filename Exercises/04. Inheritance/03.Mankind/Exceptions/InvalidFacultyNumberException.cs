using System;

public class InvalidFacultyNumberException : Exception
{
    private const string InvalidFacultyNumberExceptionMessage = "Invalid faculty number!";

    public InvalidFacultyNumberException()
        : base(InvalidFacultyNumberExceptionMessage)
    { }
}