using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_learn
{
    public class 使用异常
    {
        /// <summary>
        /// 自定义异常类
        /// </summary>
        class CustomException : Exception
        {
            public CustomException(string message)
            {
            }
        }
        private static void TestThrow()
        {
            throw new CustomException("Custom exception in TestThrow()");
        }

        public void a()
        {
            try
            {
                TestThrow();
            }
            catch (CustomException ex)
            //引发异常后，运行时将检查当前语句，以确定它是否在 try 块内。 如果在，则将检查与 try 块关联的所有 catch 块，以确定它们是否可以捕获该异常。
            //Catch 块通常会指定异常类型；如果该 catch 块的类型与异常或异常的基类的类型相同，则该 catch 块可处理该方法
            {
                Console.WriteLine(ex.Message + ex.StackTrace); // 一旦引发了一个异常，此异常会在调用堆栈中传播，直到找到针对它的 catch 语句 StackTrace
            }
            catch (Exception ex) //一个 try 语句可包含多个 catch 块,但只会处理第一个匹配的catch 像(if else)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            finally
            {
                //释放资源，比如报错了可能资源没法释放
            }

            /***
             * 
             * 不理解这是个什么意思用啥用?（划掉）
                   如果引发异常之后没有在调用堆栈上找到兼容的 catch 块，则会出现以下三种情况之一：

                如果异常存在于终结器内，将中止终结器，并调用基类终结器（如果有）。
                如果调用堆栈包含静态构造函数或静态字段初始值设定项，将引发 TypeInitializationException，同时将原始异常分配给新异常的 InnerException 属性。
                如果到达线程的开头，则终止线程。
             * 
            ***/




        }


    }
}
