using log4net;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LogService
    {
        private ILog _log;

        public LogService(ILog log)
        {
            _log = log;
        }
        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
                _log.Info(logMessage);
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _log.Warn(logMessage);
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _log.Error(logMessage);
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
                _log.Fatal(logMessage);
        }
        public void Debug(object logMessage)
        {
            if (IsFatalEnabled)
                _log.Debug(logMessage);
        }
    }
}
