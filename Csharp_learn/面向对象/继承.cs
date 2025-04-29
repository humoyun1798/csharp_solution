using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_learn
{
    public class 继承
    {

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            //public abstract void Introduce(); // 抽象方法 之内定义在抽象类
        }
        public abstract class Person2
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public abstract void Introduce(); // 抽象方法 之内定义在抽象类
        }
        public class Student : Person
        {
            public string StudentId { get; set; }

            public void Study()
            {
                Console.WriteLine($"{Name} is studying.");
            }
        }


        public  class Student2 : Person2
        {
            public  int ssss { get; set; }

            public override sealed void Introduce()
            {
            } // 抽象类的派生类必须实现抽象方法
        }


        public class Student3 : Student2
        {
            public int ssss { get; set; }
            //public override void Introduce()
            //{
            //} // Student2里sealed修饰了，不能重写了
        }


        public class Teacher : Person
        {
            public  string Subject { get; set; }

            public void Teach()
            {
                Console.WriteLine($"{Name} is teaching {Subject}.");
            }
        }

        public class OldTeacher : Teacher
        {

        }

        public void aa()
        {
            var k = new OldTeacher();
            k.Subject = "数学";
        }

        public interface I接口
        {
            void a1();
        }
        public interface I接口2
        {
            void a2();
        }

        public class ll : 对象, I接口, I接口2
        {
            public void a1()
            {
                Console.WriteLine("l1");
            }

            public void a2() //继承的接口方法必须实现
            {
                Console.WriteLine("l2");
            }
        }
    }
}
