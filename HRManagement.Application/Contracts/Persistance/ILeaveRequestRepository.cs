using HRmanagementDomain;

namespace HRManagement.Application.Contracts.Persistance
{
    public interface ILeaveRequestRepository : IGenericRepositor<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);

    }


}
