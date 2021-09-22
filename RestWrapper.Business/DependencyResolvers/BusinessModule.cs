using RestWrapper.Business.Concrete;
using RestWrapper.Business.Abstract;
using RestWrapper.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace RestWrapper.Business.DependencyResolvers
{
    // Dependencies about Business need to be added here
    public class BusinessModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<ICalculator, Calculator>();
        }
    }
}
