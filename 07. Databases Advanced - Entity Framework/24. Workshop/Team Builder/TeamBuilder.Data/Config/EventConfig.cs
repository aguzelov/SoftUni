using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Config
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(25)
                .IsUnicode(true);

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.HasOne(e => e.Creator)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}