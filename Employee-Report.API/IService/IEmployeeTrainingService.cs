﻿using Employee_Report.Model.Models;
namespace Employee_Report.API.IService
{
    public interface IEmployeeTrainingService
    {
        public ResponseModel SaveEmployeeTraningDetails(EmployeeTraining employeeTrainng);
        public List<EmployeeTraining> GetEmployeeTraningDetails();
    }
}
