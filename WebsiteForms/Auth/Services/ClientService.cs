using Microsoft.Extensions.Options;
using WebsiteForms.Auth.Models;
using WebsiteForms.Contracts.Auth;

namespace WebsiteForms.Auth.Services
{
    public class ClientService : IClientService
    {
        private static readonly Dictionary<string, Guid> _clients = new Dictionary<string, Guid>();
        private readonly ApiKeyClientsSettings _settings;
        private readonly ILogger<ClientService> _logger;

        public ClientService(IOptions<ApiKeyClientsSettings> settings, ILogger<ClientService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }
        public Task<Dictionary<string, Guid>> GetActiveClients()
        {
            return Task.FromResult(_clients);
        }

        public Task InvalidateApiKey(string apiKey)
        {
            _clients.Remove(apiKey);

            return Task.CompletedTask;
        }
        private string GetQueryParams(string url, Dictionary<string, string> keyValues)
        {
            for (int i = 0; i < keyValues.Count; i++)
            {
                if (i == 0)
                    url += $"?{keyValues.ElementAt(i).Key}={keyValues.ElementAt(i).Value}";
                else
                    url += $"&{keyValues.ElementAt(i).Key}={keyValues.ElementAt(i).Value}";
            }
            return url;
        }
        public async Task<bool> ValidateApiKey(string apiKey, string domain, string ip)
        {
            var @params = new Dictionary<string, string>
            {
                { "apiKey", apiKey },
                { "domain", domain },
                { "ip", ip },
            };
            var url = GetQueryParams($"{_settings.UrlBase}ApiKey/VerifyApiKey", @params);
            var response = await MakeGetRequestAuth(url, _settings.ApiKey);
            var responseString = await response.Content.ReadAsStringAsync();
            if (Guid.TryParse(responseString.Replace("\"", string.Empty), out Guid clientId))
            {
                _clients.Add(apiKey, clientId);
                return true;
            }
            return false;
        }
        private async Task<HttpResponseMessage> MakeGetRequestAuth(string url, string apikey)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("x-api-key", apikey);
                    var response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return response;
                    else
                        throw new BadHttpRequestException("An error occurred during authentication");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
