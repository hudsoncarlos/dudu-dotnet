using Microsoft.Extensions.DependencyInjection;

namespace Ioc.Model
{
    public abstract class ConfigurationIoc
    {
        protected IServiceCollection _services;

        public ConfigurationIoc(IServiceCollection services)
        {
            _services = services;
            RegisterDependencies();
        }

        public abstract void RegisterDependencies();
    }
}
