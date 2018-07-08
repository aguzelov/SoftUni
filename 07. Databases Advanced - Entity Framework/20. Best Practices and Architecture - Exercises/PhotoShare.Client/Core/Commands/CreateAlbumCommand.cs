namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Client.Validation;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System.Linq;

    [CredentialAttribute(true)]
    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumServise service;

        public CreateAlbumCommand(IAlbumServise service)
        {
            this.service = service;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string bgColor = data[2];
            string[] tags = data.Skip(3).Select(t => t.ValidateOrTransform()).ToArray();

            Album album = service.CreateAlbum(username, albumTitle, bgColor, tags);

            return $"Album {album.Name} successfully created!";
        }
    }
}