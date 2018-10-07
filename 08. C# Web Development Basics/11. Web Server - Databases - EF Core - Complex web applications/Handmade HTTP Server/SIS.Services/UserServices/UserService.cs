using SIS.Data;
using SIS.Models;
using System.Linq;

namespace SIS.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ByTheCakeContext _context;

        public UserService(ByTheCakeContext context)
        {
            this._context = context;
        }

        public User Get(string username)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Username == username);

            return user;
        }

        public void Add(string name, string username, string password)
        {
            var user = new User()
            {
                Name = name,
                Username = username,
                Password = password
            };

            this.Add(user);
        }

        public void Add(User user)
        {
            this._context.Users.Add(user);
            this._context.SaveChanges();
        }

        public bool Exsist(string username, string password)
        {
            var exsist = this._context.Users
                .Any(user => user.Username == username && user.Password == password);

            return exsist;
        }
    }
}