using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Csharp_learn
{
    public class 匿名类型
    {
        //private Node? head;

        public void a()
        {

            var a = new { Name = "Tom", Age = 18 };
            //var b = new { Name = null, Age = 18 };//匿名类型包含一个或多个公共只读属性。 包含其他种类的类成员（如方法或事件）为无效。 用来初始化属性的表达式不能为 `null`、匿名函数或指针类型。




            var c = new { Name = new { tom = "1" }, Age = 18 };

            var d = new[]
            {
                new { Name = "Tom", Age = 18 },
                new { Name = "Jerry", Age = 19 }
            };//将隐式键入的本地变量与隐式键入的数组相结合创建匿名键入的元素的数组


            //var kk = (string)a;//匿名类型class类型，object的派生，无法强制转换为除object以外的任何类型
            

            var j = new { Name = "Tom", Age = 18 };
            var k = new { Name = "Tom", Age = 19 };
            //如果程序集中的两个或多个匿名对象初始值指定了属性序列，这些属性采用相同顺序且具有相同的名称和类型，则编译器将对象视为相同类型的实例。 它们共享同一编译器生成的类型信息。
            Console.Write("1:"); // True
            Console.WriteLine(j.GetType() == k.GetType()); // True


            var gg = new { Name = "Tom", Age = 18 };
            var mm= new { Name = "Tom", Age = 18 };
            Console.Write("2:");
            Console.WriteLine(gg==mm); // False
            Console.WriteLine(gg.Equals(mm)); // True
            //由于匿名类型上的 Equals 和 GetHashCode 方法是根据方法属性的 Equals 和 GetHashCode 定义的，因此仅当同一匿名类型的两个实例的所有属性都相等时，这两个实例才相等


            //匿名类型的辅助功能级别为 internal，因此在不同程序集中定义的两种匿名类型并非同一类型。 因此，当在不同的程序集中进行定义时，匿名类型的实例不能彼此相等，即使其所有属性都相等。

        }

    }

}
