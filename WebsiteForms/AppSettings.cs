using dotenv.net;
using System.Diagnostics;

namespace WebsiteForms
{
    public class AppSettings
    {
        private const string DEFAULT_SECRET_KEY = "Uj4j!&g@H7scvc&eyRdt6ta3tvHx#j";
        private const string DEFAULT_AUDIENCE = "localhost";
        private const string DEFAULT_ISSUER = "localhost";
        private const string DEFAULT_EXPIRE_TOKEN_MINUTES = "30";
        private const string DEFAULT_FILES_FOLDER = "Files";
        private const string DEFAULT_DB_SERVER = "(LOCALDB)\\SERVERDB";
        private const string DEFAULT_DB_NAME = "WebsiteForms";
        private const string DEFAULT_DB_USER = "";
        private const string DEFAULT_DB_PASSWORD = "";
        private const string DEFAULT_DB_INTEGRATED_SECURITY = "true";

        public string SecretKey { get; private set; }
        public string AudienceToken { get; private set; }
        public string IssuerToken { get; private set; }
        public double ExpireTokenMinutes { get; private set; }
        public string RootPath { get; private set; }
        public string FilesPath { get; private set; }
        public string DbServer { get; private set; }
        public string DbName { get; private set; }
        public string DbUser { get; private set; }
        public string DbPassword { get; set; }
        public string DbIntegratedSecuryty { get; set; }

        public AppSettings()
        {
            string projectDirectory = Path.GetFullPath(".\\");

            var envFilePaths = new string[]
            {
                Path.Combine(projectDirectory, ".env"),
                Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), ".env")
            };

            DotEnv.Load(options: new DotEnvOptions(envFilePaths: envFilePaths)) ;

            RootPath = projectDirectory;

            SecretKey = Environment.GetEnvironmentVariable("SECRET_KEY") ?? DEFAULT_SECRET_KEY;
            AudienceToken = Environment.GetEnvironmentVariable("AUDIENCE_TOKEN") ?? DEFAULT_AUDIENCE;
            IssuerToken = Environment.GetEnvironmentVariable("ISSUER_TOKEN") ?? DEFAULT_ISSUER;
            ExpireTokenMinutes = double.Parse(Environment.GetEnvironmentVariable("EXPIRE_TOKEN_MINUTES") ?? DEFAULT_EXPIRE_TOKEN_MINUTES);

            FilesPath = Environment.GetEnvironmentVariable("FILES_BASE_PATH") ?? Path.Combine(projectDirectory, DEFAULT_FILES_FOLDER);

            DbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? DEFAULT_DB_SERVER;
            DbName = Environment.GetEnvironmentVariable("DB_NAME") ?? DEFAULT_DB_NAME;
            DbUser = Environment.GetEnvironmentVariable("DB_USER") ?? DEFAULT_DB_USER;
            DbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? DEFAULT_DB_PASSWORD;
            DbIntegratedSecuryty = bool.Parse(Environment.GetEnvironmentVariable("DB_INTEGRATED_SECURITY") ?? DEFAULT_DB_INTEGRATED_SECURITY).ToString();
        }
    }
}
