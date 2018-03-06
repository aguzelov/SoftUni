namespace Forum.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category(int id, string name, IEnumerable<int> posts)
        {
            this.Id = id;
            this.Name = name;
            this.Posts = new List<int>(posts);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> Posts { get; set; }
    }
}