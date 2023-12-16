using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.Common
{
  public class CreateLeaveTypeDto
  {
    public string? Name { get; set; }
    public int DefaultDays { get; set; }
  }
}