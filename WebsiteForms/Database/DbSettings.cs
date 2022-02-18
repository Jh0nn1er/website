namespace WebsiteForms.Database
{
    public static class DbSettings
    {
        public static string GetConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "(localdb)\\MSSqlLocalDb";
            string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "WebsiteForms";
            string user = Environment.GetEnvironmentVariable("DB_USER") ?? "";
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";
            bool integratedSecurity = Boolean.Parse(Environment.GetEnvironmentVariable("DB_INTEGRATED_SECURITY") ?? "true");

            return $"Server={server};Database={database};Integrated Security={integratedSecurity};user id={user};password={password}";
        }
    }
}
