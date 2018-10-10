using IRunes.Data;
using IRunes.Models;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services.AlbumServices
{
    public class AlbumService : IAlbumService
    {
        private readonly IRunesContext _context;

        public AlbumService(IRunesContext context)
        {
            this._context = context;
        }

        public void Add(string name, string cover)
        {
            var album = new Album()
            {
                Name = name,
                Cover = cover
            };

            this._context.Albums.Add(album);
            this._context.SaveChanges();
        }

        public ICollection<Album> GetAll()
        {
            var albums = this._context.Albums.ToArray();

            return albums;
        }

        public ICollection<Album> GetAll(string searchedAlbum)
        {
            var albums = this._context.Albums
                .Where(c => c.Name.Contains(searchedAlbum))
                .ToArray();

            return albums;
        }

        public Album Get(string id)
        {
            var album = this._context.Albums.Find(id);

            return album;
        }
    }
}