using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using HRManagement.BlazorUI;
using HRManagement.BlazorUI.Shared;
using HRManagement.BlazorUI.Models.LeaveTypes;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Services;

namespace HRManagement.BlazorUI.Pages.LeaveTypes
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILeaveTypeServices LeaveTypeService { get; set; }
        [Inject]
        public ILeaveAllocationServices leaveAllocationServices { get; set; }

        public List<LeaveTypeVM> LeaveTypes { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateLeaveType()
        {
            NavigationManager.NavigateTo("/leavetypes/create/");
        }

        protected void AllocateLeaveType(int id)
        {
            leaveAllocationServices.CreateLeaveAllocations(id);
        }

        protected void EditLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
        }

        protected void DetailsLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/details/{id}");
        }

        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            LeaveTypes = await LeaveTypeService.GetLeaveTypes();
        }
    }
}