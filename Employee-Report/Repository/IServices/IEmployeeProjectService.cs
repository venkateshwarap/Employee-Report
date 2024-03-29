﻿using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeeProjectService
    {
        Task<Response> GetEmployeeProjectDetails();
        Task<Response> AddEmployeeProject(EmployeeProject project);
        Task<Response> GetAdminProjectDetails();
        Task<Response> CreateAdminProject(Project project);
        Task<Response> GetEmployeeProjectDetailsById(string Id);
    }
}
