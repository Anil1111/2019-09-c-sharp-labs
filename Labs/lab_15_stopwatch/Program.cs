using System;
using System.Diagnostics;
using System.IO;

namespace lab_15_stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();

            Console.WriteLine("Stopwatch started...");
            s.Start();

            int counter = 0;
            for (int i = 0; i < 100_000_000; i++)
                counter++;

            s.Stop();
            Console.WriteLine("Stopwatch stopped...");
            Console.WriteLine(s.Elapsed);
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.WriteLine(s.ElapsedTicks);


            for(int i=0; i < 1_000_000; i++)
            {
                File.AppendAllText($"C:\\trash files\\{DateTime.Now.ToLongDateString()}_{i}.txt", "some text");
            }
        }
    }
}
