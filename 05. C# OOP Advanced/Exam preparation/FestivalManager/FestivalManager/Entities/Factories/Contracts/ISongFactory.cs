namespace FestivalManager.Entities.Factories.Contracts
{
    using Entities.Contracts;
    using System;

    public interface ISongFactory
    {
        ISong CreateSong(string name, TimeSpan duration);
    }
}