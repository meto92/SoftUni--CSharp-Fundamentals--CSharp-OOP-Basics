public class InvalidSongLengthException : InvalidSongException
{
    private const string InvalidSongLengthExceptionMessage = "Invalid song length.";

    public InvalidSongLengthException()
        : base(InvalidSongLengthExceptionMessage)
    { }

    public InvalidSongLengthException(string message)
        : base(message)
    { }
}