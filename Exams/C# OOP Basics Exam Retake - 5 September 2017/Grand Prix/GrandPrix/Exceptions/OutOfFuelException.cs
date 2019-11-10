public class OutOfFuelException : RaceException
{
    private const string OutOfFuelExceptionMessage = "Out of fuel";

    public OutOfFuelException()
        : base(OutOfFuelExceptionMessage)
    { }
}