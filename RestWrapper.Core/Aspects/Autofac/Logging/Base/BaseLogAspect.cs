using Castle.DynamicProxy;
using RestWrapper.Core.Utilities.Interceptors;

namespace RestWrapper.Core.Aspects.Autofac.Logging.Base
{
    public abstract class BaseLogAspect : MethodInterception
    {
        protected static int callOrderer = 1;
        public abstract string GetLogMessage(IInvocation invocation);
    }
}
