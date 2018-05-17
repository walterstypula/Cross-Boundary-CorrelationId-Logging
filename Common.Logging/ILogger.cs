using System;
using System.Runtime.CompilerServices;

namespace Common.Logging
{
    public interface ILogger
    {
        void Debug(object message);

        void Debug(object message, Exception ex);
    }

    public static class ILoggerExtensions
    {
        public static LoggingBlock GetLoggingBlock(this ILogger logger, [CallerMemberName] string memberName = "")
        {
            return new LoggingBlock(logger, memberName);
        }
    }
}