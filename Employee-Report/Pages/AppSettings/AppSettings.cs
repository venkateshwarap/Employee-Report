using Employee_Report.Utilities;

namespace Employee_Report
{
    public static class Config
    {
        #region API Config
        public static string API_ROUTE = ConfigurationHelper._config!.GetSection(Constants.API_ROUTE).Value!;
       
        public static string GET_EA_COUNCIL = ConfigurationHelper._config!.GetSection(Constants.GET_EA_COUNCIL).Value!;
        public static string CREATE_EA_COUNCIL_ENTRY = ConfigurationHelper._config!.GetSection(Constants.CREATE_EA_COUNCIL_ENTRY).Value!;
        public static string GET_CERTIFICATIONS_DETAILS = ConfigurationHelper._config!.GetSection(Constants.GET_CERTIFICATIONS_DETAILS).Value!;
        public static string CREATE_CERTIFICATIONS_DETAILS = ConfigurationHelper._config!.GetSection(Constants.CREATE_CERTIFICATIONS_DETAILS).Value!;

        public const string LoginAPI = "https://localhost:7024/api/Authenticate/login";
        public const string DashboardList = "https://localhost:7024/api/Dashboard/GetEmployeeDetails";
        public const string GetPOC = "https://localhost:7024/api/POC/GetPOCDetails";
        public static string GetEmployeeURl = "https://localhost:7024/api/Employee/GetAllEmployee";
        public static string GetlearningURl = "https://localhost:7024/api/Learning/GetLearningDetails";
        public static string PostlearningURl = "https://localhost:7024/api/Learning/SaveLearning";
        public const string GetTrainings = "https://localhost:7024/api/Training/GetAllTrainings";
        
        #region Interviews
        public const string GetInterviews = "Interview/GetAllInterviews";
        public const string AddInterviews = "Interview/AddInterview";
        #endregion

        #region Skills
        public const string GetSkills = "Skills/GetSkills";
      #endregion
       #endregion
}
}
