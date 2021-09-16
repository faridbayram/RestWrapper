using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _logger;

        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            var log4nnet = xmlDocument["log4net"];
            XmlConfigurator.Configure(loggerRepository, log4nnet);

            _logger = LogManager.GetLogger(loggerRepository.Name, name);
        }

        public void Info(object logMessage)
        {
            if(IsInfoEnabled)
                _logger.Info(logMessage);
        }

        public void Debug(object logMessage)
        {
            if(IsDebugEnabled)
                _logger.Debug(logMessage);
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _logger.Warn(logMessage);
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _logger.Error(logMessage);
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
                _logger.Fatal(logMessage);
        }

        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;
    }
}
