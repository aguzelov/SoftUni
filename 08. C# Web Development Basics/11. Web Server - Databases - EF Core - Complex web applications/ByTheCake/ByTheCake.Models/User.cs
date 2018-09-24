using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ByTheCake.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfRegistration { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}