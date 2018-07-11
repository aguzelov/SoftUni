using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IFriendshipService
    {
        void AddFriendTo(User user, User friend);

        void AcceptFriend(User user, User friend);

        string[] GetAllFriends(string username);

        bool Exist(string userName, string friendName);
    }
}