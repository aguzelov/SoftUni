public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException() : base("Invalid song length.")
    {

    }

    public InvalidSongLengthException(string message) : base(message)
    {

    }
}