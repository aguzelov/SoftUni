namespace Forum.App.Services
{
    using Forum.App.UserInterface.ViewModels;
    using Forum.Data;
    using Forum.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            Category category = forumData.Categories.Find(c => c.Id == categoryId);

            return category;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();

            var allCategories = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategories;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postID)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postID);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                Reply reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            var postIds = forumData.Categories.First(c => c.Id == categoryId).Posts;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);
            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            var posts = forumData.Posts;
            int postId = posts.Any() ? posts.Last().Id + 1 : 1;

            Category category = EnsureCategory(postView, forumData);

            User author = UserService.GetUser(postView.Author, forumData);

            int authorId = author.Id;
            string content = string.Join("", postView.Content);

            Post post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            postView.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel replyView, int postId)
        {
            bool emptyContent = !replyView.Content.Any();

            if (emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            var replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            User author = UserService.GetUser(replyView.Author, forumData);
            Post post = forumData.Posts.Single(p => p.Id == postId);
            string content = string.Join("", replyView.Content);

            Reply reply = new Reply(replyId, content, author.Id, postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();

            return true;
        }
    }
}