namespace Employee_Report.Utilities
{
    public static class ConfigurationHelper
    {
        public static IConfiguration _config;
        public static void Initialize(IConfiguration Configuration)
        {
            _config = Configuration;
        }
    }
}
