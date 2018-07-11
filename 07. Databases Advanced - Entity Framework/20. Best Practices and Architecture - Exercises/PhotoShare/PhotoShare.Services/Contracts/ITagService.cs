using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface ITagService
    {
        Tag GetTagByName(string tagName);

        Tag AddTag(string tagName);

        bool Exist(string tagName);
    }
}