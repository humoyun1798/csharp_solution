using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
namespace 基准测试1
{

    public class Benchmarks
    {
        [Benchmark]
        public void Method1()
        {
            // 测试的代码


            var a = 1;
            var b = 2;
            var c = a + b;
            Console.WriteLine(c);

        }


        [Benchmark]
        public void Method2()
        {
            // 测试的代码

            var c = 1 + 2;
            Console.WriteLine(c);

        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
