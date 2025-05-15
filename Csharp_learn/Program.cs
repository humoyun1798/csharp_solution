using System;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Csharp_learn
{
    internal class Program
    {



        


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var a = 1;
            //var b = 1;
            //Console.WriteLine(ReferenceEquals(1, 1));//false
            //Console.WriteLine(1.Equals(1));//true
            //Console.WriteLine(1==1);//true
            //Console.WriteLine(a == b);//true
            //Console.WriteLine(a.Equals(b));//true
            //Console.WriteLine(ReferenceEquals(a,b));//false


            //var k = new 构造函数(1);
            //var j = new 构造函数(1);

            //Console.WriteLine(k == j);//true
            //Console.WriteLine(k.Equals(j));//true
            //Console.WriteLine(ReferenceEquals(k, j));//false





            //var k1 = new 对象();
            //k1.a();
            //var lll = new ll();
            //lll.a();
            //lll.a1();
            //lll.a2();
            var url="https://www.baidu.comggj";
            var data= new byte[1000000];
            Console.WriteLine($"{url,-60} {data.Length,10:#,#}"); //-60表示左对齐占60个字符位，10表示右对齐占10个字符位



            var v = new 异步();
            Task.Run(()=>v.SumPageAsync());
            //v.b(-1);
            //v.b(0);

            Console.ReadKey();

        }







    }
}
