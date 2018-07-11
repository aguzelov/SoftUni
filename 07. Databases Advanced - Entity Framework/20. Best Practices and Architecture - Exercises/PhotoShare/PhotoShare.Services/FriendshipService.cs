using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Linq;

namespace PhotoShare.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly PhotoShareContext context;

        public FriendshipService(PhotoShareContext context)
        {
            this.context = context;
        }

        public void AcceptFriend(User user, User friend)
        {
            if (Exist(user.Username, friend.Username))
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }

            if (Exist(friend.Username, user.Username))
            {
                throw new InvalidOperationException($"{friend.Username} has not added {user.Username} as a friend");
            }

            Friendship friendship = new Friendship
            {
                User = user,
                Friend = friend
            };

            context.Friendships.Add(friendship);

            context.SaveChanges();
        }

        public void AddFriendTo(User user, User friend)
        {
            if (Exist(user.Username, friend.Username))
            {
                throw new ArgumentException($"{friend.Username} is already a friend to {user.Username}");
            }

            Friendship friendship = new Friendship
            {
                User = user,
                Friend = friend
            };

            context.Friendships.Add(friendship);

            context.SaveChanges();
        }

        public string[] GetAllFriends(string username)
        {
            var friendsUsername = context.Friendships
                .Include(f => f.User)
                .Include(f => f.Friend)
                .Where(u => u.User.Username == username)
                .Select(f => f.Friend.Username)
                .OrderBy(f => f)
                .ToArray();

            return friendsUsername;
        }

        public bool Exist(string userName, string friendName)
        {
            return context.Friendships.Any(f => f.User.Username == userName && f.Friend.Username == friendName);
        }
    }
}