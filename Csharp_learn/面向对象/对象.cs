using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_learn
{
    public class 对象
    {
        public string q { get; set; }
        public string w { get; set; }
        public struct 结构体 //结构体
        {
            public string Name;
            public int Age;
            public 结构体(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
        public void a()
        {

            var j=new 对象();
            j.q = "1";
            j.w = "一";



            var k = j;
            k.q = "2";
            k.w = "二";
            Console.WriteLine(j.q); //2
            Console.WriteLine(k.q); //2



            //由于结构是值类型，因此结构对象的变量具有整个对象的副本。 结构的实例也可使用 new 运算符来创建，但这不是必需
            var jj =new 结构体("Tom", 18);

            var kk = jj;
            kk.Name = "Jerry";

            Console.WriteLine(jj.Name); //Tom
            Console.WriteLine(kk.Name); //Jerry
            //kk 和 jj 是两个实例了

        }

    }
}
