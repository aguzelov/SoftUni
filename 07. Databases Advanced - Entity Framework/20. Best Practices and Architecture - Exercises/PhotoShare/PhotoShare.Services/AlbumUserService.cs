using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Services
{
    public class AlbumUserService : IAlbumUserService
    {
        private readonly PhotoShareContext context;

        public AlbumUserService(PhotoShareContext context)
        {
            this.context = context;
        }

        public void AddUserToAlbum(Album album, User user)
        {
            AlbumRole albumRole = new AlbumRole
            {
                Album = album,
                User = user
            };

            context.AlbumRoles.Add(albumRole);
        }
    }
}