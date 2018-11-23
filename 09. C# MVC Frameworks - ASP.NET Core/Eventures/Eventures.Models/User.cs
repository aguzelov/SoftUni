using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Eventures.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UniqueCitizenNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}