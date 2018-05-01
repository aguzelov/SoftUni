namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SongFactory : ISongFactory
    {
        public ISong CreateSong(string name, TimeSpan duration)
        {
            Type songType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(s => s.Name == "Song");

            if (songType == null)
            {
                throw new InvalidOperationException("Song not found!");
            }

            if (!typeof(ISong).IsAssignableFrom(songType))
            {
                throw new InvalidOperationException($"Song is not a ISong!");
            }

            ISong song = (ISong)Activator.CreateInstance(songType, name, duration);

            return song;
        }
    }
}