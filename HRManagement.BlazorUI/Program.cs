using Blazored.LocalStorage;
using HRManagement.BlazorUI;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Handlers;
using HRManagement.BlazorUI.Providers;
using HRManagement.BlazorUI.Services;
using HRManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7218"))
    .AddHttpMessageHandler<JwtAuthorizationMessageHandler>();



builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthStateProvider>();
builder.Services.AddScoped<ILeaveTypeServices, LeaveTypeService>();
builder.Services.AddScoped<ILeaveRequestServices, LeaveRequestService>();
builder.Services.AddScoped<ILeaveAllocationServices, LeaveAllocationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();    
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
await builder.Build().RunAsync();
