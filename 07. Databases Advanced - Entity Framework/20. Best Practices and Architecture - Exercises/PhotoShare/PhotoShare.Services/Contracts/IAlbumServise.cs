using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IAlbumServise
    {
        Album GetAlbumByName(string albumTitle);

        Album GetAlbumById(int id);

        Album CreateAlbum(string username, string albumTitle, string bgColor, params string[] tags);

        bool Exist(string albumName);
    }
}