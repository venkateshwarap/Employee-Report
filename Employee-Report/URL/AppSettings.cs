namespace Employee_Report
{
    public static class AppSettings
    {
        public const string BaseUrl = "https://localhost:7178/api/";


        public const string LoginAPI = "https://localhost:7024/api/Authenticate/login";
        public const string DashboardList = "https://localhost:7024/api/Dashboard/GetEmployeeDetails";

        #region POC       
        public const string GetPOC = "https://localhost:7178/api/POC/GetEmployeePOC";
        public const string AddPOC = "https://localhost:7178/api/POC/AddEmployeePoc";
        #endregion

        #region Project
        public const string GetEmployeeProject = "https://localhost:7178/api/Project/GetEmployeeProject";
        public const string AddProject = "https://localhost:7178/api/Project/AddEmployeeProject";
        #endregion

        #region Role
        public const string GetRole = "https://localhost:7178/api/Role/GetRole";
        public const string AddRole = "https://localhost:7178/api/Role/AddRole";
        #endregion



        public static string GetEmployeeURl = "https://localhost:7024/api/Employee/GetAllEmployee";
        public static string GetlearningURl = "https://localhost:7024/api/Learning/GetLearningDetails";
        public static string PostlearningURl = "https://localhost:7024/api/Learning/SaveLearning";
        public const string GetTrainings = "https://localhost:7024/api/Training/GetAllTrainings";
        public const string GetBenchEntry = "eacouncil/entry/get";
        public const string CreateBenchEntry = "eacouncil/entry/create";
        
        #region Interviews
        public const string GetInterviews = "Interview/GetAllInterviews";
        public const string AddInterviews = "Interview/AddInterview";
        #endregion

        #region Skills
        public const string GetSkills = "Skills/GetSkills";
        #endregion
        #region
        public static string GetlearningApi = "https://localhost:7178/api/Learning";
        public static string SavelearningApi = "";
        public static string GetTraningApi = "https://localhost:7178/api/Training/GetEmployeeTraning";
        public static string SaveTraningApi = "";
        #endregion
    }
}
