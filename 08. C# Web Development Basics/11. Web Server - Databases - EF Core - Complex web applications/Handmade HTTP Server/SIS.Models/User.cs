using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public class User
    {
        public User()
        {
            this.DateOfRegistration = DateTime.UtcNow;
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}