using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_learn
{
    public class 索引器
    {


        class SampleCollection<T>
        {
            // Declare an array to store the data elements.
            private T[] arr = new T[100];

            // Define the indexer to allow client code to use [] notation.
            public T this[int i]
            {
                //get { return arr[i]; }
                //set { arr[i] = value; }

                get => arr[i];
                set => arr[i] = value;
            }
        }

        class SampleCollection2<T>
        {
            // Declare an array to store the data elements.
            private T[] arr = new T[100];
            int nextIndex = 0;

            // Define the indexer to allow client code to use [] notation.
            public T this[int i] => arr[i];

            public void Add(T value)
            {
                if (nextIndex >= arr.Length)
                    throw new IndexOutOfRangeException($"The collection can hold only {arr.Length} elements.");
                arr[nextIndex++] = value;
            }
        }

        #region Csharp 不将索引参数类型限制为整数

        // Using a string as an indexer value
        class DayCollection
        {
            string[] days = ["Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat"];

            // Indexer with only a get accessor with the expression-bodied definition:
            public int this[string day] => FindDayIndex(day);

            private int FindDayIndex(string day)
            {
                for (int j = 0; j < days.Length; j++)
                {
                    if (days[j] == day)
                    {
                        return j;
                    }
                }

                throw new ArgumentOutOfRangeException(
                    nameof(day),
                    $"Day {day} is not supported.\nDay input must be in the form \"Sun\", \"Mon\", etc");
            }
        }

        #endregion
        static void a()
        {
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            Console.WriteLine(stringCollection[0]);
        }

        // The example displays the following output:
        //       Hello, World.

        static void b()
        {
            var stringCollection = new SampleCollection2<string>();
            stringCollection.Add("Hello, World");
            System.Console.WriteLine(stringCollection[0]);
        }
    }
}
