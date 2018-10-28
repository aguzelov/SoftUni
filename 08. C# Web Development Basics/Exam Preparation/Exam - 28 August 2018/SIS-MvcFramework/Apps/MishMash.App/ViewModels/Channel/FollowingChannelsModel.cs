using System.Collections.Generic;

namespace MishMash.App.ViewModels
{
    public class FollowingChannelsModel
    {
        public IEnumerable<ChannelModel> FollowedChannels { get; set; }
    }
}