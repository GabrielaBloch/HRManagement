using AutoMapper;
using HRManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HRManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HRmanagementDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.MappingProfiles
{
    public class LeaveAllocationsProfile : Profile
    {
        public LeaveAllocationsProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
