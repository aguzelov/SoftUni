using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.Services
{
    public class UserService : IUserService
    {
        private readonly TeamBuilderContext context;

        public UserService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            this.context.Users.Add(user);

            this.context.SaveChanges();
        }

        public User GetUser(string username)
        {
            if (!IsUserExisting(username))
            {
                return null;
            }

            User user = this.context.Users
                .Where(u => u.Username == username)
                .SingleOrDefault();

            return user;
        }

        public User GetUser(int id)
        {
            User user = this.context.Users.Find(id);

            return user;
        }

        public bool IsUserExisting(string username)
        {
            return this.context.Users.Any(u => u.Username == username);
        }

        public void DeleteUser(User user)
        {
            user.IsDeleted = true;

            this.context.SaveChanges();
        }
    }
}