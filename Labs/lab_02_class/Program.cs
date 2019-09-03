using System;

namespace lab_02_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //use the class : create a new Dog object
            var dog01 = new Dog();
            dog01.Name = "Scooby";
            dog01.Age = 2;
            dog01.Height = 50;

            //grow our dog
            dog01.Grow();

            //print new age and height
            Console.WriteLine($"Age is: {dog01.Age}");
            Console.WriteLine($"Height is: {dog01.Height}");

            //grow our dog
            dog01.Grow();

            //print new age and height
            Console.WriteLine($"Age is: {dog01.Age}");
            Console.WriteLine($"Height is: {dog01.Height}");
        }
    }

    
}
