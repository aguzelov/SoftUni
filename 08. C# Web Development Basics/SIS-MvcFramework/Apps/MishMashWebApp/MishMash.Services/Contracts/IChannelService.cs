using MishMash.Models;
using System.Collections.Generic;
using System.Linq;

namespace MishMash.Services
{
    public interface IChannelService
    {
        IQueryable<Channel> YourChannels(string username);

        ICollection<Channel> FollowedChannels(string username);

        IQueryable<Channel> SuggestedChannels(string username);

        IQueryable<Channel> SeeOtherChannels(string username);

        bool Follow(int userId, int channelId);

        bool Unfollow(int userId, int channelId);

        bool AddChannel(string name, string description, string allTags, string typeStr, User user);
    }
}