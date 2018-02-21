public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException() : base("Artist name should be between 3 and 20 symbols.")
    {

    }

    public InvalidArtistNameException(string message) : base(message)
    {

    }
}