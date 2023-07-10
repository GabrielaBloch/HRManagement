using HRmanagementDomain;

namespace HRManagement.Application.Contracts.Persistance
{
    public interface ILeaveTypeRepository : IGenericRepositor<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }


}
