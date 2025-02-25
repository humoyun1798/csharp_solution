using System;

namespace Scoket
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("input: 1.Server  2.Client ");
            Console.Write("input:"); var a=Console.ReadLine();
            if (a == "1")
            {
                Server.server();
            }
            else if (a == "2") { 
                Client.client();
            }
            else
            {
                Console.WriteLine("Don't write randomly.");
            }


            Console.WriteLine("Hello World!");
        }
    }
}
