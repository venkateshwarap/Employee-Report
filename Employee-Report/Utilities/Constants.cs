namespace Employee_Report.Utilities
{
    public static class Constants
    {
        public const string API_CONFIG = "APIConfig";
        public const string APP_JSON = "application/json";

        #region API Routes
        public const string API_ROUTE = "APIConfig:BaseUrl";

        #region Power House
        public const string GET_POWERHOUSE = "APIConfig:GetPowerHouse";
        public const string CREATE_POWERHOUSE = "APIConfig:CreatePowerHouse";
        public const string GET_POWERHOUS_BY_ID = "APIConfig:GetPowerHouseById";
        public const string CREATE_POWERHOUSE_ROLE = "APIConfig:CreatePowerHouse_Role";
        #endregion

        #region Certificate
        public const string GET_CERTIFICATIONS_DETAILS = "APIConfig:GetCertificationsDetails";
        public const string CREATE_CERTIFICATIONS_DETAILS = "APIConfig:CreateCertificationsDetails";
        public const string GET_CERTIFICATION_BY_ID = "APIConfig:GetCertificationsDetailsById";
        #endregion

        #region Employee
        public const string CREATE_EMPLOYEE = "APIConfig:CreateEmployee";
        public const string GET_EMPLOYEE_BY_ID = "APIConfig:GetEmployeeById";
        public const string GET_EMPLOYEES = "APIConfig:GetEmployee";
        #endregion

        #region Employee Project
        public const string GET_EMPLOYEE_PROJECT_BY_ID = "APIConfig:GetEmployeeProjectById";
        public const string GET_EMPLOYEE_PROJECT = "APIConfig:GetEmployeeProjectById";
        public const string CREATE_EMPLOYEE_PROJECT = "APIConfig:CreateEmployeeProject";
        #endregion

        #region Project
        public const string CREATE_PROJECT = "APIConfig:GetProject";
        public const string GET_PROJECT_BY_ID = "APIConfig:GetProjectById";
        public const string GET_PROJECT = "APIConfig:GetProject";
        #endregion

        #region LEARNING
        public const string GET_EMPLOYEE_LEARNING_BY_ID = "APIConfig:GetEmployeeLearningById";
        public const string GET_EMPLOYEE_LEARNING = "APIConfig:GetEmployeeLearning";
        public const string CREATE_EMPLOYEE_LEARNING = "APIConfig:CreateEmployeeLearning";
        #endregion

        #region ADMIN LEARNING
        public const string GET_ADMIN_EMPLOYEE_LEARNING = "APIConfig:GetAdminLearning";
        public const string CREATE_ADMIN_LEARNING = "APIConfig:CreateAdminLearning";
        #endregion

        #region TRAINING
        public const string GET_TRAINING_BY_ID = "APIConfig:GetTrainingById";
        public const string GET_EMPLOYEE_TRAINING = "APIConfig:GetEmployeeTraining";
        public const string GET_EMPLOYEE_TRAINING_BY_ID = "APIConfig:GetEmployeeTrainingById";
        public const string CREATE_EMPLOYEE_TRAINING = "APIConfig:CreateEmployeeTraining";
        #endregion

        #region TRAINING
        public const string GET_ADMIN_TRAINING = "APIConfig:GetAdminTraining";
        public const string GET_ADMIN_TRAINING_BY_ID = "APIConfig:GetAdminTrainingById";
        public const string CREATE_ADMIN_TRAINING = "APIConfig:CreateAdminTrainingById";
        #endregion

        #region Interview
        public const string GET_INTERVIEW = "APIConfig:GetInterviews";
        public const string GET_INTERVIEW_BY_ID = "APIConfig:GetInterviewById";
        public const string CREATE_INTERVIEW = "APIConfig:CreateInterview";
        #endregion

        #region Employee POC
        public const string GET_EMPLOYEE_POC_ID = "APIConfig:GetEmployeePOCByEmpId";
        public const string CREATE_EMPLOYEE_POC = "APIConfig:CreateEmployeePOC";
        public const string GET_EMPLOYEE_POC = "APIConfig:GetEmployeePOC";
        #endregion

        #region Admin POC
        public const string GET_ADMIN_POC_By_ID = "APIConfig:GetAdminPOC";
        public const string CREATE_ADMIN_POC = "APIConfig:CreateAdminPOC";
        public const string GET_ADMIN_POC = "APIConfig:GetAdminPOC";
        #endregion

        #region Role
        public const string GET_ROLE = "APIConfig:GetRole";
        public const string ADD_ROLE = "APIConfig:CreateRole";
        #endregion

        #region Employee Skills
        public const string GET_EMPLOYEE_SKILLS = "APIConfig:GetEmployeeSkills";
        public const string GET_EMPLOYEE_SKILLS_By_ID = "APIConfig:GetEmployeeSkillsById";
        public const string CREATE_EMPLOYEE_SKILLS = "APIConfig:CreateEmployeeSkills";

        #endregion

        #region Admin Skills 
        public const string GET_ADMIN_SKILLS = "APIConfig:GetAdminSkills";
        public const string CREATE_ADMIN_SKILLS = "APIConfig:CreateAdminSkills";
        #endregion

        #region IntellectualProperty Routes
        public const string GET_INTELLECTUAL_PROPERTY = "APIConfig:GetIntellectualProperty";
        public const string CREATE_INTELLECTUAL_PROPERTY = "APIConfig:CreateIntellectualProperty";
        public const string GET_BY_ID_INTELLECTUAL_PROPERTY = "APIConfig:GetIntellectualPropertyById";
        #endregion
        #endregion

        public const string EMPLOYEE_ID = "EmployeeId";


        public const string AZ_AD_SECTION = "AzureAd";
        public const string AZ_MICROSOFTGRAPH = "MicrosoftGraph";
        public const string AZ_GRAPH_SCOPES = "MicrosoftGraph:Scopes";
        public const string AZ_AD_RURL = "AzureAd:RedirectUri";
        public const string AZ_SSO_SIGNOUT = "/signout-callback-oidc";

        public const string SURVEY_API_SCOPE = "SurveyAPI:scopes";
    }
}
