using System;

namespace Csharp_learn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = 1;
            var b = 1;
            Console.WriteLine(ReferenceEquals(1, 1));//false
            Console.WriteLine(1.Equals(1));//true
            Console.WriteLine(1==1);//true
            Console.WriteLine(a == b);//true
            Console.WriteLine(a.Equals(b));//true
            Console.WriteLine(ReferenceEquals(a,b));//false


            var k = new 构造函数(1);
            var j = new 构造函数(1);

            Console.WriteLine(k == j);//true
            Console.WriteLine(k.Equals(j));//true
            Console.WriteLine(ReferenceEquals(k, j));//false


            var k1 = new 匿名类型();
            k1.a();


            Console.ReadKey();

        }
    }
}
