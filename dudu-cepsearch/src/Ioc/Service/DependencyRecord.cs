using Microsoft.Extensions.DependencyInjection;

namespace Ioc.Service
{
    public static class DependencyRecord
    {
        public static void DependencyManager(this IServiceCollection services)
            => _ = new ApiInterviewIoc(services);
    }
}
