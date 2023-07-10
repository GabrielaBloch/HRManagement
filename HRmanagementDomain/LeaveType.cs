using HRmanagementDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRmanagementDomain
{
    public class LeaveType: BaseEntity
    {
        
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
