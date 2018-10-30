using MishMash.Data;
using MishMash.Models;
using MishMash.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MishMash.Services
{
    public class ChannelService : IChannelService
    {
        private readonly MishMashContext context;

        public ChannelService(MishMashContext context)
        {
            this.context = context;
        }

        public ICollection<Channel> FollowedChannels(string username)
        {
            return this.YourChannels(username).ToList();
        }

        public IQueryable<Channel> SeeOtherChannels(string username)
        {
            var userChannels = this.YourChannels(username);
            var suggestedChannels = this.SuggestedChannels(username);

            var ids = userChannels.Select(x => x.Id).ToList();
            ids = ids.Concat(suggestedChannels.Select(x => x.Id)).ToList();
            ids = ids.Distinct().ToList();

            return this.context.Channels
                .Where(c => !ids.Contains(c.Id));
        }

        public IQueryable<Channel> SuggestedChannels(string username)
        {
            var tags = this.FollowedChannelsTags(username);
            return this.context.Channels.Where(
                c => !c.Followers.Any(f => f.User.Username == username) &&
                c.Tags.Any(t => tags.Contains(t.Id)));
        }

        public IQueryable<Channel> YourChannels(string username)
        {
            return this.context.Channels
                .Where(c => c.Followers.Any(f => f.User.Username == username));
        }

        public bool Follow(int userId, int channelId)
        {
            var channel = this.context.Channels.FirstOrDefault(x => x.Id == channelId);

            if (channel == null)
            {
                return false;
            }

            channel.Followers.Add(new UserInChannel
            {
                UserId = userId
            });

            this.context.SaveChanges();

            return true;
        }

        public bool Unfollow(int userId, int channelId)
        {
            var userInChannel = this.context.UsersInChannels.FirstOrDefault(x => x.UserId == userId && x.ChannelId == channelId);

            if (userInChannel == null)
            {
                return false;
            }

            this.context.UsersInChannels.Remove(userInChannel);
            this.context.SaveChanges();

            return true;
        }

        public bool AddChannel(string name, string description, string allTags, string typeStr, User user)
        {
            if (!this.IsValid(name, description, allTags, typeStr))
            {
                return false;
            }

            var isParsed = Enum.TryParse<ChannelType>(typeStr, out ChannelType type);
            if (!isParsed)
            {
                return false;
            }

            var tags = allTags.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(t => new ChannelTag
            {
                Tag = new Tag { Name = t.Trim() }
            }).ToList();

            var channel = new Channel
            {
                Name = name,
                Description = description,
                Tags = tags,
                Type = type,
            };

            channel.Followers.Add(new UserInChannel
            {
                UserId = user.Id
            });

            this.context.Channels.Add(channel);
            this.context.SaveChanges();

            return true;
        }

        public void AddFollower(int id)
        {
        }

        private ICollection<int> FollowedChannelsTags(string username)
        {
            return this.YourChannels(username)
               .SelectMany(c => c.Tags.Select(t => t.TagId))
               .ToList();
        }

        private bool IsValid(string name, string description, string tags, string type)
        {
            if (name == null || description == null || tags == null || type == null)
            {
                return false;
            }

            return true;
        }
    }
}