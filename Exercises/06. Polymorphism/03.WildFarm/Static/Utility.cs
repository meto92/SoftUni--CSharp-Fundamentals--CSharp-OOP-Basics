using System;

public static class Utility
{
    private const string NullOrEmptyStringMessage = "{0} cannot be null!";
    private const string ZeroOrNegativeNumberMessage = "{0} must be non-zero and positive!";
    private const string NegativeNumberMessage = "{0} must be positive!";

    public static string ValidateNullOrEmptyString(string value, string paramName)
    {
        if (string.IsNullOrEmpty(value) || value.Trim() == string.Empty)
        {
            throw new ArgumentNullException(
                paramName, 
                string.Format(NullOrEmptyStringMessage, paramName));
        }

        return value;
    }

    public static double ValidateNonZeroPositiveNumber(double value, string paramName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(
                paramName, 
                string.Format(ZeroOrNegativeNumberMessage, paramName));
        }

        return value;
    }

    public static double ValidatePositiveNumber(double value, string paramName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                paramName, 
                string.Format(NegativeNumberMessage, paramName));
        }

        return value;
    }
}