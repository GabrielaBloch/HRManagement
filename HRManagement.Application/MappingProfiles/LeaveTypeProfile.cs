using AutoMapper;
using HRManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRmanagementDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile :  Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDetailsDto, LeaveType>().ReverseMap() ;
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}
