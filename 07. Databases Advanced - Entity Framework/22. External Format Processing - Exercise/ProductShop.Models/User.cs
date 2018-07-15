using System.Collections.Generic;

namespace ProductShop.Models
{
    public class User
    {
        public int Id { get; set; }

        public int? Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Product> Bought { get; set; } = new List<Product>();

        public ICollection<Product> Sold { get; set; } = new List<Product>();
    }
}