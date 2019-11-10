using System;

public class NameFirstLetterUppercaseException : Exception
{
    private const string NameUppercaseExceptionMessage = "Expected upper case letter! Argument: {0}";

    public NameFirstLetterUppercaseException(string nameType)
        : base(string.Format(NameUppercaseExceptionMessage, nameType))
    { }
}