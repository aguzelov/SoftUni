public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException() : base("Song minutes should be between 0 and 14.")
    {

    }

    public InvalidSongMinutesException(string message) : base(message)
    {

    }
}