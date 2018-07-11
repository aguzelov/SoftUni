using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IAlbumUserService
    {
        void AddUserToAlbum(Album album, User user);
    }
}