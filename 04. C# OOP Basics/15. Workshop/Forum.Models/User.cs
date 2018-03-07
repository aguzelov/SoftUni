using System.Collections.Generic;

namespace Forum.Models
{
    public class User
    {
        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
            this.PostIds = new List<int>();
        }
        public User(int id, string username, string password, IEnumerable<int> postIds):
            this(id, username,password)
        {
            PostIds = new List<int>(postIds);
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<int> PostIds { get; set; }
    }
}