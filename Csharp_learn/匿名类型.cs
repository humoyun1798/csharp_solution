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
            Console.WriteLine(j.GetType() == k.GetType()); // True

        }

    }

}
