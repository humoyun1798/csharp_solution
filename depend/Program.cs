
using Microsoft.Extensions.DependencyInjection;

namespace depend
{
    internal class Program
    {
        static void Main(string[] args)
        {


            ServiceCollection services = new ServiceCollection();
            //services.AddTransient<TestServiceImp1>(); //瞬时 GetService 一次创建一个对象
            //services.AddSingleton<TestServiceImp1>();//单例

            services.AddScoped<TestServiceImp1>();//范围

            using (ServiceProvider sp = services.BuildServiceProvider()) //ServiceProvider ==服务定位器
            {
                /*
                TestServiceImp1 t = sp.GetService<TestServiceImp1>();
                t.Name = "lily0.";
                t.SayHi();
                TestServiceImp1 t1 = sp.GetService<TestServiceImp1>();
                Console.WriteLine(object.ReferenceEquals(t1, t)); //判断两个对象是不是一个对象
                */
                using (IServiceScope scope1 = sp.CreateScope())
                {
                    //在 scope 中获取 对象要拿 scope里的 scope.xxx
                    var t=scope1.ServiceProvider.GetService<TestServiceImp1>();

                    t.Name = "lily0.";
                    t.SayHi();
                    var t1 = scope1.ServiceProvider.GetService<TestServiceImp1>();
                    Console.WriteLine(object.ReferenceEquals(t1, t)); //判断两个对象是不是一个对象
                }



            }



        }
    }


    public interface ITestService
    {
        public string Name { get; set; }
        public void SayHi();
    }

    public class TestServiceImp1 : ITestService
    {
        public string Name { get; set; }
        public void SayHi()
        {
            Console.WriteLine("TestServiceImp1 "+Name);
        }
    }
    public class TestServiceImp2 : ITestService
    {
        public string Name { get; set; }
        public void SayHi()
        {
            Console.WriteLine("TestServiceImp2");
        }
    }
}