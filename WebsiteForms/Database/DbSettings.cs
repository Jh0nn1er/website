using System.Diagnostics;

namespace WebsiteForms.Database
{
    public static class DbSettings
    {
        private static readonly AppSettings _appSettings = new();
        public static string GetConnectionString()
        {
            string server = _appSettings.DbServer;
            string database = _appSettings.DbName;
            string user = _appSettings.DbUser;
            string password = _appSettings.DbPassword;
            string integratedSecurity = _appSettings.DbIntegratedSecuryty;

            return $"Server={server};Database={database};Integrated Security={integratedSecurity};user id={user};password={password}";
        }
    }
}
