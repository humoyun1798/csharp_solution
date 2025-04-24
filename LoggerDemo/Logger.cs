using Microsoft.Extensions.Logging;

namespace LoggerDemo
{
    public class Logger
    {
        private readonly ILogger<Logger> logger;
        public Logger(ILogger<Logger> logger)
        {
            this.logger = logger;
        }

        public void Log()
        {
            logger.LogDebug("开始日志记录");
                logger.LogInformation("杀人成功");
            logger.LogWarning("刺杀失败，重试。。。");

        }
    }
}
