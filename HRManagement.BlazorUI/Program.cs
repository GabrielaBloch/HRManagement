using HRManagement.BlazorUI;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Services;
using HRManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7218"));

builder.Services.AddScoped<ILeaveTypeServices, LeaveTypeService>();
builder.Services.AddScoped<ILeaveRequestServices, LeaveRequestService>();
builder.Services.AddScoped<ILeaveAllocationServices, LeaveAllocationService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
await builder.Build().RunAsync();
