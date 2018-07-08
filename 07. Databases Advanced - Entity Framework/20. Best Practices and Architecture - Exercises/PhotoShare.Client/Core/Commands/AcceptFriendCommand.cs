namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;

    [CredentialAttribute(true)]
    public class AcceptFriendCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IFriendshipService friendshipService;

        public AcceptFriendCommand(IUserService userService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.friendshipService = friendshipService;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string[] data)
        {
            string usernameToAccept = data[0];
            string usernameToBeAccepted = data[1];

            User user = null;
            User friend = null;

            try
            {
                user = userService.GetUserByUsername(usernameToAccept);
                friend = userService.GetUserByUsername(usernameToBeAccepted);
            }
            catch (ArgumentException ae)
            {
                string username = ae.Message.Split(" ")[1];
                throw new ArgumentException($"{username} not found!");
            }

            friendshipService.AddFriendTo(user, friend);

            return $"{user.Username} accepted {friend.Username} as a friend";
        }
    }
}