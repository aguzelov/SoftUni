using System.Collections.Generic;

namespace Chushka.App.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public bool IsDeleted { get; set; }
    }
}