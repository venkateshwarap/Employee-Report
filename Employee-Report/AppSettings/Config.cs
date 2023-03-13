using Employee_Report.Utilities;

namespace Employee_Report.AppSettings
{
    public static class Config
    {
        public static string API_ROUTE = ConfigurationHelper._config!.GetSection(Constants.API_ROUTE).Value!;
        public static string GET_EA_COUNCIL = ConfigurationHelper._config!.GetSection(Constants.GET_EA_COUNCIL).Value!;
        public static string CREATE_EA_COUNCIL_ENTRY = ConfigurationHelper._config!.GetSection(Constants.CREATE_EA_COUNCIL_ENTRY).Value!;
        public static string GET_CERTIFICATIONS_DETAILS = ConfigurationHelper._config!.GetSection(Constants.GET_CERTIFICATIONS_DETAILS).Value!;
        public static string CREATE_CERTIFICATIONS_DETAILS = ConfigurationHelper._config!.GetSection(Constants.CREATE_CERTIFICATIONS_DETAILS).Value!;

        public const string LoginAPI = "https://localhost:7024/api/Authenticate/login";
        public const string DashboardList = "https://localhost:7024/api/Dashboard/GetEmployeeDetails";

        #region POC       
        public const string GetEmployeePOC = "https://localhost:7178/api/POC/GetEmployeePOC";
        public const string AddEmployeePOC = "https://localhost:7178/api/POC/AddEmployeePoc";
        public const string GetPOC = "https://localhost:7178/api/POC/GetPOC";
        public const string AddPOC = "https://localhost:7178/api/POC/AddPoc";
        #endregion

        #region Project
        public const string GetEmployeeProject = "https://localhost:7178/api/Project/GetEmployeeProject";
        public const string AddEmployeeProject = "https://localhost:7178/api/Project/AddEmployeeProject";
        public const string GetProject = "https://localhost:7178/api/Project/GetProject";
        public const string AddProject = "https://localhost:7178/api/Project/AddProject";
        #endregion

        #region Employee
        public const string GetEmployee = "https://localhost:7178/api/Emp/GetEmployee";
        #endregion

        #region Role
        public const string GetRole = "https://localhost:7178/api/Role/GetRole";
        public const string AddRole = "https://localhost:7178/api/Role/AddRole";
        #endregion

        #region Learnings
        public static string Getlearnings = "Learnings/get";
        public static string AddNewLearning = "Learnings/create";
        #endregion

        #region Trainings
        public static string GetTrainings = "Trainings/get";
        public static string AddNewTraining = "Trainings/create";
        #endregion

        public static string GetEmployeeURl = "Employee/GetAllEmployee";
        public const string GetBenchEntry = "eacouncil/entry/get";
        public const string CreateBenchEntry = "eacouncil/entry/create";

        #region Interviews
        public const string GetInterviews = "Interview/GetAllInterviews";
        public const string AddInterviews = "Interview/AddInterview";
        #endregion

        #region Skills
        public const string GetSkills = "Skills/get";
        public const string AddSkill = "Skills/create";
        #endregion

        #region EmployeeSkills
        public const string GetEmployeeSkills = "EmployeeSkills/get";
        public const string AddEmployeeSkill = "EmployeeSkills/create";
        #endregion
    }
}
