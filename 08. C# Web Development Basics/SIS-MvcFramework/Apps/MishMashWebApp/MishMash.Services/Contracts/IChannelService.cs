using MishMash.Models;
using System.Collections.Generic;

namespace MishMash.Services
{
    public interface IChannelService
    {
        ICollection<Channel> YourChannels(string username);

        ICollection<int> FollowedChannelsTags(string username);

        ICollection<Channel> FollowedChannels(string username);

        ICollection<Channel> SuggestedChannels(string username);

        ICollection<Channel> SeeOtherChannels(string username);

        bool Follow(int userId, int channelId);

        bool Unfollow(int userId, int channelId);

        bool AddChannel(string name, string description, string allTags, string typeStr, User user);
    }
}