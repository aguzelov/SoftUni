using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public class Order
    {
        public Order()
        {
            this.DateOfCreating = DateTime.UtcNow;
            this.Products = new HashSet<OrderProducts>();
        }

        public int Id { get; set; }

        public DateTime DateOfCreating { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderProducts> Products { get; set; }
    }
}