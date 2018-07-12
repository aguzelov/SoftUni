using Employees.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Data.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.FirstName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.LastName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Salary)
                .IsRequired(true);

            builder.Property(e => e.Birthday)
                .HasColumnType("DATETIME2");

            builder.HasOne(e => e.Manager)
                .WithMany(m => m.ManagerEmployees)
                .HasForeignKey(e => e.ManagerId);
        }
    }
}