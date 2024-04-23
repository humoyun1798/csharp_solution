using System.Data.Common;
using System.Linq;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region Part_1 Count Any
            var list = new int[] { 1, 2, 3, 5, 6, 51, 52, 53 };

            Console.WriteLine(list.Count());
            Console.WriteLine(list.Count(c => c > 50));

            //数据至少有一个
            //或者说是否包含这个 复合这个 委托的 数据 ，是否包含 true/false

            Console.WriteLine(list.Any(c => c > 50));


            /*
            判断数据中是否有复合条件的数据 用Any 比Count 效率高 ，Any 碰到符合的就返回了，Count会全部遍历一遍
            */
            #endregion


            #region Part_2 Single SingleOrDefault 、First FirstOrDefault  、OrderBy ThenBy
            //Single 返回唯一一条数据
            Console.WriteLine(list.Single(c => c == 51));
            //Single 返回唯一一条或0条
            Console.WriteLine(list.SingleOrDefault(c => c == -1));


            //返回符合条件的第一条
            Console.WriteLine(list.First(c => c == 51));

            Console.WriteLine(list.FirstOrDefault(c => c == -1));



            var asc = list.OrderBy(c => c);
            var desc = list.OrderByDescending(c => c);

            var ran = new Random();
            var rand = list.OrderBy(c => ran.Next());
            var guid = list.OrderBy(c => Guid.NewGuid());

            //先按c排序，c相同的拿x排序
            var twice = list.OrderBy(c => c).ThenBy(x => x);


            //Skip
            //    Take
            #endregion

            #region Part_3 GroupBy Max Min Average Sum Count 
            Console.WriteLine("Max:" + list.Max(x => x));
            Console.WriteLine("Min:" + list.Min(x => x));
            Console.WriteLine("Avg:" + list.Average(x => x));
            Console.WriteLine("Sum:" + list.Sum(x => x));
            Console.WriteLine("Count:" + list.Count());


            //GroupBy IGrouping<TKey,TSource>类型 
            //Key 自己输入的判断条件  Source 分组后的集合

            var groups = new List<data>();

            groups.Add(new data { name = 1, email = "a" });
            groups.Add(new data { name = 1, email = "b" });
            groups.Add(new data { name = 1, email = "c" });
            groups.Add(new data { name = 2, email = "d" });
            groups.Add(new data { name = 2, email = "e" });
            groups.Add(new data { name = 2, email = "f" });
            groups.Add(new data { name = 3, email = "g" });

            var a = groups.GroupBy(c => c.name);
            var b = a.Select(c => c.First());
            foreach (var it in a)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(it.Key + ":");
                Console.ResetColor();
                foreach (var its in it)
                {
                    Console.Write(its.email + " ");
                }
                Console.WriteLine("");
            }

            foreach (var it in b)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(it.email + " ");
                Console.ResetColor();

            }
            #endregion

            #region Part_4 投影操作Select  
            //将选择的内容重新弄成另一个集合
            //decimal
            //匿名类型
            var nn = new { laoba = "555", dage = "w13" };
            Console.Write(nn.laoba + nn.dage);
            #endregion


            #region 链式调用  ToArray();  ToList();



            #endregion

            #region 还有另一种Linq 写法 像是sql的那种   编译后生成的代码是一样的 ，两种掌握一种就行
            //e groups的每个对象  select 在后面
            var k = from e in groups where e.name > 1 orderby e.name descending select new { e.name };
            Console.WriteLine("k.Count():" + k.Count());
            foreach (var kk in k)
            {
                Console.WriteLine(kk.name);
            }

            //https://www.bilibili.com/video/BV1pK41137He?p=30&spm_id_from=pageDriver&vd_source=e3062b2e209c6b198898bee77b21bc4f

            #endregion 

            //图像处理 可能会比较慢
            //Linq 多数据 多循环可能会出性能问题
            //除非你代码烂得一批
        }
        public class data
        {
            public int name { get; set; }
            public string email { get; set; }

        }
    }
}