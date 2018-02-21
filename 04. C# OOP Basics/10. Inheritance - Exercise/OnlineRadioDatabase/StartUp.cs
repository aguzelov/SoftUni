using System;

public class StartUp
{
    private static void Main()
    {

        RadioDatabase radio = new RadioDatabase();

        int numberOfInput = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInput; i++)
        {
            Song song = null;

            try
            {
                GetSong(out song);
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }


            radio.AddSong(song);
            Console.WriteLine("Song added.");
        }

        System.Console.WriteLine(radio);
    }

    private static void GetSong(out Song song)
    {
        song = null;

        string[] tokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length != 3) throw new InvalidSongException();

        string artist = tokens[0];
        string songName = tokens[1];
        string[] length = tokens[2].Split(":", StringSplitOptions.RemoveEmptyEntries);

        int minutes = 0;
        int seconds = 0;
        if (length.Length != 2) throw new InvalidSongLengthException();
        try
        {
            minutes = int.Parse(length[0]);
            seconds = int.Parse(length[1]);
        }
        catch (Exception)
        {
            throw new InvalidSongLengthException();
        }
        
        song = new Song(artist, songName, minutes, seconds);
    }
}