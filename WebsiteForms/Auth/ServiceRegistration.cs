using WebsiteForms.Auth.Handlers;
using WebsiteForms.Auth.Models;
using WebsiteForms.Auth.Services;
using WebsiteForms.Contracts.Auth;

namespace WebsiteForms.Auth
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddScoped<ICacheService, CacheService>();

            services.Configure<ApiKeyClientsSettings>(configuration.GetSection("ApiKeyClientsSettings"));


            services.AddScoped<ApiKeyAuthenticationHandler>();

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, o => { });

            services.AddMemoryCache();
            return services;
        }
    }
}
