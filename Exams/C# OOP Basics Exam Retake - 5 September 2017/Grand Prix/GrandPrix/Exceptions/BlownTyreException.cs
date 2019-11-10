public class BlownTyreException : RaceException
{
    private const string BlownTyreExceptionMessage = "Blown Tyre";

    public BlownTyreException()
        : base(BlownTyreExceptionMessage)
    { }
}