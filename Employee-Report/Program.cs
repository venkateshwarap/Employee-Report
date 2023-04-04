using Employee_Report.Auth;
using Employee_Report.Repository.IServices;
using Employee_Report.Repository.Services;
using Employee_Report.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Syncfusion.Blazor;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<ILearningService, LearningService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ISkillsService, SkillsService>();
builder.Services.AddScoped<IEmployeeLearningService, EmployeeLearningService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ExportService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpClient();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTIxMjA0MEAzMjMwMmUzNDJlMzBMalJWcXpUYTZBY09jeDZqNjQwVGRtK3lBU0dWMWladUU2Vi9XQVNmNFNzPQ==");
ConfigurationHelper.Initialize(builder.Configuration);
using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
{
    var accessor = serviceProvider.GetService<IHttpContextAccessor>();
    Utility.SetHttpContextAccessor(accessor);

}
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
app.UseSession();
app.Use(async delegate (HttpContext Context, Func<Task> Next)
{
    //this throwaway session variable will "prime" the SetString() method
    //to allow it to be called after the response has started
    var TempKey = Guid.NewGuid().ToString(); //create a random key
    Context.Session.Set(TempKey, Array.Empty<byte>()); //set the throwaway session variable
    Context.Session.Remove(TempKey); //remove the throwaway session variable
    await Next(); //continue on with the request
});
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
