using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Services
{
    public class AlbumRoleService : IAlbumRoleService
    {
        private readonly PhotoShareContext context;

        public AlbumRoleService(PhotoShareContext context)
        {
            this.context = context;
        }

        public AlbumRole ShareAlbum(Album album, User user, Role role)
        {
            AlbumRole albumRole = new AlbumRole
            {
                Album = album,
                User = user,
                Role = role
            };

            context.AlbumRoles.Add(albumRole);

            context.SaveChanges();

            return albumRole;
        }
    }
}