using System;
using System.Collections.Generic;

namespace lab_05_list_of_rabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a lab

            // count 1 to 10

            // create Rabbits

            // name = "Rabbit" + 0 + i    Rabbit01, Rabbit02,  
            // age = i
            // add to list of rabbits
            // print out list at end 


            List<Rabbit> rabbits = new List<Rabbit>();

            for(int i = 1; i <= 10; i++)
            {
                rabbits.Add(new Rabbit($"Rabbit{i:D2}", i));
            }

            foreach(Rabbit rabbit in rabbits)
            {
                Console.WriteLine(rabbit.Name);
            }
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }

 
        public Rabbit(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
