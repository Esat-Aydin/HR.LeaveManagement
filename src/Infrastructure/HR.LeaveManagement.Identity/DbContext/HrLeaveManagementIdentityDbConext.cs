using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Identity.DbContext
{
    public class HrLeaveManagementIdentityDbConext : IdentityDbContext<ApplicationUser>
    {
        public HrLeaveManagementIdentityDbConext(DbContextOptions<HrLeaveManagementIdentityDbConext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagementIdentityDbConext).Assembly);
            
        }
    }
}