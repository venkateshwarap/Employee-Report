using employee_report.api.iservice;
using Employee_Report.API.IService;
using Employee_Report.API.Service;
using Employee_Report.Model.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EatrackingContext>();
builder.Services.AddTransient<IPOCService, POCService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ISkillsService, SkillsService>();
builder.Services.AddTransient<IInterviewService, InterviewService>();
builder.Services.AddScoped<IEACouncilService, EACouncilService>();
builder.Services.AddScoped<ICertificationService, CertificationService>();
builder.Services.AddScoped<ILearningService, LearningService>();
builder.Services.AddScoped<IEmployeeLearningService, EmployeeLearningService>();
builder.Services.AddScoped<IEmployeeTrainingService, EmployeeTrainingService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddTransient<IRoleService, RoleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
