using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HRManagement.BlazorUI.Pages.LeaveTypes
{
    public partial class Details
    {
        [Inject]
        ILeaveTypeServices _client { get; set; }

        [Parameter]
        public int id { get; set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            leaveType = await _client.GetLeaveTypeDetails(id);
        }
    }
}
