using AutoMapper;
using Instagraph.Data;
using Instagraph.DataProcessor;
using System;
using System.IO;
using System.Text;

namespace Instagraph.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(options => options.AddProfile<InstagraphProfile>());

            Console.WriteLine(ResetDatabase());

            Console.WriteLine(ImportData());

            ExportData();
        }

        private static string ImportData()
        {
            StringBuilder sb = new StringBuilder();

            using (var context = new InstagraphContext())
            {
                var baseDir = "../../../";

                string picturesJson = File.ReadAllText(baseDir + "files/input/pictures.json");

                sb.AppendLine(Deserializer.ImportPictures(context, picturesJson));

                string usersJson = File.ReadAllText(baseDir + "files/input/users.json");

                sb.AppendLine(Deserializer.ImportUsers(context, usersJson));

                string followersJson = File.ReadAllText(baseDir + "files/input/users_followers.json");

                sb.AppendLine(Deserializer.ImportFollowers(context, followersJson));

                string postsXml = File.ReadAllText(baseDir + "files/input/posts.xml");

                sb.AppendLine(Deserializer.ImportPosts(context, postsXml));

                string commentsXml = File.ReadAllText(baseDir + "files/input/comments.xml");

                sb.AppendLine(Deserializer.ImportComments(context, commentsXml));
            }

            string result = sb.ToString().Trim();
            return result;
        }

        private static void ExportData()
        {
            using (var context = new InstagraphContext())
            {
                var baseDir = "../../../";

                string uncommentedPostsOutput = Serializer.ExportUncommentedPosts(context);

                File.WriteAllText(baseDir + "files/output/UncommentedPosts.json", uncommentedPostsOutput);

                string usersOutput = Serializer.ExportPopularUsers(context);

                File.WriteAllText(baseDir + "files/output/PopularUsers.json", usersOutput);

                string commentsOutput = Serializer.ExportCommentsOnPosts(context);

                File.WriteAllText(baseDir + "files/output/CommentsOnPosts.xml", commentsOutput);
            }
        }

        private static string ResetDatabase()
        {
            using (var context = new InstagraphContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return $"Database reset succsessfully.";
        }
    }
}