using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public  class LeaveTypeDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
        public DateTime? DataCreated { get; set; }
        public DateTime? DataModified { get; set; }

    }
}
