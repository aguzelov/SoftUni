namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    [CredentialAttribute(true)]
    public class UploadPictureCommand : ICommand
    {
        private readonly IAlbumServise albumServise;
        private readonly IPictureService pictureService;

        public UploadPictureCommand(IAlbumServise albumServise, IPictureService pictureService)
        {
            this.albumServise = albumServise;
            this.pictureService = pictureService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumTitle = data[0];
            string pictureTitle = data[1];
            string picturePath = data[2];

            Album album = albumServise.GetAlbumByName(albumTitle);

            Picture picture = pictureService.UploadPicture(album, pictureTitle, picturePath);

            return $"Picture {picture.Title} added to {album.Name}!";
        }
    }
}