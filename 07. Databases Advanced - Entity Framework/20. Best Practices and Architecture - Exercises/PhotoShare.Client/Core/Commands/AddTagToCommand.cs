namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Client.Validation;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;

    [CredentialAttribute(true)]
    public class AddTagToCommand : ICommand
    {
        private readonly IAlbumServise albumServise;
        private readonly ITagService tagService;
        private readonly IAlbumTagService albumTagService;

        public AddTagToCommand(IAlbumServise albumServise, ITagService tagService, IAlbumTagService albumTagService)
        {
            this.albumServise = albumServise;
            this.tagService = tagService;
            this.albumTagService = albumTagService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            string albumTitle = data[0];
            string tagName = data[1].ValidateOrTransform();
            Album album = null;
            Tag tag = null;

            try
            {
                album = albumServise.GetAlbumByName(albumTitle);

                tag = tagService.GetTagByName(tagName);

                albumTagService.AddTagToAlbum(album, tag);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            return $"Tag {tag.Name} added to {album.Name}!";
        }
    }
}