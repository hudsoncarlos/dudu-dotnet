using CrossCutting.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace CrossCutting.Service
{
    public static class LoadConfig
    {
        public static IConfiguration LoadConfigurationJson(this IServiceCollection services)
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        public static IServiceCollection AddMiddlewareOptions(this IServiceCollection services, IConfiguration configuration)
            => services.Configure<GenericError>(configuration.GetSection("GenericError"));
    }
}
