using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Csharp_learn.虚方法;

namespace Csharp_learn
{
    public class 弃元
    {

        public string q = "1";
        public string w = "2";


        public void Deconstruct(out string j, out string k)
        {
            j = q;
            k = w;
        }

        public void a()
        {
            var v = new 弃元();
            var (_, b) = v; //用弃元解构去掉不想要的值
            Console.WriteLine($"{b.ToString()}"); //2




            Console.WriteLine("About to launch a task...");
            Task.Run(() =>
            {
                var iterations = 0;
                for (int ctr = 0; ctr < int.MaxValue; ctr++)
                    iterations++;
                Console.WriteLine("Completed looping operation...");
                throw new InvalidOperationException();
            });
            //await Task.Delay(5000);
            Console.WriteLine("Exiting after 5 second delay");

        }

    }
        

       
}
