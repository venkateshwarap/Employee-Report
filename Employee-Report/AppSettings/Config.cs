using Employee_Report.Utilities;

namespace Employee_Report.AppSettings
{
    public static class Config
    {
        public static string API_ROUTE = ConfigurationHelper._config!.GetSection(Constants.API_ROUTE).Value!;

        #region Certificate
        public static string GET_CERTIFICATIONS_DETAILS = ConfigurationHelper._config!.GetSection(Constants.GET_CERTIFICATIONS_DETAILS).Value!;
        public static string GET_CERTIFICATIONS_DETAILS_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_POWERHOUS_BY_ID).Value!;
        public static string CREATE_CERTIFICATIONS_DETAILS = ConfigurationHelper._config!.GetSection(Constants.CREATE_CERTIFICATIONS_DETAILS).Value!;
        #endregion

        #region INTELLECTUAL
        public static string GET_INTELLECTUAL_PROPERTY_DETAILS = ConfigurationHelper._config!.GetSection(Constants.GET_INTELLECTUAL_PROPERTY).Value!;
        public static string CREATE_INTELLECTUAL_PROPERTY_DETAILS = ConfigurationHelper._config!.GetSection(Constants.CREATE_INTELLECTUAL_PROPERTY).Value!;
        #endregion

        #region Power House 
        public static string GET_POWER_HOUSE = ConfigurationHelper._config!.GetSection(Constants.GET_POWERHOUSE).Value!;
        public static string GET_POWERHOUS_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_POWERHOUS_BY_ID).Value!;
        public static string CREATE_POWER_HOUSE = ConfigurationHelper._config!.GetSection(Constants.CREATE_POWERHOUSE).Value!;
        public static string CREATE_POWERHOUSE_ROLE = ConfigurationHelper._config!.GetSection(Constants.CREATE_POWERHOUSE_ROLE).Value!;
        #endregion

        #region Employee POC
        public static string GET_EMPLOYEE_POC = ConfigurationHelper._config.GetSection(Constants.GET_EMPLOYEE_POC).Value;
        public static string GET_EMPLOYEE_POC_ID = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_POC_ID).Value!;
        public static string CREATE_EMPLOYEE_POC = ConfigurationHelper._config!.GetSection(Constants.CREATE_EMPLOYEE_POC).Value!;
        #endregion

        #region Admin POC
        public static string GET_ADMIN_POC = ConfigurationHelper._config.GetSection(Constants.GET_ADMIN_POC).Value;
        public static string GET_ADMIN_POC_ID = ConfigurationHelper._config!.GetSection(Constants.GET_ADMIN_POC_By_ID).Value!;
        public static string CREATE_ADMIN_POC = ConfigurationHelper._config!.GetSection(Constants.CREATE_ADMIN_POC).Value!;
        #endregion

        #region Employee Project
        public static string CREATE_EMPLOYEE_PROJECT = ConfigurationHelper._config!.GetSection(Constants.CREATE_EMPLOYEE_PROJECT).Value!;
        public static string GET_EMPLOYEE_PROJECT = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_PROJECT).Value!;
        public static string GET_EMPLOYEE_PROJECT_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_PROJECT_BY_ID).Value!;
        #endregion

        #region Project
        public static string CREATE_PROJECT = ConfigurationHelper._config!.GetSection(Constants.CREATE_PROJECT).Value!;
        public static string GET_PROJECT_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_PROJECT_BY_ID).Value!;
        public static string GET_PROJECT = ConfigurationHelper._config!.GetSection(Constants.GET_PROJECT).Value!;
        #endregion

        #region Employee
        public static string GET_EMPLOYEE_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_BY_ID).Value!;
        public static string CREATE_EMPLOYEE = ConfigurationHelper._config!.GetSection(Constants.CREATE_EMPLOYEE).Value!;
        public static string GET_EMPLOYEES = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEES).Value!;
        #endregion

        #region Login
        public const string Login = "https://localhost:7178/api/Authenticate/login";
        #endregion

        #region Role
        public static string ADD_ROLE = ConfigurationHelper._config!.GetSection(Constants.ADD_ROLE).Value!;
        public static string GET_ROLE = ConfigurationHelper._config!.GetSection(Constants.GET_ROLE).Value!;
        #endregion

        #region Learnings
        public static string CREATE_EMPLOYEE_LEARNING = ConfigurationHelper._config!.GetSection(Constants.CREATE_EMPLOYEE_LEARNING).Value!;
        public static string GET_EMPLOYEE_LEARNING = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_LEARNING).Value!;
        public static string GET_EMPLOYEE_LEARNING_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_LEARNING_BY_ID).Value!;
        #endregion

        #region Admin Learning
        public static string CREATE_ADMIN_LEARNING = ConfigurationHelper._config!.GetSection(Constants.CREATE_ADMIN_LEARNING).Value!;
        public static string GET_ADMIN_LEARNING = ConfigurationHelper._config!.GetSection(Constants.GET_ADMIN_EMPLOYEE_LEARNING).Value!;
        #endregion

        #region Trainings
        public static string GET_EMPLOYEE_TRAINING = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_TRAINING).Value!;
        public static string CREATE_EMPLOYEE_TRAINING = ConfigurationHelper._config!.GetSection(Constants.CREATE_EMPLOYEE_TRAINING).Value!;
        public static string GET_EMPLOYEE_TRAINING_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_TRAINING_BY_ID).Value!;
        #endregion

        #region Admin Training
        public static string GET_ADMIN_TRAINING = ConfigurationHelper._config!.GetSection(Constants.GET_ADMIN_TRAINING).Value!;
        public static string GET_ADMIN_TRAINING_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_ADMIN_TRAINING_BY_ID).Value!;
        public static string CREATE_ADMIN_TRAINING = ConfigurationHelper._config!.GetSection(Constants.CREATE_ADMIN_TRAINING).Value!;
        #endregion

        #region Interviews
        public static string GET_INTERVIEW = ConfigurationHelper._config!.GetSection(Constants.GET_INTERVIEW).Value!;
        public static string GET_INTERVIEW_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_INTERVIEW_BY_ID).Value!;
        public static string CREATE_INTERVIEW = ConfigurationHelper._config!.GetSection(Constants.CREATE_INTERVIEW).Value!;
        #endregion

        #region ADMIN Skills
        public static string GET_ADMIN_SKILLS = ConfigurationHelper._config!.GetSection(Constants.GET_ADMIN_SKILLS).Value!;
        public static string CREATE_ADMIN_SKILLS = ConfigurationHelper._config!.GetSection(Constants.CREATE_ADMIN_SKILLS).Value!;
        #endregion

        #region Employee Skills
        public static string GET_EMPLOYEE_SKILLS_BY_ID = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_SKILLS_By_ID).Value!;
        public static string CREATE_EMPLOYEE_SKILLS = ConfigurationHelper._config!.GetSection(Constants.CREATE_EMPLOYEE_SKILLS).Value!;
        public static string GET_EMPLOYEE_SKILLS = ConfigurationHelper._config!.GetSection(Constants.GET_EMPLOYEE_SKILLS).Value!;
        #endregion
    }
}
