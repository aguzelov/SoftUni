namespace Forum.App.Models.Commands
{
    using Forum.App.Contracts;
    using System;

    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            string replyContent = args[0];
            if (string.IsNullOrWhiteSpace(replyContent) || string.IsNullOrEmpty(replyContent))
            {
                throw new ArgumentException("Reply cannot be empty!");
            }

            int postId = int.Parse(args[1]);
            int userId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyContent, userId);

            return this.session.Back();
        }
    }
}