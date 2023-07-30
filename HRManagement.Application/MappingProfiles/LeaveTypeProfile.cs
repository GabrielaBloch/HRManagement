﻿using AutoMapper;
using HRManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HRManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
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
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap() ;
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
