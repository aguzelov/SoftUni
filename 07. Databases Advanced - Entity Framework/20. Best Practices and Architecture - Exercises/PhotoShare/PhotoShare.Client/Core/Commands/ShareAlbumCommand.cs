namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;

    [CredentialAttribute(true)]
    public class ShareAlbumCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IAlbumServise albumServise;
        private readonly IAlbumRoleService albumRoleService;

        public ShareAlbumCommand(IUserService userService, IAlbumServise albumServise, IAlbumRoleService albumRoleService)
        {
            this.userService = userService;
            this.albumServise = albumServise;
            this.albumRoleService = albumRoleService;
        }

        // ShareAlbum <albumId> <username> <permission>

        public string Execute(string[] data)
        {
            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permissionName = data[2];

            Album album = albumServise.GetAlbumById(albumId);

            User user = userService.GetUserByUsername(username);

            bool isValid = Enum.TryParse<Role>(permissionName, out Role role);
            if (!isValid)
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
            }

            AlbumRole albumRole = albumRoleService.ShareAlbum(album, user, role);

            return $"Username {user.Username} added to album {album.Name} ({albumRole.Role.ToString()})";
        }
    }
}