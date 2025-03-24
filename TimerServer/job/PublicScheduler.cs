using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimerServer.job
{
    public class PublicScheduler
    {
        public static async Task<IScheduler> Create(Type type,bool start = true)
        {
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            {

                var jobData = new JobDataMap();
                jobData.Put("DateFrom", DateTime.Now);
                jobData.Put("QuartzAssembly", File.ReadAllBytes(typeof(IScheduler).Assembly.Location));

                var job = JobBuilder.Create(type)
                    .WithIdentity("testname", "MyGroup")
                    .WithDescription("is description")
                    .UsingJobData(jobData)
                    .StoreDurably()
                    .Build();

                var trigger = TriggerBuilder.Create()
                    .WithIdentity("testname-触发器")
                    .StartNow()
                    .StartAt(DateTimeOffset.Parse("2024-01-01 00:00:00"))
                    .WithCronSchedule("0 0/30 * * * ? ")
                    .Build();

                await scheduler.ScheduleJob(job, trigger);

                if (start)
                    await scheduler.Start();

                return scheduler;
            }


        }
    }
}
