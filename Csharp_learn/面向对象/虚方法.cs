using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_learn
{
    public class 虚方法
    {

        public class Shape
        {
            public virtual void Draw()
            {
                Console.WriteLine("a shape.");
            }
        }

        public class Triangle : Shape
        {
            public override void Draw()  //基类的方法类型是 abstract抽象的 或者是virtual虚拟的 才可以被重写
            {
                Console.WriteLine("Drawing a triangle.");
                base.Draw();
            }
        }

        public class Circle : Shape
        {
            public new void Draw()  //new 方法表示 不是继承的Shape 只是同名方法   ，使用新成员隐藏基类成员
            {
                Console.WriteLine("Drawing a Circle.");
                base.Draw();
            }
        }


        public void a()
        {

            Console.WriteLine("======= overrider =======");
            Triangle t =new Triangle();
            t.Draw();//新

            Shape s = t; //重写继承的方法，调用积累的方法会调用被重现的方法
            s.Draw(); //新



            Console.WriteLine("======= new =======");

            Circle B = new Circle();
            B.Draw();  // 用 new 修饰 //新

            Shape A = (Shape)B;
            A.Draw();  // 老
            Console.WriteLine("======= sealed override =======");


            D d=new D();
            d.DoWork(); //d
            C c = (C)d;
            c.DoWork();//d  sealed overrider 从这里开始继承 前面的 A B都不算了
            B b = (B)d;
            b.DoWork();//d
            A a = (A)d;
            a.DoWork();//d

        }



        public class A
        {
            public virtual void DoWork() {
                Console.WriteLine("A");
            }
        }

        public class B : A
        {
            public override void DoWork() {
                Console.WriteLine("B");

            }
        }

        public class C : B
        {
            public sealed override void DoWork() {
            
                Console.WriteLine("C");
            }
        }

        public class D : C
        {
            public new void DoWork() {
                Console.WriteLine("D");

            }
        }



    }
}
