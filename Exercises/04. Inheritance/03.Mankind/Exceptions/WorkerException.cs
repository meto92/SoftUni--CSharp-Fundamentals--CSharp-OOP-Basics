using System;

public class WorkerException : Exception
{
    private const string WorkerExceptionMessage = "Expected value mismatch! Argument: {0}";

    public WorkerException(string argumentType)
        : base(string.Format(WorkerExceptionMessage, argumentType))
    { }
}