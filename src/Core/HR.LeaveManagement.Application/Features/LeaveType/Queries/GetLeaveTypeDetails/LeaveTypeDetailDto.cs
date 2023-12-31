using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Common;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class LeaveTypeDetailsDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime? DateModified { get; set; }
    public string? ModifiedBy { get; set; }
}
