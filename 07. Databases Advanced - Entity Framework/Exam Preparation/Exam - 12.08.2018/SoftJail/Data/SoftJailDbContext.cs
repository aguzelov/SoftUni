namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Prisoner>()
                .HasOne(p => p.Cell)
                .WithMany(c => c.Prisoners)
                .HasForeignKey(p => p.CellId);

            builder.Entity<Cell>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Cells)
                .HasForeignKey(c => c.DepartmentId);

            builder.Entity<Mail>()
                .HasOne(m => m.Prisoner)
                .WithMany(p => p.Mails)
                .HasForeignKey(m => m.PrisonerId);

            builder.Entity<OfficerPrisoner>()
                .HasKey(e => new { e.PrisonerId, e.OfficerId });

            builder.Entity<OfficerPrisoner>()
                .HasOne(op => op.Prisoner)
                .WithMany(p => p.PrisonerOfficers)
                .HasForeignKey(op => op.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OfficerPrisoner>()
                .HasOne(op => op.Officer)
                .WithMany(o => o.OfficerPrisoners)
                .HasForeignKey(op => op.OfficerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}