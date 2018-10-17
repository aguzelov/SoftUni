using System.Collections.Generic;
using IRunes.Models;

namespace IRunes.Services.AlbumServices
{
    public interface IAlbumService
    {
        void Add(string name, string cover);

        ICollection<Album> GetAll();

        ICollection<Album> GetAll(string searchedCakes);

        Album Get(string id);
    }
}