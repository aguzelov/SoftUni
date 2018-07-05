using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

            builder.Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);

            builder.Property(c => c.StartDate)
                .HasColumnType("DATETIME2");

            builder.Property(c => c.EndDate)
                .HasColumnType("DATETIME2");
        }
    }
}