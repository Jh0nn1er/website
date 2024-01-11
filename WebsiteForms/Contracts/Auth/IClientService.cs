namespace WebsiteForms.Contracts.Auth
{
    public interface IClientService
    {
        Task<bool> ValidateApiKey(string apiKey, string domain, string ip);
        Task<Dictionary<string, Guid>> GetActiveClients();
        Task InvalidateApiKey(string apiKey);
    }
}
