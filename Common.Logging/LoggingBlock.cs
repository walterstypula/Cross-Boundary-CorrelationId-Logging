using System;
using System.Runtime.CompilerServices;

namespace Common.Logging
{
    public class LoggingBlock : IDisposable
    {
        private bool disposed;
        private readonly DateTime _start = DateTime.Now;
        private readonly string _memberName;
        private readonly ILogger _logger;      

        public LoggingBlock(ILogger logger, string memberName = "")
        {
            _logger = logger;
            _memberName = memberName;

            var msg = string.Format("Started '{0}'", _memberName);
            _logger.Debug(msg);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                var end = DateTime.Now;

                var totalExecTime = (end - _start).TotalMilliseconds;
                var msg = string.Format("Completed '{0}' : execution time: {1}ms", _memberName, totalExecTime);
                _logger.Debug(msg);
            }

            disposed = true;
        }
    }
}