using System;

public class InvalidSongException : Exception
{
    public InvalidSongException() : base("Invalid song.")
    {
    }

    public InvalidSongException(string message) : base(message)
    {
    }
}