using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext
{
    public class HrDatabaseContext : DbContext
    {
        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options){}

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);

            // Example code below. Normally I would use the `HasData` method to seed data to the database.
            // Now the LeaveType data is beein seeded through the `LeaveTypeConfiguration` class.

            // modelBuilder.Entity<LeaveType>().HasData(
            //     new LeaveType
            //     {
            //         Id = 1,
            //         DefaultDays = 15,
            //         Name = "Vacation"
            //     }
            // );

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // The code it's iterating over all tracked entities of type `BaseDomainEntity` that have changes.
            // For each entity, it checks the state of the entity:
            // - If the entity is in the `Added` state (new entity)`DateCreated` and `DateModified`to current date.
            // - If the entity is in the `Modified` state (existing entity)updates `DateModified` to current date.
            // This is a common pattern used to automatically manage timestamps
            // for create and update operations in a database.

            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        entry.Entity.DateModified = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}