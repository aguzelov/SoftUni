using MishMash.App.ViewModels;
using MishMash.App.ViewModels.Channel;
using MishMash.Data;
using MishMash.Services;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System.Linq;

namespace MishMash.App.Controllers
{
    public class ChannelsController : BaseController
    {
        private readonly MishMashContext context;
        private readonly IUserService userService;
        private readonly IChannelService channelService;

        public ChannelsController(MishMashContext context, IUserService userService, IChannelService channelService)
        {
            this.context = context;
            this.userService = userService;
            this.channelService = channelService;
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("User")]
        public IHttpResponse Create(CreateChannelModel model)
        {
            var user = this.userService.GetUser(this.User.Username);
            if (user == null)
            {
                return this.Redirect("/");
            }

            if (!this.channelService.AddChannel(
                model.Name,
                model.Description,
                model.Tags,
                model.Type,
                user))
            {
                return this.BadRequestErrorWithView("Invalid channel data.");
            }

            return this.Redirect("/");
        }

        [Authorize("User")]
        public IHttpResponse Followed()
        {
            var user = this.userService.GetUser(this.User.Username);
            if (user == null)
            {
                return this.Redirect("/");
            }
            var model = new FollowingChannelsModel
            {
                FollowedChannels = this.channelService.FollowedChannels(user.Username)
                .Select(c => new ChannelModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Type = c.Type.ToString(),
                    FollowersCount = c.Followers.Count()
                })
                .ToList()
            };

            return this.View("Channels/Followed", model);
        }

        [Authorize("User")]
        public IHttpResponse Follow(int id)
        {
            var user = this.userService.GetUser(this.User.Username);
            if (!this.channelService.Follow(user.Id, id))
            {
                return this.BadRequestErrorWithView("Invalid channel data.");
            }

            return this.Redirect("/");
        }

        [Authorize("User")]
        public IHttpResponse Unfollow(int id)
        {
            var user = this.userService.GetUser(this.User.Username);

            this.channelService.Unfollow(user.Id, id);

            return this.Redirect("/Channels/Followed");
        }

        [Authorize("User")]
        public IHttpResponse Details(int id)
        {
            var channel = this.context.Channels.Where(c => c.Id == id)
                .Select(c => new ChannelDetails
                {
                    Name = c.Name,
                    Type = c.Type.ToString(),
                    FollowersCount = c.Followers.Count(),
                    Description = c.Description,
                    Tags = c.Tags.Select(t => t.Tag.Name)
                }).FirstOrDefault();

            if (channel == null)
            {
                return this.BadRequestErrorWithView("Invalid channel id.");
            }

            return this.View(channel);
        }
    }
}