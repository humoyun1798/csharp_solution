using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_learn
{
    public class 异步
    {


        public async Task a()
        {
            try
            {
                // 创建多个任务
                Task<int> task1 = DoWorkAsync(1, 2000);
                Task<int> task2 = DoWorkAsync(2, 1500);
                Task<int> task3 = DoWorkAsync(3, 1000);
                Console.WriteLine("=== WhenAll ===");
                // 使用 Task.WhenAll 等待所有任务完成
                int[] results = await Task.WhenAll(task1, task2, task3);

                // 输出每个任务的结果
                for (int i = 0; i < results.Length; i++)
                {
                    Console.WriteLine($"Task {i + 1} 结果: {results[i]}");
                }
                Console.WriteLine("=== WhenAny ===");

                // 创建新的任务用于演示 Task.WhenAny
                Task<int> task4 = DoWorkAsync(4, 3000);
                Task<int> task5 = DoWorkAsync(5, 2500);
                Task<int> task6 = DoWorkAsync(6, 2000);

                // 使用 Task.WhenAny 等待任意一个任务完成
                Task<int> firstCompletedTask = await Task.WhenAny(task4, task5, task6);
                int firstResult = await firstCompletedTask;
                Console.WriteLine($"第一个完成的任务结果: {firstResult}");

                //Console.WriteLine("=== TaskValue ==="); //nnd TaskValue不是只能执行一次吗，怎么tm不报错nnd

                //var vt = GetValueTaskAsync();
                //int a1 = await vt;
                //Console.WriteLine(a1);
                //try
                //{
                //    int a2 = await vt;
                //    Console.WriteLine(a2);

                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"发生错误: {ex.Message}");
                //}


                //Console.WriteLine("=== Task ===");  
                //var t = GetTaskAsync();
                //int b1 = await t;
                //Console.WriteLine(b1);

                //int b2 = await t;
                //Console.WriteLine(b2);

                //try
                //{
                //    // 创建 ValueTask 任务
                //    ValueTask<int> valueTask = GetValueTaskAsync();

                //    // 第一次等待 ValueTask
                //    int firstResultFromValueTask = await AwaitValueTask(valueTask).AsTask();
                //    Console.WriteLine($"ValueTask 第一次等待结果: {firstResultFromValueTask}");

                //    try
                //    {
                //        // 尝试第二次等待 ValueTask，这会抛出异常
                //        int secondResultFromValueTask = await AwaitValueTask(valueTask).AsTask();
                //        Console.WriteLine($"ValueTask 第二次等待结果: {secondResultFromValueTask}");
                //    }
                //    catch (InvalidOperationException ex)
                //    {
                //        Console.WriteLine($"尝试第二次等待 ValueTask 时出错: {ex.Message}");
                //    }

                //    // 创建 Task 任务
                //    Task<int> task = GetTaskAsync();

                //    // 第一次等待 Task
                //    int firstResultFromTask = await task;
                //    Console.WriteLine($"Task 第一次等待结果: {firstResultFromTask}");

                //    // 第二次等待 Task
                //    int secondResultFromTask = await task;
                //    Console.WriteLine($"Task 第二次等待结果: {secondResultFromTask}");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"发生错误: {ex.Message}");
                //}

                using var client = new HttpClient();

                Task<string> getStringTask =
                    client.GetStringAsync("https://learn.microsoft.com/dotnet");

                string contents = await getStringTask;
                Console.WriteLine(contents);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }

        public async Task<int> DoWorkAsync(int taskId, int delay)
        {
            Console.WriteLine($"Task {taskId} 开始执行");
            await Task.Delay(delay);
            Console.WriteLine($"Task {taskId} 执行完成");
            return taskId * 10;
        }


        //public async Task<int> GetUrlContentLengthAsync()
        //{
        //    using var client = new HttpClient();

        //    Task<string> getStringTask =
        //        client.GetStringAsync("https://learn.microsoft.com/dotnet");

        //    string contents = await getStringTask;

        //    return contents.Length;
        //}
        public async ValueTask<int> AwaitValueTask(ValueTask<int> valueTask)
        {
            return await valueTask;
        }

        public async ValueTask<int> GetValueTaskAsync()
        {
            await Task.Delay(100);
            return 42;
        }

        public async Task<int> GetTaskAsync()
        {
            await Task.Delay(100);
            return 42;
        }

    }
}
