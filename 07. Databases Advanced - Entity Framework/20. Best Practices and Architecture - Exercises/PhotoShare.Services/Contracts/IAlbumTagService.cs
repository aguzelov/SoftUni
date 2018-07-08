using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IAlbumTagService
    {
        void AddTagToAlbum(Album album, Tag tag);
    }
}