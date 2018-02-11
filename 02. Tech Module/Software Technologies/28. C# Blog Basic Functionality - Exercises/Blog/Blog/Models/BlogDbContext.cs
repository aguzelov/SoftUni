﻿

namespace Blog.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using System.Data.Entity;
    
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }
    }
}