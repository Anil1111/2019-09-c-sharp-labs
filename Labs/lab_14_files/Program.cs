using System;
using System.IO;

namespace lab_14_files
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("myFile.txt"))
            {
                var string1 = File.ReadAllText("myFile.txt");
                Console.WriteLine(string1);
                File.WriteAllText("myFile1.txt", string1);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            Console.WriteLine("\n\n ======  save on multiple lines =======");
            File.WriteAllText("multipleLines.txt", "some\ndata\non\ndifferent\nlines");
            Console.WriteLine(File.ReadAllText("multipleLines.txt"));

            Console.WriteLine("\n\n ======  save on multiple lines better way =======");
            File.WriteAllText("multipleLines2.txt", "some" + Environment.NewLine + "data" + Environment.NewLine + "on" +
                Environment.NewLine + "different" + Environment.NewLine + "lines");
            Console.WriteLine(File.ReadAllText("multipleLines2.txt"));

            Console.WriteLine("\n\n ======  save arrays to multiple lines =======");
            string[] myArray = new string[] { "some", "data", "in", "multiple", "lines" };
            File.WriteAllLines("multiLineFile.txt", myArray);
            var outputArray = File.ReadAllLines("multiLineFile.txt");
            Array.ForEach(outputArray, item => Console.WriteLine(item));

            Console.WriteLine("\n\n ======  Logging =======");

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log", $"Event happened at time {DateTime.Now}" + Environment.NewLine);
                Console.WriteLine($"Logged {i} lines");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine(File.ReadAllText("myLogFile.log"));

        }
    }
}
