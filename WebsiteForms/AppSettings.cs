namespace WebsiteForms
{
    public class AppSettings
    {
        public string SecretKey { get => Environment.GetEnvironmentVariable("SECRET_KEY"); }
        public string AudienceToken { get => Environment.GetEnvironmentVariable("AUDIENCE_TOKEN"); }
        public string IssuerToken { get => Environment.GetEnvironmentVariable("ISSUER_TOKEN"); }
        public string ExpireTokenMinutes { get => Environment.GetEnvironmentVariable("EXPIRE_TOKEN_MINUTES"); }
    }
}
