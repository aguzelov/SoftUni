using FDMC.Models;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Data
{
    public class FDMCContext : DbContext
    {
        public FDMCContext(DbContextOptions options) : base(options)
        {
        }

        public FDMCContext()
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}