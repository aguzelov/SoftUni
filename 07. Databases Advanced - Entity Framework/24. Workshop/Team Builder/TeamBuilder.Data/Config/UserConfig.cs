using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Username)
                .IsUnique(true);

            builder.Property(e => e.Username)
                .IsRequired(true)
                .HasMaxLength(25);

            builder.Property(e => e.FirstName)
                .HasMaxLength(25);

            builder.Property(e => e.LastName)
                .HasMaxLength(25);

            builder.Property(e => e.Password)
                .IsRequired(true)
                .HasMaxLength(30);
        }
    }
}