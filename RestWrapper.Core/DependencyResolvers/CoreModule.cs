using Microsoft.Extensions.DependencyInjection;
using RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers;
using RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RestWrapper.Core.Utilities.IoC;

namespace RestWrapper.Core.DependencyResolvers
{
    // Dependencies about Core functionality need to be added here
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<FileLogger, FileLogger>();
            services.AddSingleton<CallDBLogger, CallDBLogger>();
            services.AddSingleton<RequestDBLogger, RequestDBLogger>();
        }
    }
}
