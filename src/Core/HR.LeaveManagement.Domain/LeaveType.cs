using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Domain
{
  public class LeaveType : BaseDomainEntity
  {
    public string? Name { get; set; }
    public int DefaultDays { get; set; }
  }
}