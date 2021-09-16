using System.Collections.Generic;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public string CallName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
