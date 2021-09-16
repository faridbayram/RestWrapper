using Autofac;
using Autofac.Extras.DynamicProxy;
using RestWrapper.Business.Concrete;
using Castle.DynamicProxy;
using RestWrapper.Business.Abstract;
using RestWrapper.Core.Utilities.Interceptors;

namespace RestWrapper.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Calculator>().As<ICalculator>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
