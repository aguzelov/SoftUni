namespace Forum.App.UserInterface.ViewModels
{
    using Forum.App.Services;
    using Forum.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public PostViewModel()
        {
            this.Content = new List<string>();
        }

        public PostViewModel(Post post)
        {
            this.PostId = post.Id;
            this.Title = post.Title;
            this.Content = this.GetLines(post.Content);
            this.Author = UserService.GetUser(post.AuthorId).Username;
            this.Category = PostService.GetCategory(post.CategoryId).Name;
            this.Replies = PostService.GetPostReplies(post.Id);
        }

        private IList<string> GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            List<string> lines = new List<string>();

            for (int counter = 0; counter < content.Length; counter += LINE_LENGHT)
            {
                char[] row = contentChars.Skip(counter).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }
    }
}