using log4net;  

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger:LogService
    {
        public FileLogger():base(LogManager.GetLogger("FileLogger"))
        {
            
        }
    }
}
