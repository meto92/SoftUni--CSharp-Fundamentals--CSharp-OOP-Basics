using System;
using System.Collections.Generic;

public static class Utility
{
    private const string InvalidStatExceptionMessage = "{0} should be between 0 and 100.";

    public static int ValidateFootballPlayerStat(int statValue, string stat)
    {
        if (statValue < 0 || statValue > 100)
        {
            throw new ArgumentException(string.Format(InvalidStatExceptionMessage, stat));
        }

        return statValue;
    }

    public static string ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Trim() == string.Empty)
        {
            throw new ArgumentException("A name should not be empty.");
        }

        return name;
    }
}