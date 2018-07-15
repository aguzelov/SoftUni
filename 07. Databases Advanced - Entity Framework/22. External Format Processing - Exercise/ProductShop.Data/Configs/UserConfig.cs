using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShop.Models;

namespace ProductShop.Data.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.LastName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Age)
                .IsRequired(false)
                .IsUnicode(true);
        }
    }
}