using Forum.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Forum.Data
{
    public class DataMapper
    {
        private const string DATA_PATH = "../data/";

        private const string CONFIG_PATH = "config.ini";

        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        private static void EnsureConfigFile(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                File.WriteAllText(configFilePath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configFilePath)
        {
            EnsureConfigFile(configFilePath);

            var contents = ReadLines(configFilePath);

            var config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            var dataLines = ReadLines(config["categories"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var name = args[1];
                var postIds = args[2]
                    .Split(',', System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Category category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (var category in categories)
            {
                const string categoryFormat = "{0};{1};{2}";
                string line = string.Format(categoryFormat,
                    category.Id,
                    category.Name,
                    string.Join(",", category.Posts)
                );

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var username = args[1];
                var password = args[2];

                int[] postIds = null;
                if (args.Length < 4)
                {
                    postIds = new int[0];
                }
                else
                {
                    postIds = args[3]
                    .Split(',', System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                }

                User user = new User(id, username, password, postIds);
                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (var user in users)
            {
                const string categoryFormat = "{0};{1};{2};{3}";
                string line = string.Format(categoryFormat,
                    user.Id,
                    user.Username,
                    user.Password,
                    string.Join(",", user.PostIds)
                );

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var title = args[1];
                var content = args[2];
                var categoryId = int.Parse(args[3]);
                var authorId = int.Parse(args[4]);

                var replyIds = new int[0];
                if (args.Length < 6)
                {
                    replyIds = new int[0];
                }
                else
                {
                    replyIds = args[5]
                    .Split(',', System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                }

                Post post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (var post in posts)
            {
                const string categoryFormat = "{0};{1};{2};{3};{4};{5}";
                string line = string.Format(categoryFormat,
                    post.Id,
                    post.Title,
                    post.Content,
                    post.CategoryId,
                    post.AuthorId,
                    string.Join(",", post.ReplyIds)
                );

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var content = args[1];
                var authorId = int.Parse(args[2]);
                var postId = int.Parse(args[3]);

                Reply reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (var reply in replies)
            {
                const string categoryFormat = "{0};{1};{2};{3}";
                string line = string.Format(categoryFormat,
                    reply.Id,
                    reply.Content,
                    reply.AuthorId,
                    reply.PostId
                );

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}