using System;
using System.Linq;
using Castle.DynamicProxy;
using RestWrapper.Core.Aspects.Autofac.Logging.Base;
using RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net;
using RestWrapper.Core.Utilities.Formats;
using RestWrapper.Core.Utilities.Messages;

namespace RestWrapper.Core.Aspects.Autofac.Logging
{
    public class LogAspectRequestToSOAP : BaseLogAspect
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspectRequestToSOAP(Type loggerService)
        {
            if(loggerService.BaseType != typeof(LoggerServiceBase))
                throw new Exception(AspectMessages.WrongLoggerType);

            _loggerServiceBase = Activator.CreateInstance(loggerService) as LoggerServiceBase;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            string message = GetLogMessage(invocation);
            _loggerServiceBase.Info(message);
        }

        public override string GetLogMessage(IInvocation invocation)
        {
            var parameters = invocation.Arguments.Select(x => new { Value = (int)x }).ToList();
            var message = LogFormats.RequestToSOAP(callOrderer, parameters[0].Value, parameters[1].Value);
            return message;
        }
    }
}
