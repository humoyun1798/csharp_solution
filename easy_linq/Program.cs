namespace easy_linq
{
    internal class Program
    {



        static void Main(string[] args)
        {
            int[] a=new int[] {3,5,6,7,333,2,64,2};
            //遍历所有数
            //每个数都用 (c)=>c>10
            //如果为true 则放入结果集中
            IEnumerable<int> result = a.Where(c => c>10);

            /*
            
             public WhereArrayIterator(TSource[] source, Func<TSource, bool> predicate)
            {
            //断言
                Debug.Assert(source != null && source.Length > 0);
                Debug.Assert(predicate != null);
                _source = source;
                _predicate = predicate;
            }
             

             */

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            int[] b = new int[] { 3, 5, 6, 7, 333, 2, 64, 2 };


            Func<int, bool> f1=(int a) => a > 10;

            result=MyWhere(b, f1);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


            result = MyWhere2(b, f1);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }


        //v_0.1
        static IEnumerable<int> MyWhere(IEnumerable<int> items,Func<int,bool> fun)
        {
            var result =new List<int>();
            foreach(var item in items)
            {
                if (fun(item))
                {
                    result.Add(item);
                }
            }
            return result; 

        }
        //v_0.2
        static IEnumerable<int> MyWhere2(IEnumerable<int> items, Func<int, bool> fun)
        {
            
            foreach (var item in items)
            {
                if (fun(item))
                {
                    yield return item;
                }
            }
           

        }

    }
}