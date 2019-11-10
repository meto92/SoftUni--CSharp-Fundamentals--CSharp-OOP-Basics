using System;

public class InvalidSongException : Exception
{
    private const string InvalidSongExceptionMessage = "Invalid song.";

    public InvalidSongException()
        : base(InvalidSongExceptionMessage)
    { }

    public InvalidSongException(string message)
        : base(message)
    { }
}