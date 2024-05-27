using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiHome.Net;
using MiHome.Net.Middleware;
using MiHome.Net.Service;

namespace MiHome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            All();
            Console.WriteLine("Hello, World!");
        }

        static public async void All()
        {
           
            //列出家庭里所有的智能家居设备
            try
            {
                var miHomeDriver = CreateDriver();
                var deviceList = miHomeDriver.Cloud.GetDeviceListAsync().Result;
                //通过米家app里自己设置的智能家居名称找出自己想要操作的智能家居设备
                var moonLight = deviceList.FirstOrDefault(it => it.Name == "月球灯");
                //通过设备型号获取设备规格
                var result = miHomeDriver.Cloud.GetDeviceSpec(moonLight.Model).Result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        static public IMiHomeDriver CreateDriver()
        {
            var hostBuilder = Host.CreateDefaultBuilder();
            //添加小米米家的驱动服务，需要小米账号和密码
            hostBuilder.ConfigureServices(it => it.AddMiHomeDriver(x =>
            {
                x.UserName = "17336335046";
                x.Password = "wlgood55555";
            }));
            var host = hostBuilder.Build();
            var miHomeDriver = host.Services.GetService<IMiHomeDriver>();
            return miHomeDriver;
        }



    }
}