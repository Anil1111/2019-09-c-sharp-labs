using System;

namespace lab_06_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Labrador labr = new Labrador();
            labr.Name = "Stewart";
        }
    }

    class Dog
    {
        public string Name { get; set; }
    }

    class Labrador : Dog
    {
        public int Age { get; set; }
    }
}
