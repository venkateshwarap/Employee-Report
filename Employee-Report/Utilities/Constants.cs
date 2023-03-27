namespace Employee_Report.Utilities
{
    public static class Constants
    {
        public const string API_CONFIG = "APIConfig";
        public const string APP_JSON = "application/json";

        #region API Routes
        public const string API_ROUTE = "APIConfig:BaseUrl";
        public const string GET_EA_COUNCIL = "APIConfig:GetEACouncilEntry";
        public const string CREATE_EA_COUNCIL_ENTRY = "APIConfig:CreateEACouncilEntry";
        public const string CREATE_POWERHOUSE_ROLE = "APIConfig:CreatePowerHouse_Role";
        public const string GET_CERTIFICATIONS_DETAILS = "APIConfig:GetCertificationsDetails";
        public const string GET_CERTIFICATIONS_DETAILS_BY_ID = "APIConfig:GetCertificationsDetailsById";
        public const string CREATE_CERTIFICATIONS_DETAILS = "APIConfig:CreateCertificationsDetails";
        
        public const string GET_CERTIFICATION_BY_ID = "APIConfig:GetCertificationsDetailsById";
        public const string GET_EMPLOYEE_PROJECT_BY_ID = "APIConfig:GetEmployeeProjectById";
        public const string GET_EMPLOYEE_POC_ID = "APIConfig:GetEmployeePOCById";
        public const string GET_TRAINING_BY_ID = "APIConfig:GetTrainingById";
        public const string GET_EMPLOYEE_LEARNING_ID = "APIConfig:GetEmployeeLearningById";
        public const string GET_POWERHOUS_BY_ID = "APIConfig:GetPowerHouseById";

        #region LEARNING
        public const string CREATE_EMPLOYEE_LEARNING = "APIConfig:EmployeeLearning";
        public const string GET_EMPLOYEE_LEARNING = "APIConfig:EmployeeLearning";
        #endregion

        #region TRAINING
        public const string GET_TRAINING = "APIConfig:EmployeeTraining";
        public const string CREATE_TRAINING = "APIConfig:EmployeeTraining";
        #endregion

        #region Interview
        public const string GET_INTERVIEW = "APIConfig:Interview/GetAllInterviews";
        public const string CREATE_INTERVIEW = "APIConfig:Interview/AddInterview";
        #endregion

        #region POC
        public const string GET_POC = "APIConfig:Interview/POC/GetPOC";
        public const string CREATE_POC = "APIConfig:POC/AddEmployeePoc";
        #endregion

        #region Project
        public const string GET_EMPLOYEE_PROJECT = "APIConfig:Project/GetEmployeeProject";
        public const string AddProject = "APIConfig:Project/AddEmployeeProject";
        #endregion

        #region Role
        public const string GET_ROLE = "APIConfig:Role/GetRole";
        public const string ADD_ROLE = "APIConfig:Role/AddRole";
        #endregion

        #region Skills
        public const string GET_SKILLS = "APIConfig:Skills/GetSkills";
        public const string GET_EMPLOYEE_SKILLS_ById = "APIConfig:GetEmployee_SkilsById";
        #endregion

        #region IntellectualProperty Routes
        public const string GET_INTELLECTUAL_PROPERTY = "APIConfig:GetIntellectualProperty";
        public const string CREATE_INTELLECTUAL_PROPERTY = "APIConfig:CreateIntellectualProperty";
        public const string GET_BY_ID_INTELLECTUAL_PROPERTY = "APIConfig:GetIntellectualPropertyById";
        #endregion
        #endregion
    }
}
