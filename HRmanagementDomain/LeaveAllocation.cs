using HRmanagementDomain.Common;

namespace HRmanagementDomain
{
    public class LeaveAllocation: BaseEntity
    {
        public int Id { get; set; }
        public string NumberOfDays { get; set; } = string.Empty;
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Peroid { get; set; }
    }

}
