using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Panda.Models
{
    public class User : IdentityUser<string>
    {
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}