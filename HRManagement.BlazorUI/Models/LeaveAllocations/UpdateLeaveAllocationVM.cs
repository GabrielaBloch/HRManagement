﻿using HRManagement.BlazorUI.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HRManagement.BlazorUI.Models.LeaveAllocations
{
    public class UpdateLeaveAllocationVM
    {
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Enter Valid Number")]
        public int NumberOfDays { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
    }
}
