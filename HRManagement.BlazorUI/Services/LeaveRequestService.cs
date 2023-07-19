using Blazored.LocalStorage;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestServices
    {
        public LeaveRequestService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
        }
    }
}
