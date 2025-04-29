using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_learn
{
    public class 异常处理
    {
        public void a()
        {
            try
            {
                string? s = null;
                Console.WriteLine(s.Length);
            }
            catch (Exception e) when (LogException(e))///始终返回fasle 记录异常但不处理  光记录不处理就会报错退出程序（控制台程序的话）
            {
                Console.WriteLine(e.ToString());

            }

            Console.WriteLine("Exception must have been handled");
        }

        //finally finally 块可用于发布资源（如文件流、数据库连接和图形句柄）而无需等待运行时中的垃圾回收器来完成对象

        public void b(int index)
        {
            try
            {
               var a=new int[] {1,2 };
                var k = a[index];
            }
            catch (Exception e) when (index<0)///始终返回fasle 记录异常但不处理
            {
                Console.WriteLine("范围异常");
            }
            catch (Exception e)
            {
                Console.WriteLine("其他异常");
            }
           
        }


        /***
         * 
         * 
         * 
         * ArgumentException
         * InvalidOperationException
         * IndexOutOfRangeException
         * 
         * 
异常包含一个名为 StackTrace 的属性。 此字符串包含当前调用堆栈上的方法的名称，以及为每个方法引发异常的位置（文件名和行号）。 
StackTrace 对象由公共语言运行时 (CLR) 从 throw 语句的位置点自动创建，因此必须从堆栈跟踪的开始点引发异常。

所有异常都包含一个名为 Message 的属性。 应设置此字符串来解释发生异常的原因。 不应将安全敏感的信息放在消息文本中。
除 Message 以外，ArgumentException 也包含一个名为 ParamName 的属性，应将该属性设置为导致引发异常的参数的名称。 在属性资源库中，ParamName 应设置为 value。

公共的受保护方法在无法完成其预期功能时将引发异常。 引发的异常类是符合错误条件的最具体的可用异常。 
这些异常应编写为类功能的一部分，并且原始类的派生类或更新应保留相同的行为以实现后向兼容性。
         *
         *
         *
         *
         *
         *
         *
不要使用异常在正常执行过程中更改程序的流。 使用异常来报告和处理错误条件。
只能引发异常，而不能作为返回值或参数返回异常。
请勿有意从自己的源代码中引发 System.Exception、System.SystemException、System.NullReferenceException 或 System.IndexOutOfRangeException。
不要创建可在调试模式下引发，但不会在发布模式下引发的异常。 若要在开发阶段确定运行时错误，请改用调试断言。(Debug.Assert(!invalidCondition, "Invalid condition detected"); )
特性	调试模式 (DEBUG 定义)	发布模式 (DEBUG 未定义)
throw + #if DEBUG	异常会中断程序流	代码不存在，错误被静默忽略
Debug.Assert	触发断言失败（弹窗/日志）	代码自动移除，无性能损耗
异常处理机制	强制开发者立即修复问题	隐藏错误，导致生产环境不稳定

         
         */



        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>


        private static bool LogException(Exception e)
        {
            Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
            Console.WriteLine($"\tMessage: {e.Message}");
            return false;
        }
    }
}
