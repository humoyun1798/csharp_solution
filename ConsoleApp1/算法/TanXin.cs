using System;
using System.Collections.Generic;
using System.Text;

namespace AllTest
{

    //  Console.WriteLine("输入对面的钱:");
    //        string Getmoney = Console.ReadLine();
    //Console.WriteLine("输入花的钱:");
    //        string Lostmoney = Console.ReadLine();
    //var have_money = TanXin.getMoney(double.Parse(Getmoney), double.Parse(Lostmoney));
    //Console.WriteLine($"找零的钱：{have_money}");

    /// <summary>
    /// 最少钱币数
    /// 贪心算法 一般用于求最大或最小值
    /// 每一步都是局部最优解，在整体上可能不是最优解，但近似最优解
    /// </summary>
    public static class TanXin
    {
        public static string getMoney(double get, double lost)
        {
            if (get < lost)
            {
                return "nnd，钱不够给爷再来点";
            }
            var have = get - lost;


            var a = new Dictionary<float, int>();

            if (have > 0.1)
            {
                a = getMoney(have);
            }
            var msg = "";
            foreach (var item in a)
            {
                if (item.Value > 0)
                {
                    msg += $"{item.Value}个{item.Key}￥ ";
                }
            }

            return msg;
        }

        public static Dictionary<float, int> getMoney(double have)
        {
            var nums = new float[8] { 100f, 50f, 20f, 10f, 5f, 1f, 0.5f, 0.1f };
            var a = 0;
            var money = new Dictionary<float, int>();
            money.Add(100, 0);
            money.Add(50, 0);
            money.Add(20, 0);
            money.Add(10, 0);
            money.Add(5, 0);
            money.Add(1, 0);
            money.Add(0.5f, 0);
            money.Add(0.1f, 0);


            //money.Keys.Count


            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (have < 0.1)
                {
                    a = 1;
                    break;
                }
                if (have == nums[i])
                {
                    have = have - nums[i];
                    money[nums[i]]++;
                    i = i - 1;

                }
                else if (have < nums[i] && have >= nums[i + 1])
                {
                    have = have - nums[i + 1];
                    money[nums[i + 1]]++;
                    i = i - 1;
                    //money[i - 1]++;

                }

            }


            return money;

        }

    }
}
