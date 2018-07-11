using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IAlbumRoleService
    {
        AlbumRole ShareAlbum(Album album, User user, Role role);
    }
}