using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            var matches = _dbContext.LeaveTypes.Any(lt => lt.Name == name);
            return await Task.FromResult(!matches);
        }
    }
}