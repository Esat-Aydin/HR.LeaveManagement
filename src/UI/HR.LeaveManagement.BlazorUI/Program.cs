using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HR.LeaveManagement.BlazorUI;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using HR.LeaveManagement.BlazorUI.Providers;
using HR.LeaveManagement.BlazorUI.Handlers;
using Blazored.Toast;
using HR.LeaveManagement.BlazorUI.MappingProfiles;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client =>
    client.BaseAddress = new Uri("https://localhost:7274")).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();
    // client.BaseAddress = new Uri("http://localhost:5006")).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();



builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ApiAuthenticationStateProvider>(); 
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticateService>();

await builder.Build().RunAsync();
