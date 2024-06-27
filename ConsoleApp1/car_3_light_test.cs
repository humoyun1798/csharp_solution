using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{

    public class car_3_light_test
    {

        public enum Title
        {

            关灯 = 0,
            近光灯 = 2,
            远光灯 = 3,
            远近光交替 = 4,
            开启示廓灯双闪 = 5

        }


        public class OO
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }

        public static List<OO> RandStr()
        {
            var str = new List<OO>();
            var str2 = new List<OO>();
            var o = new OO();

            str2.Add(new OO() { Key = "模拟夜间行驶", Value = 2 });

            str.Add(new OO() { Key = "通过路口", Value = 2 });
            str.Add(new OO() { Key = "同方向近距离跟车行驶", Value = 2 });
            str.Add(new OO() { Key = "通过急弯路", Value = 4 });
            str.Add(new OO() { Key = "通过拱桥", Value = 4 });
            str.Add(new OO() { Key = "通过坡路", Value = 4 });
            str.Add(new OO() { Key = "人行横道", Value = 4 });
            str.Add(new OO() { Key = "没有信号灯的路口", Value = 4 });
            str.Add(new OO() { Key = "会车", Value = 2 });
            str.Add(new OO() { Key = "超车", Value = 4 });
            str.Add(new OO() { Key = "路边临时停车", Value = 5 });
            str.Add(new OO() { Key = "在照明良好的道路上行驶", Value = 2 });
            str.Add(new OO() { Key = "在有路灯的道路上行驶", Value = 2 });
            str.Add(new OO() { Key = "进入无照明的道路上行驶", Value = 3 });
            str.Add(new OO() { Key = "进入照明不良的道路上行驶", Value = 3 });

            Random random = new Random();
            str2.AddRange(str.OrderBy(x => random.Next()).ToList());


            str2.Add(new OO() { Key = "结束模拟夜间行驶", Value = 0 });
            return str2;

        }


        public static void Test()
        {
            var list = RandStr();
            var bb = true;
            var i = 0;
            var value = "";
            foreach (var item in list)
            {
                i++;
                WriteLine($"==== {i} ====");
                WriteLine(item.Key);
                WriteLine("0 关灯；2近光灯；3远光灯；4远近交替；5示廓双闪");
                var value2 = Console.ReadLine();

                if (!string.IsNullOrEmpty(value2))
                {
                    value = value2;
                }

                if (item.Value.ToString() == value)
                {
                    WriteLine("success", ConsoleColor.Green);
                }
                else
                {
                    bb = false;
                    WriteLine("error", ConsoleColor.Red);
                    WriteLine($"答案:{((Title)item.Value).ToString()}", ConsoleColor.Red);
                }

            }

            if (bb)
            {
                WriteLine("==== 恭喜您灯光项目满分ᕕ( ᐛ )ᕗ ====", ConsoleColor.Green);
            }
            Console.ReadLine();

        }

        public static void WriteLine(string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        //模拟夜间行驶
        //通过路口
        //同方向近距离跟车行驶
        //通过急弯路
        //通过拱桥
        //通过坡路
        //人行横道
        //没有信号灯的路口
        //会车
        //超车
        //路边临时停车
        //在照明良好的道路上行驶
        //在有路灯的道路上行驶
        //进入无照明的道路上行驶
        //进入照明不良的道路上行驶
        //结束模拟夜间行驶



    }
}


