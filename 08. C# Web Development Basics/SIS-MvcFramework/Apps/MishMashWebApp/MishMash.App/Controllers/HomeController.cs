using MishMash.App.ViewModels;
using MishMash.Data;
using MishMash.Services;
using SIS.HTTP.Responses;
using System.Linq;

namespace MishMash.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly MishMashContext context;
        private readonly IUserService userService;
        private readonly IChannelService channelService;

        public HomeController(MishMashContext context, IUserService userService, IChannelService channelService)
        {
            this.context = context;
            this.userService = userService;
            this.channelService = channelService;
        }

        public IHttpResponse Index()
        {
            var user = this.userService.GetUser(this.User.Username);
            if (user != null)
            {
                var model = new LoggedInIndexModel();

                model.YourChannels = this.channelService.YourChannels(user.Username)
                    .Select(c => new ChannelModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = c.Type.ToString(),
                        FollowersCount = c.Followers.Count()
                    }).ToList();

                model.SuggestedChannels = this.channelService.SuggestedChannels(user.Username)
                    .Select(c => new ChannelModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = c.Type.ToString(),
                        FollowersCount = c.Followers.Count()
                    }).ToList();

                model.SeeOtherChannels = this.channelService.SeeOtherChannels(user.Username)
                    .Select(c => new ChannelModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = c.Type.ToString(),
                        FollowersCount = c.Followers.Count()
                    }).ToList();

                return this.View("Home/LoggedInIndex", model);
            }
            else
            {
                return this.View();
            }
        }
    }
}