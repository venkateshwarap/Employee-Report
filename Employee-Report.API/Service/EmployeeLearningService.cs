﻿using Employee_Report.Model.Models;
using Employee_Report.API.IService;
using Employee_Report.API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.API.Service
{
    public class EmployeeLearningService : IEmployeeLearningService
    {

        private readonly EmployeeInfoContext _context;
        public EmployeeLearningService(EmployeeInfoContext context)
        {
            _context = context;
        }
        public Response GetEmployeelearningDetails()
        {

            try
            {
                var result = from employelearning in _context.EmployeeLearnings
                             join learnig in _context.Learnings on employelearning.LearningId equals learnig.SkillId into Details
                             from m in Details.DefaultIfEmpty()
                             select new
                             {
                                 EmpId = employelearning.EmpId,
                                 EndDate = (employelearning.EndDate.HasValue)?(employelearning.EndDate): employelearning.EndDate.GetValueOrDefault(),
                                 StartDate = (employelearning.StartDate.HasValue) ? (employelearning.StartDate) : employelearning.EndDate.GetValueOrDefault(),
                                 Duration = (employelearning.EndDate - employelearning.StartDate)!.HasValue ? (employelearning.EndDate - employelearning!.StartDate)!.Value.TotalDays : 0,
                                 Name = m.Name!=null? m.Name:String.Empty,
                                 Path = m.Path != null? m.Path:String.Empty,
                                 HoursOfLearning = m.HoursOfLearning != null ? m.HoursOfLearning :0,
                             };

                var employee_res = from employelearning in result
                             join employee in _context.Employees on employelearning.EmpId equals employee.Id into Details 
                from m in Details.DefaultIfEmpty()
                select new
                {
                    FirstName = m!.FirstName,
                    LastName = m!.LastName,
                    EmpId = employelearning.EmpId,
                    EndDate = employelearning.EndDate,
                    StartDate = employelearning.StartDate,
                    Duration = employelearning.Duration,
                    Name = employelearning.Name,
                    Path = employelearning.Path,
                    HoursOfLearning = employelearning.HoursOfLearning,
                };
                if (employee_res.Count() > 0)
                {
                    return APIUtility.BindResponse(employee_res, true);
                }
                return APIUtility.BindResponse(null!, false);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<Response> GetEmployeeLearningbyEmpId(string empId)
        {

            try
            {
                var employee = await _context.Employees.Where(x=>x.Id== empId).FirstOrDefaultAsync();
                var result = from employelearning in _context.EmployeeLearnings
                              join learnig in _context.Learnings on employelearning.LearningId equals learnig.SkillId  into Details where employelearning.EmpId == empId
                             from m in Details.DefaultIfEmpty()
                             select new
                             {
                                 EmpId = employelearning.EmpId,
                                 EndDate = employelearning.EndDate,
                                 StartDate = employelearning.StartDate,
                                 Duration = (employelearning.EndDate - employelearning.StartDate)!.Value.TotalDays,
                                 LearningName = m.Name,
                                 LarningId = m.Id,
                                 LearningPath = m.Path,
                                 HoursOfLearning = m.HoursOfLearning,
                             };
                if (result.Count() > 0)
                {
                        return APIUtility.BindResponse(result, true);
                }
                return APIUtility.BindResponse(null!, false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> CreateEmployeeLearning(EmployeeLearning learning)
        {
            await _context.AddAsync(learning);
            var result = await _context.SaveChangesAsync();
            if(result != 0)
            {
               return APIUtility.BindResponse(result, true, "Employee Learning created successfully.");
            }
            else
            {
                return APIUtility.BindResponse(result, true, "Employee Learning not created successfully.");
            }
         
        }

    }
}
