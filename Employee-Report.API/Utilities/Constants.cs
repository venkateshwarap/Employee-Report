using System;

namespace Employee_Report.API.Utilities
{
    public static class Constants
    {
        public const string Content_Type = "text/html";

        #region Empty data
        public const string Response_Database_Empty = "Your database is empty... Try adding some data";
        #endregion

        #region Bench
        public const string Response_Bench_Entry = "Bench entry has been created successfully.";
        public const string Response_Bench_Entry_Failed = "Bench entry has not been created.";
        public const string RE_EmpId_Not_Available_EA = "Employee not registered into EA Council";
        public const string RE_Remove_EA = "Employee entry deleted from EA Council";
        #endregion

        #region Certification
        public const string Response_Create_Certification = "Certification Details has been created.";
        public const string Response_Remove_Certification = "Certification details deleted";
        #endregion

        #region Interview
        public const string Response_Add_Interview_Success = "New Interview details have been added Successfully";
        public const string Response_Add_Interview_Failure = "Failed to add New Interview details";
        #endregion

        #region Skills
        public const string Response_Add_Skill_Success = "New Skill has been added Successfully";
        public const string Response_Add_Skill_Failure = "Failed to add New Skill";
        #endregion

        #region Learnings
        public const string Response_Add_Learning_Success = "New Learning has been added Successfully";
        public const string Response_Add_Learning_Failure = "Failed to add New Learning";
        #endregion

        #region Trainings
        public const string Response_Add_Training_Success = "New training has been added Successfully";
        public const string Response_Add_Training_Failure = "Failed to add New Training";
        #endregion

        #region EmployeeSkills
        public const string Response_Add_EmployeeSkills_Success = "New EmployeeSkill has been added Successfully";
        public const string Response_Add_EmployeeSkills_Failue = "Faield to add New EmployeeSkill";
        public const string Response_EmployeeSkills_Already_Exists = "EmployeeSkill already exists in your database";
        #endregion

        #region API Routes
        public const string RT_Certification = "api/certification";
        public const string RT_POWER_HOUSE = "api/power-house";
        public const string RT_INTELLECTUAL_PROPERTY = "api/intellectual-property";
        #endregion

        #region Controller Routes
        public const string get = "get";
        public const string create = "create";
        public const string getById = "getById";
        #endregion

        public const string GET = "get";
        public const string CREATE = "create";
        public const string UPDATE = "update";
        public const string GET_BY_ID = "getById";
    }
}
