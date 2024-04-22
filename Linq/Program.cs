using System.Linq;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region Count Any
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


            #region Single First
            //Single 返回唯一一条数据
            Console.WriteLine(list.Single(c=>c==51));
            //Single 返回唯一一条或0条
            Console.WriteLine(list.SingleOrDefault(c=>c==-1));


            //返回符合条件的第一条
            Console.WriteLine(list.First(c => c == 51));

            Console.WriteLine(list.FirstOrDefault(c => c == -1));



            var asc = list.OrderBy(c => c);
            var desc=list.OrderByDescending(c => c);

            var ran=new Random();
            var rand= list.OrderBy(c => ran.Next()); 
            var guid=list.OrderBy(c => Guid.NewGuid());

            //先按c排序，c相同的拿x排序
            var twice=list.OrderBy(c => c).ThenBy(x=>x);


            //Skip
            //    Take
            #endregion
        }
    }
}