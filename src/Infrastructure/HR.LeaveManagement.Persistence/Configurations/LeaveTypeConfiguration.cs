using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
            new LeaveType
            {
                Id = 1,
                DefaultDays = 15,
                Name = "Vacation"
            }
            );

            // Here I can place code to restrict the database table. I can give it validation rules, etc.
            // Example:
            // builder.Property(q => q.Name)
            //     .IsRequired()
            //     .HasMaxLength(50);
        }
    }
}