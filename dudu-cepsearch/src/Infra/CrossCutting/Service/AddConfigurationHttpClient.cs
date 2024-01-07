using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Service
{
    public static class AddConfigurationHttpClient
    {
        public static void AddHttpClientFactory(this IServiceCollection services)
            => services.AddHttpClient();
    }
}
