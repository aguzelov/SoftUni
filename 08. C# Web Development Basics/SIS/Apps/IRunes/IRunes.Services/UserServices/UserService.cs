using IRunes.Data;
using IRunes.Models;
using System.Linq;

namespace IRunes.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRunesContext _context;

        public UserService(IRunesContext context)
        {
            this._context = context;
        }

        public User Get(string username)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Username == username);

            return user;
        }

        public void Add(string username, string password, string email)
        {
            var user = new User()
            {
                Username = username,
                Password = password,
                Email = email
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