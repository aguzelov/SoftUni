using IRunes.Data;
using IRunes.Models;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services.TrackServices
{
    public class TrackService : ITrackService
    {
        private readonly IRunesContext _context;

        public TrackService(IRunesContext context)
        {
            this._context = context;
        }

        public void Add(Track track)
        {
            this._context.Tracks.Add(track);
            this._context.SaveChanges();
        }

        public void Add(string name, string link, decimal price, Album album)
        {
            var track = new Track()
            {
                Name = name,
                Link = link,
                Price = price,
                Album = album
            };

            this.Add(track);
        }

        public ICollection<Track> GetTracksByUserId(string albumId)
        {
            var track = this._context.Tracks
                .Where(o => o.AlbumId == albumId)
                .ToList();

            return track;
        }

        public Track GetTrackById(string id)
        {
            var track = this._context.Tracks.FirstOrDefault(o => o.Id == id);

            return track;
        }
    }
}