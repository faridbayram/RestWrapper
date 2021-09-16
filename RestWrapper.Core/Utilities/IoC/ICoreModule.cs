using Microsoft.Extensions.DependencyInjection;

namespace RestWrapper.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
