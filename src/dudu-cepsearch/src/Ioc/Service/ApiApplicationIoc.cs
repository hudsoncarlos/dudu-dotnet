using CrossCutting.Interface;
using CrossCutting.Service;
using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Ioc.Model;
using Microsoft.Extensions.DependencyInjection;
using Service.Service;

namespace Ioc.Service
{
    public class ApiInterviewIoc : ConfigurationIoc
    {
        public ApiInterviewIoc(IServiceCollection services) : base(services) { }

        public override void RegisterDependencies()
        {
            _services.AddDbContext<SqliteContext>();

            Application();
            Service();
            Repository();

            _services.AddSingleton<IExceptionMiddleware, GlobalException>();
        }

        void Application() { }

        void Service()
        {
            _services.AddScoped<IBaseService<CepModel>, BaseService<CepModel>>();

            _services.AddScoped<ISearchCepService<CepModel>, SearchCepService<CepModel>>();
            
        }
            

        void Repository()
            => _services.AddScoped<IBaseRepository<CepModel>, BaseRepository<CepModel>>();
    }
}
