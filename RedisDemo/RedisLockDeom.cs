using Newtonsoft.Json.Linq;
using RedisDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class RedisLockDeom
    {
        public static  async Task demo()
        {
            var redisConnectionString = "127.0.0.1:6379"; // 替换为你的Redis服务器地址和端口号，如果有密码请使用password@hostname:port格式
            var lockManager = new RedisLockManager(redisConnectionString, "myLock", TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(5)); // 设置锁超时和续期时间根据需要调整
            var lockValue = Guid.NewGuid().ToString(); // 锁的值，通常需要一个唯一的标识符来防止误释放其他进程的锁（例如使用GUID）
            try
            {

                if (await lockManager.AcquireLockAsync(lockValue)) // 尝试获取锁
                {
                    Console.WriteLine("Lock acquired!"); // 获取锁成功，执行需要同步的操作...
                                                         // ...你的代码逻辑...
                }
                else
                {
                    Console.WriteLine("Failed to acquire lock."); // 获取锁失败，可能是因为超时或竞争条件等原因。根据需求处理这种情况。
                }


                //await lockManager.ReleaseLockAsync("77"); // 释放锁

                if (await lockManager.AcquireLockAsync("777")) // 尝试获取锁
                {
                    Console.WriteLine("Lock acquired!"); // 获取锁成功，执行需要同步的操作...
                                                         // ...你的代码逻辑...
                }
                else
                {
                    Console.WriteLine("Failed to acquire lock."); // 获取锁失败，可能是因为超时或竞争条件等原因。根据需求处理这种情况。
                }


            }
            finally
            {
               
            }



            await lockManager.ReleaseLockAsync("myLock");

            Thread.Sleep(10000);



        }
    }
}
