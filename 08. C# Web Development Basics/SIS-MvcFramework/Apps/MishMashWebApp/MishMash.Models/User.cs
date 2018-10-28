using MishMash.Models.Enums;
using System.Collections.Generic;

namespace MishMash.Models
{
    public class User
    {
        public User()
        {
            this.FollowedChannels = new HashSet<UserInChannel>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<UserInChannel> FollowedChannels { get; set; }
    }
}