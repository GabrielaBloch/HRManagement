using Blazored.LocalStorage;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationServices
    {
        public LeaveAllocationService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
        }
    }
}
