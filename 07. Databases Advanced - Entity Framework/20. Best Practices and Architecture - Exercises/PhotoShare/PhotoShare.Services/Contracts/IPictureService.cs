using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IPictureService
    {
        Picture UploadPicture(Album album, string pictureTitle, string path);
    }
}