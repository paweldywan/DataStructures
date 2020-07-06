using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = args;

            var buffer = new CircularBuffer<double>(capacity: 3);
            buffer.ItemDiscarded += ItemDiscarded;

            ProcessInput(buffer);

            WriteSeparator();

            buffer.Dump(d => Console.WriteLine(d));

            WriteSeparator();

            TestMap(buffer);

            WriteSeparator();

            ProcessBuffer(buffer);

            WriteSeparator();

            TestLocalFunction();


            Console.ReadLine();
        }

        private static void ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine("Buffer full. Discarding {0} New item is {1}", e.ItemDiscarded, e.NewItem);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                {
                    buffer.Write(value);

                    continue;
                }

                break;
            }
        }

        private static void WriteSeparator()
        {
            Console.WriteLine("---");
        }

        private static void TestMap(CircularBuffer<double> buffer)
        {
            var asDates = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));

            foreach (var date in asDates)
            {
                Console.WriteLine(date);
            }
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;

            Console.WriteLine("Buffer: ");

            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }

            Console.WriteLine(sum);
        }

        private static void TestLocalFunction()
        {
            void print(bool d) => Console.WriteLine(d);

            double square(double d) => d * d;

            double add(double x, double y) => x + y;

            bool isLessThanTen(double d) => d < 10;


            print(isLessThanTen(square(add(3, 5))));
        }
    }
}
