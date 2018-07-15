using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShop.Models;

namespace ProductShop.Data.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.BuyerId)
                .IsRequired(false);

            builder.Property(e => e.SellerId)
                .IsRequired(true);

            builder.HasOne(p => p.Buyer)
                .WithMany(u => u.Bought)
                .HasForeignKey(p => p.BuyerId);

            builder.HasOne(p => p.Seller)
                .WithMany(u => u.Sold)
                .HasForeignKey(p => p.SellerId);
        }
    }
}