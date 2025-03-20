using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimerServer.job
{
    public class TestJob : IJob
    {
        public async Task Execute(IJobExecutionContext content)
        {


            Console.WriteLine("let's do it");


            DoIt();
        }


        public void DoIt()
        {
            Console.WriteLine("just do it");
        }


    }
}
