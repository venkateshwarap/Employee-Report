namespace Employee_Report
{
    public static class AppSettings
    {
        public const string BaseUrl = "https://localhost:7178/api/";

        public const string LoginAPI = "https://localhost:7024/api/Authenticate/login";
        public const string DashboardList = "https://localhost:7024/api/Dashboard/GetEmployeeDetails";
        public const string GetPOC = "https://localhost:7024/api/POC/GetPOCDetails";
        public const string GetInterview = "https://localhost:7024/api/Interview/GetInterview";
        public static string GetEmployeeURl = "https://localhost:7024/api/Employee/GetAllEmployee";
        public static string GetlearningURl = "https://localhost:7024/api/Learning/GetLearningDetails";
        public static string PostlearningURl = "https://localhost:7024/api/Learning/SaveLearning";
        public const string GetTrainings = "https://localhost:7024/api/Training/GetAllTrainings";
        public const string GetBenchEntry = "eacouncil/entry/get";
        public const string CreateBenchEntry = "eacouncil/entry/create";
    }
}
