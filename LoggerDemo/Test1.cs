using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo
{
    class Test1
    {
        private readonly ILogger<Logger> logger;
        public Test1(ILogger<Logger> logger)
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
