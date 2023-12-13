using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTOs.Common;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
  public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
  {
    public int Id { get; set; }
  }
}