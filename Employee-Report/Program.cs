using Employee_Report.Auth;
using Employee_Report.Repository.IServices;
using Employee_Report.Repository.Services;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IPowerHouseService, PowerHouseService>();
builder.Services.AddScoped<ICertificationsService, CertificationsService>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();
builder.Services.AddScoped<IEmployeeSkillService, EmployeeSkillService>();
builder.Services.AddScoped<IEmployeePocService, EmployeePocService>();
builder.Services.AddScoped<IGetRoleService, GetRoleService>();
builder.Services.AddScoped<IIntellectualPropertyService, IntellectualPropertyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpClient();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTIxMjA0MEAzMjMwMmUzNDJlMzBMalJWcXpUYTZBY09jeDZqNjQwVGRtK3lBU0dWMWladUU2Vi9XQVNmNFNzPQ==");
ConfigurationHelper.Initialize(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
