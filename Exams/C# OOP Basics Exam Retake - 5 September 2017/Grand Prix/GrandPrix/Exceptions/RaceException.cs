using System;

public class RaceException : Exception
{
    public RaceException(string message)
        : base(message)
    { }
}