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
    public partial class Details
    {
        [Inject] ILeaveRequestServices leaveRequestService { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        [Parameter] public int id { get; set; }

        string ClassName;
        string HeadingText;

        public LeaveRequestVM Model { get; private set; } = new LeaveRequestVM();

        protected override async Task OnParametersSetAsync()
        {
            Model = await leaveRequestService.GetLeaveRequest(id);
        }

        protected override async Task OnInitializedAsync()
        {
            if (Model.Approved == null)
            {
                ClassName = "warning";
                HeadingText = "Pending Approval";
            }
            else if (Model.Approved == true)
            {
                ClassName = "success";
                HeadingText = "Approved";
            }
            else
            {
                ClassName = "danger";
                HeadingText = "Rejected";
            }
        }

        async Task ChangeApproval(bool approvalStatus)
        {
            await leaveRequestService.ApproveLeaveRequest(id, approvalStatus);
            navigationManager.NavigateTo("/leaverequests/");
        }
    }
}