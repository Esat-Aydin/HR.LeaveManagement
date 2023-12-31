using HR.LeaveManagement.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
