using IRunes.Models;
using System.Collections.Generic;

namespace IRunes.Services.TrackServices
{
    public interface ITrackService
    {
        void Add(Track order);

        ICollection<Track> GetTracksByUserId(string id);

        void Add(string name, string link, decimal price, Album album);

        Track GetTrackById(string id);
    }
}