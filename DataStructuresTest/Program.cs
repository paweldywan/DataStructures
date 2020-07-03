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
        static void ConsoleWrite(double data)
        {
            Console.WriteLine(data);
        }

        static void Main(string[] args)
        {
            var buffer = new Buffer<double>();

            ProcessInput(buffer);

            ProcessOutput(buffer);

            ProcessBuffer(buffer);

            Console.ReadLine();
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");

            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();

                //Console.WriteLine("\t" + buffer.Read());
            }

            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }

                break;
            }
        }

        private static void ProcessOutput(Buffer<double> buffer)
        {
            buffer.Dump(ConsoleWrite);

            var asInts = buffer.AsEnumerableOf<double, int>();

            foreach (var item in asInts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
