using System;
using Castle.DynamicProxy;
using RestWrapper.Core.Aspects.Autofac.Logging.Base;
using RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net;
using RestWrapper.Core.Utilities.Formats;
using RestWrapper.Core.Utilities.Messages;

namespace RestWrapper.Core.Aspects.Autofac.Logging
{
    public class LogAspectResponseFromSOAP : BaseLogAspect
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspectResponseFromSOAP(Type loggerService)
        {
            if(loggerService.BaseType != typeof(LoggerServiceBase))
                throw new Exception(AspectMessages.WrongLoggerType);

            _loggerServiceBase = Activator.CreateInstance(loggerService) as LoggerServiceBase;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            string message = GetLogMessage(invocation);
            _loggerServiceBase.Info(message);
        }

        public override string GetLogMessage(IInvocation invocation)
        {
            var message = LogFormats.ResponseFromSOAP(callOrderer, (int)invocation.ReturnValue);
            return message;
        }
    }
}
