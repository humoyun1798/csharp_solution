using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimerServer.job
{
    public class DingDingJob:IJob
    {
        public async Task Execute(IJobExecutionContext content)
        {


            Console.WriteLine("dingdingServer");



        }
    }
}
