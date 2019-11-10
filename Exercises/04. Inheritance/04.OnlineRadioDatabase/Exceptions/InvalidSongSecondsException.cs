public class InvalidSongSecondsException : InvalidSongLengthException
{
    private const string InvalidSongSecondsExceptionMessage = "Song seconds should be between 0 and 59.";

    public InvalidSongSecondsException()
        : base(InvalidSongSecondsExceptionMessage)
    { }
}