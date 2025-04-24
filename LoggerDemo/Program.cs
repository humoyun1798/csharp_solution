using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace LoggerDemo
{
    internal class Program
    {
        public static readonly ILogger<Program> logger;

        static void Main(string[] args)
        {
            ServiceCollection service = new ServiceCollection();
            service.AddLogging(build =>
            {
                build.AddConsole();
            });


            using (var sp = service.BuildServiceProvider())
            {
                var test = sp.GetRequiredService<Test1>();
                test.Log();
            }

        }
    }
}
