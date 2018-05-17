using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Common.Logging
{
    public class Logger : ILogger
    {
        private readonly log4net.ILog _logger;

        public Logger(Type type)
        {
            _logger = log4net.LogManager.GetLogger(type);
        }

        public void Debug(object message)
        {
            var activityId = Trace.CorrelationManager.ActivityId;
            _logger.DebugFormat("CorrelationId: {0} - {1}", activityId, message);
        }

        public void Debug(object message, Exception ex)
        {
            var activityId = Trace.CorrelationManager.ActivityId;
            _logger.DebugFormat("CorrelationId: {0} - {1} - {2}", activityId, message, ex);
        }
    }
}