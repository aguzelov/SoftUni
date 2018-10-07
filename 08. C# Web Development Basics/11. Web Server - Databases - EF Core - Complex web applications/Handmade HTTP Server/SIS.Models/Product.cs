using System.Collections.Generic;

namespace SIS.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<OrderProducts>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public virtual ICollection<OrderProducts> Orders { get; set; }
    }
}