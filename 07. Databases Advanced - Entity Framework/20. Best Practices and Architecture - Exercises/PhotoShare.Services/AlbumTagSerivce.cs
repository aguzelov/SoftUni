using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Services
{
    public class AlbumTagSerivce : IAlbumTagService
    {
        private readonly PhotoShareContext context;

        public AlbumTagSerivce(PhotoShareContext context)
        {
            this.context = context;
        }

        public void AddTagToAlbum(Album album, Tag tag)
        {
            AlbumTag albumTag = new AlbumTag
            {
                Album = album,
                Tag = tag
            };

            context.AlbumTags.Add(albumTag);

            context.SaveChanges();
        }
    }
}