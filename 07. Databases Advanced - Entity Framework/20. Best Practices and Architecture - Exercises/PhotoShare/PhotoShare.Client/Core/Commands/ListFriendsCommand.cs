namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Services.Contracts;
    using System.Text;

    public class ListFriendsCommand : ICommand
    {
        private readonly IFriendshipService friendshipService;

        public ListFriendsCommand(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        // PrintFriendsList <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            var friendsUsername = friendshipService.GetAllFriends(username);

            if (friendsUsername.Length == 0)
            {
                return "No friends for this user. :(";
            }

            // TODO prints all friends of user with given username.
            var sb = new StringBuilder();
            sb.AppendLine("Friends:");
            foreach (var friend in friendsUsername)
            {
                sb.AppendLine($"-{friend}");
            }

            return sb.ToString();
        }
    }
}