using Microsoft.Extensions.DependencyInjection;
using RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RestWrapper.Core.Utilities.IoC;

namespace RestWrapper.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<FileLogger, FileLogger>();
        }
    }
}
