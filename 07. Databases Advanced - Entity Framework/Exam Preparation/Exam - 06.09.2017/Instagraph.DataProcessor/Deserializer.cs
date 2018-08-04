using Instagraph.Data;
using Instagraph.DataProcessor.Models.Import;
using Instagraph.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        private const string SUCCESSFULLY_IMPORTED = "Successfully imported {0} {1}.";
        private const string SUCCESSFULLY_IMPORTED_FOLLOWER = "Successfully imported Follower {0} to User {1}.";
        private const string ERROR_MESSAGE = "Error: Invalid data.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<PictureImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var pictures = new List<Picture>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) ||
                    pictures.Any(p => p.Path.Equals(dto.Path, StringComparison.OrdinalIgnoreCase)))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Picture picture = new Picture
                {
                    Path = dto.Path,
                    Size = dto.Size
                };

                pictures.Add(picture);
                sb.AppendLine(String.Format(SUCCESSFULLY_IMPORTED, nameof(Picture), picture.Path));
            }

            context.Pictures.AddRange(pictures);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var users = new List<User>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var picture = context.Pictures
                    .SingleOrDefault(p => p.Path.Equals(dto.ProfilePicture, StringComparison.OrdinalIgnoreCase));

                if (picture == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var user = new User
                {
                    Username = dto.Username,
                    Password = dto.Password,
                    ProfilePicture = picture
                };

                users.Add(user);
                sb.AppendLine(String.Format(SUCCESSFULLY_IMPORTED, nameof(User), user.Username));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<UserFollowerImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var usersFollowers = new List<UserFollower>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var user = context.Users
                    .FirstOrDefault(u => u.Username == dto.User);

                if (user == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var follower = context.Users
                    .FirstOrDefault(u => u.Username == dto.Follower);

                if (follower == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var isDuplicateEntity = usersFollowers
                    .Any(uf => uf.UserId == user.Id && uf.FollowerId == follower.Id);

                if (isDuplicateEntity)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var userFollower = new UserFollower
                {
                    UserId = user.Id,
                    FollowerId = follower.Id
                };

                usersFollowers.Add(userFollower);

                sb.AppendLine(String.Format(SUCCESSFULLY_IMPORTED_FOLLOWER, follower.Username, user.Username));
            }

            var result = sb.ToString();

            context.UsersFollowers.AddRange(usersFollowers);
            context.SaveChanges();

            return result;
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(PostImportDto[]), new XmlRootAttribute("posts"));

            var dtos = (PostImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var posts = new List<Post>();
            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var user = context.Users
                .SingleOrDefault(u => u.Username.Equals(dto.User, StringComparison.OrdinalIgnoreCase));
                if (user == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var picture = context.Pictures
                .SingleOrDefault(p => p.Path.Equals(dto.Picture, StringComparison.OrdinalIgnoreCase));
                if (picture == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var post = new Post
                {
                    Caption = dto.Caption,
                    UserId = user.Id,
                    PictureId = picture.Id
                };

                posts.Add(post);

                sb.AppendLine(String.Format(SUCCESSFULLY_IMPORTED, nameof(Post), post.Caption));
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CommentImportDto[]), new XmlRootAttribute("comments"));
            var dtos = (CommentImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();
            var comments = new List<Comment>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var user = context.Users
                .SingleOrDefault(u => u.Username.Equals(dto.User, StringComparison.OrdinalIgnoreCase));
                if (user == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var post = context.Posts
                .SingleOrDefault(p => p.Id == dto.Post.Id);
                if (post == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var comment = new Comment
                {
                    Content = dto.Content,
                    UserId = user.Id,
                    PostId = post.Id
                };

                comments.Add(comment);
                sb.AppendLine(String.Format(SUCCESSFULLY_IMPORTED, nameof(Comment), comment.Content));
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}