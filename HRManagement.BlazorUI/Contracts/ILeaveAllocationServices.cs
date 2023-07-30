using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Contracts
{
    public interface ILeaveAllocationServices
    {
        Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId);
    }
}
