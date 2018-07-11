namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    [CredentialAttribute(true)]
    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IFriendshipService friendshipService;

        public AddFriendCommand(IUserService userService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.friendshipService = friendshipService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            string usernameToAdd = data[0];
            string usernameToByAdded = data[1];

            User user = null;
            User friend = null;

            user = userService.GetUserByUsername(usernameToAdd);
            friend = userService.GetUserByUsername(usernameToByAdded);

            friendshipService.AddFriendTo(user, friend);

            return $"Friend {friend.Username} added to {user.Username}";
        }
    }
}