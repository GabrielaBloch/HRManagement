using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
   // public  class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    //{

    //}
    public record GetLeaveTypesDetailsQuery : IRequest<List<LeaveTypeDetailsDto>>;
 

}
