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
            Console.WriteLine("之前 {0}", Global.Instance.Name);
            Global.Instance.Name = "dingdingServer";

            Console.WriteLine("之后 {0}", Global.Instance.Name);



        }
    }
}
