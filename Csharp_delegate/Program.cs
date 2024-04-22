namespace Csharp_delegate
{
    internal class Program
    {
        //委托指向 普通方法
        static void Main(string[] args)
        {
            var a=new demo_1();
            a.Main();

            D d1 = F1;
            d1();
            d1 = F2;
            d1();

            //d1 = Add; //委托类型不一致
            A a1 = Add;
            Console.WriteLine(a1(1, 1));

            #region Action 泛型委托 无返回值
            Action f = F1;
            f();

            // in in 
            Action<int,string> f3 = ActionF3;
            f3(6, "你好");
            #endregion

            #region Func 泛型委托 有返回值
            //in in out 
            Func<int,int,int> f1 = Add;
            Console.WriteLine(f1(1, 3));
            #endregion

        }
        static  void F1()
        {
            Console.WriteLine("F1");
        }
        static void F2()
        {
            Console.WriteLine("F2");
        }
        static void ActionF3(int a,string k)
        {
            Console.WriteLine(k+a);
        }
        static int Add(int a,int b)
        {
            return a + b;
        }

    }

    //自定义委托类型
    delegate void D();
    delegate int A(int a, int b);
}