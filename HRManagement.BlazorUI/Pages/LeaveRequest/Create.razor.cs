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
using HRManagement.BlazorUI.Models;
using HRManagement.BlazorUI.Pages.LeaveTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using HRManagement.BlazorUI.Models.LeaveRequests;
using HRManagement.BlazorUI.Services;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Models.LeaveTypes;

namespace HRManagement.BlazorUI.Pages.LeaveRequest
{
    public partial class Create
    {
        [Inject] ILeaveTypeServices leaveTypeService { get; set; }
        [Inject] ILeaveRequestServices leaveRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        LeaveRequestVM LeaveRequest { get; set; } = new LeaveRequestVM();
        List<LeaveTypeVM> leaveTypeVMs { get; set; } = new List<LeaveTypeVM>();

        protected override async Task OnInitializedAsync()
        {
            leaveTypeVMs = await leaveTypeService.GetLeaveTypes();
        }

        private async Task HandleValidSubmit()
        {
            // Perform form submission here
            await leaveRequestService.CreateLeaveRequest(LeaveRequest);
            NavigationManager.NavigateTo("/leaverequests/");
        }
    }
}