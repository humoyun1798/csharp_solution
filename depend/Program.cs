namespace depend
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var a = "123,232,344,222,322,55,1,23,5,7,944";
            var item = a.Split(",");
            var sum = 0;
            for(int i = 0; i < item.Length; i++)
            {
                sum += int.Parse(item[i]);
            }

            var avg=sum/item.Length;


            var w = "hello World HHHHahahaha";
            w=w.ToLower();
            var list = w.GroupBy(w => w).Select(c => new { c.Key, c }).ToLsit();
            Console.WriteLine(list);

            Console.WriteLine($"Hello, World! {avg}");
        }
    }
}