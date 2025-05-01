using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Transactions;

namespace Csharp_learn
{
    public class 模式匹配
    {
        /// <summary>
        /// checknull
        /// </summary>
        public void a()
        {
            int? n = 12;

            if (n is int) Console.WriteLine("is int");


            if (n is int number) //声明模式，用于测试变量类型并将其分配给新变量 n 赋值给number number只能在这个if 区间使用，else 或其他地方都调用不到number
                                 //类型测试
            {
                Console.WriteLine(number.ToString());
            }
            else
            {
                Console.WriteLine("not number");
            }


            //if(n is not null) // is not 在 C# 9.0之后才支持
            //{

            //}


            Console.WriteLine(B("A"));
            Console.WriteLine(B(null));
            //yield return new string[] { "1", "DEPOSIT", "ABC", "100.00" };
            //yield return new string[] { "2", "WITHDRAWAL", "DEF", "50.00" };
            //yield return new string[] { "3", "INTEREST", "2.50" };
            //yield return new string[] { "4", "FEE", "1.00" };

            //CSV 格式文件
            Console.WriteLine(Check(new string[] { "1", "DEPOSIT", "ABC", "100.00" }));
            double? key = 11.3;

            int? m = key as int?;
            Console.WriteLine("as :" + m);


            for (int i = 0; i < 3; i++)
            {
                Console.Write("请输入你现在的体温：");
                var a = Console.ReadLine();
                Console.WriteLine(温度(Convert.ToInt32(a)));
            }

        }


        #region switch表达式

        /// <summary>
        /// 比较离散值 特定值的匹配项
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string B(string command) =>
        command switch
        {
            "A" => "called A",
            "B" => "called B",
            "C" => "called C",
            "D" => "called D",
            _ => "Invalid string value for command",
        };


        public string 温度(int oc) =>  //and or < = > 在C#9之后才有 关系模式 如果没有处理每个值就会报错
        oc switch
        {
            < 28 => "可能已经硬了",
            (>= 28) and (<= 35) => "低温症",
            (>= 36) and (<= 37) => "正常",
            (> 37) and (<= 42) => "发烧",
            (> 42) and (< 150) => "可能已经熟了",
            >= 150 => "可能已经烧焦了",
        };


        public record 狗(int 名字, int 年龄); //record 记录类型，类似于类，主要用于存储数据，自动实现了Equals和GetHashCode方法 C#9之后才有
        public decimal CalculateDiscount(狗 order) =>   //多个输入
           order switch
           {
               { 名字: > 10, 年龄: > 1000 } => 0.1m,
               ( > 5, > 50) => 0.05m,
               null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
               var someObject => 0m,
           };


        public decimal Check(string[] transaction) =>

            transaction switch
            {
            [_, "DEPOSIT", _, var amount] => decimal.Parse(amount),
            [_, "WITHDRAWAL", .., var amount] => -decimal.Parse(amount),
            [_, "INTEREST", var amount] => decimal.Parse(amount),
            [_, "FEE", var fee] => -decimal.Parse(fee),
                _ => throw new InvalidOperationException($"Record {string.Join(", ", transaction)} is not in the expected format!"),
            };


        //static System.Collections.Generic.IEnumerable<string[]> ReadRecords()
        //{
        //    // 这里可以实现读取交易记录的逻辑
        //    // 示例返回一些测试数据
        //    yield return new string[] { "1", "DEPOSIT", "ABC", "100.00" };
        //    yield return new string[] { "2", "WITHDRAWAL", "DEF", "50.00" };
        //    yield return new string[] { "3", "INTEREST", "2.50" };
        //    yield return new string[] { "4", "FEE", "1.00" };
        //}
        #endregion

        #region switch传奇实例
        public class Car
        {
            public int Passengers { get; set; }
        }



        public class DeliveryTruck
        {
            public int GrossWeightClass { get; set; }
        }



        public class Taxi
        {
            public int Fares { get; set; }
        }

        public class Bus
        {
            public int Capacity { get; set; }
            public int Riders { get; set; }
        }


        public decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car c => c.Passengers switch
                {
                    0 => 2.00m + 0.5m,
                    1 => 2.0m,
                    2 => 2.0m - 0.5m,
                    _ => 2.00m - 1.0m
                },

                Taxi t => t.Fares switch
                {
                    0 => 3.50m + 1.00m,
                    1 => 3.50m,
                    2 => 3.50m - 0.50m,
                    _ => 3.50m - 1.00m
                },

                Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
                Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
                Bus b => 5.00m,

                DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
                DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
                DeliveryTruck t => 10.00m,

                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };

        #endregion
      


        #region 弃元


        #endregion

    }
}
