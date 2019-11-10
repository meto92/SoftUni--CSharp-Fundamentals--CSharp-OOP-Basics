class InvalidSongNameException : InvalidSongException
{
    private const string InvalidSongNameExceptionMessage = "Song name should be between 3 and 30 symbols.";

    public InvalidSongNameException()
        : base(InvalidSongNameExceptionMessage)
    { }
}