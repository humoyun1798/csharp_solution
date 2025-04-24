
using System;
using System.Threading;
using TimerServer.job;

namespace TimerServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var scheduler=TestJobScheduler.Create().Result;
            //scheduler.Start();
            //while (!scheduler.IsShutdown)
            //{
            //    Thread.Sleep(1000);
            //}


            var scheduler = PublicScheduler.Create(typeof(DingDingJob)).Result;

            scheduler.Start();
            while (!scheduler.IsShutdown)
            {
                Thread.Sleep(1000);
            }


            Console.WriteLine("結束");
        }
    }
}
