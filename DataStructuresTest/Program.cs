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
            var buffer = new CircularBuffer(capacity: 3);

            while(true)
            {
                var input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                {
                    buffer.Write(value);
                    continue;
                }

                break;
            }

            Console.WriteLine("Buffer: ");

            while(!buffer.IsEmpty)
            {
                Console.WriteLine("\t" + buffer.Read());
            }

            Console.ReadLine();
        }
    }
}
