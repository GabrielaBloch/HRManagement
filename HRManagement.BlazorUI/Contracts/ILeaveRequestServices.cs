using HRManagement.BlazorUI.Models.LeaveRequests;
using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Contracts
{
    public interface ILeaveRequestServices
    {
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests();
        Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest);
        Task<LeaveRequestVM> GetLeaveRequest(int id);
        Task DeleteLeaveRequest(int id);
        Task ApproveLeaveRequest(int id, bool approved);
    }
}
