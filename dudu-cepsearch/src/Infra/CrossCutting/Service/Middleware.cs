using Microsoft.AspNetCore.Builder;

namespace CrossCutting.Service
{
    public static class Middleware
    {
        public static void ConfigurationMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionMiddleware>();
    }
}
