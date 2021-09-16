using System.IO;
using log4net.Core;
using log4net.Layout;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {

        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            writer.WriteLine($"[{loggingEvent.TimeStamp}]. {loggingEvent.MessageObject}");
        }
    }
}
