using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Services
{
    public class PictureService : IPictureService
    {
        private readonly PhotoShareContext context;

        public PictureService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Picture UploadPicture(Album album, string pictureTitle, string path)
        {
            Picture picture = new Picture
            {
                Title = pictureTitle,
                Path = path,
                Album = album
            };

            context.Pictures.Add(picture);

            context.SaveChanges();

            return picture;
        }
    }
}