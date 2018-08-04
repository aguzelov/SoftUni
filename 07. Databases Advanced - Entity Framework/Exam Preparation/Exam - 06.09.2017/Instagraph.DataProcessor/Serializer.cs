using Instagraph.Data;
using Instagraph.DataProcessor.Models.Export;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new UncommentedPostExportDto
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .OrderBy(p => p.Id)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(posts, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Select(c => c.UserId)
                        .Intersect(u.Followers
                            .Select(f => f.FollowerId))
                        .Any()))
                 .Select(u => new PopularUserExportDto
                 {
                     Id = u.Id,
                     Username = u.Username,
                     Followers = u.Followers.Count
                 })
                 .OrderBy(u => u.Id)
                 .ToArray();

            var jsonString = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    u.Username,
                    PostCommentsCount = u.Posts.Select(p => p.Comments.Count).ToArray()
                })
                .Select(u => new CommentsPostExportDto
                {
                    Username = u.Username,
                    MostComments = u.PostCommentsCount.Any()
                        ? u.PostCommentsCount.OrderByDescending(c => c).First()
                        : 0
                })
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CommentsPostExportDto[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }
    }
}