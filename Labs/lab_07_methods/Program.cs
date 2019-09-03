using System;

namespace lab_07_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThisAswell();

            var mammal = new Mammal();
            mammal.GetOlder();

            //Method INSIDE method
            void DoThis()
            {
                Console.WriteLine("Do this...");
            }


            CountNumbers(5000);//y only
            CountNumbers(5000, 300);//y and x

            OutParamters(10, 10, out int a);
            Console.WriteLine($"out parameter was {a}");

            TupleMethod();//not using the output. output is wasted
            var tupleOutput = TupleMethod();
            Console.WriteLine($"{tupleOutput.x}, {tupleOutput.y}, {tupleOutput.z}");
        }

        static void DoThisAswell()
        {
            Console.WriteLine("Do this aswell...");
        }

        static void CountNumbers(int y, int x = 100)
        {
            Console.WriteLine(x*y);
        }

        static void OutParamters(int x, int y, out int z)
        {
            z = x * y;//will return this as 'z'
        }

        static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", false);
        }
    }

    class Mammal
    {
        public int Age { get; set; }
        public void GetOlder() { Age++; }
    }
}
