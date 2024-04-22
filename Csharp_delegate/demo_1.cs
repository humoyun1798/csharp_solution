using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_delegate
{
    //委托指向匿名方法
    internal class demo_1
    {
        public void Main()
        {
            Action f1 = delegate ()
            {
                Print.WriteLine("匿名方法f1");
            };
            f1();

            Func<int, int, int> f2 = (int a,int b) =>
            {
                return a + b;
            };
            Print.WriteLine("f2"+f2(3, 3));
            
            ///lambda 表达式 委托匿名函数
            Func<int, int, int> f3 = (a,b) =>
            { 
                return a + b;
            };
            Print.WriteLine("f3" + f3(3, 3));

            Action f4 = () =>
            {
                Print.WriteLine("匿名方法f4");
            };
            f4();

            //只有一行代码可以省略大括号{} ,感觉和 if else 类似
            Action f5 = () => Print.WriteLine("匿名方法f5");
            f5();
            //有返回值的 return 也能省略

            Func<int,string> f6 = (a) => "匿名方法f6"+a;
            Print.WriteLine(f6(6));

            //单参数（）也能省
            Func<int, string> f7 = a => "匿名方法f7" + a;
        }



    }
}
