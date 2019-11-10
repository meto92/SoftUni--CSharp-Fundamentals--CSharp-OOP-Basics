using System;

public class NameLengthException : Exception
{
    private const string NameLengthExceptionMessage = "Expected length at least {0} symbols! Argument: {1}";

    public NameLengthException(string argumentType, int minLength)
        : base(string.Format(NameLengthExceptionMessage, minLength, argumentType))
    { }
}