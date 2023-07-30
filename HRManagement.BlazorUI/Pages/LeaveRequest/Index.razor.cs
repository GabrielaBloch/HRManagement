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
using HRManagement.BlazorUI.Contracts;

namespace HRManagement.BlazorUI.Pages.LeaveRequest
{
    public partial class Index
    {
        [Inject] ILeaveRequestServices leaveRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public AdminLeaveRequestViewVM Model { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Model = await leaveRequestService.GetAdminLeaveRequestList();
        }

        void GoToDetails(int id)
        {
            NavigationManager.NavigateTo($"/leaverequests/details/{id}");
        }
    }
}