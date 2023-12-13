using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
      CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
      CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
      CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
      CreateMap<BaseDomainEntity, BaseDto>().ReverseMap();
    }
  }
}