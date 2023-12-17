using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    // Sure, a record in C# is a simplified class that is primarily used to store data.
    // Unlike a class, a record provides built-in functionality for comparing instances based on their values
    // instead of their references.
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
}
