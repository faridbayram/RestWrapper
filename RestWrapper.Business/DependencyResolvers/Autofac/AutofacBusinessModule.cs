using Autofac;
using Autofac.Extras.DynamicProxy;
using RestWrapper.Business.Concrete;
using Castle.DynamicProxy;
using RestWrapper.Business.Abstract;
using RestWrapper.Core.Utilities.Interceptors;
using RestWrapper.DataAccess.Abstract;
using RestWrapper.DataAccess.Concrete.EntityFramework.DALC;

namespace RestWrapper.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Calculator>().As<ICalculator>();
            builder.RegisterType<CallDAL>().As<ICallDAL>();
            builder.RegisterType<RequestDAL>().As<IRequestDAL>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
