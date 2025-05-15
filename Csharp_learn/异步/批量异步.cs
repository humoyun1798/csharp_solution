using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_learn
{
    public class 批量异步
    {


        /// <summary>
        /// 普通 按执行顺序执行，不是按完成顺序执行
        /// </summary>
        /// <returns></returns>
        public async Task<int> a()
        {

            List<Task<T>> tasks = …;
            foreach (var t in tasks)
            {
                try { Process(await t); }
                catch (OperationCanceledException) { }
                catch (Exception exc) { Handle(exc); }
            }
        }



        public async Task<int> b()
        {

            List<Task<T>> tasks = …;
            foreach (var t in tasks)
                t.ContinueWith(completed => {
                    switch (completed.Status)
                    {
                        case TaskStatus.RanToCompletion: Process(completed.Result); break;
                        case TaskStatus.Faulted: Handle(completed.Exception.InnerException); break;
                    }
                }, TaskScheduler.Default);
        }




    }
}
