using System;
using System.Collections.Generic;
using System.Threading;

namespace lab_12_rabbit_explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            int populationLimit = 5;
            int currentPopulation = 0;

            List<Rabbit> rabbits = new List<Rabbit>();

            int count = 1;
            while (currentPopulation < populationLimit)
            {
                
                var rabbit = new Rabbit();
                rabbit.ID = count;

                rabbits.Add(rabbit);

                Console.WriteLine($"Rabbit {count} is born..");

                count++;
                currentPopulation++;
                Thread.Sleep(1500);
            }

            Console.WriteLine($"{count - 1} births to reach population limit");
        }
    }

    class Rabbit
    {
        public string Name;
        public int Age;
        public int ID;


        public Rabbit()
        {
            Init("Bob", 1, -1);
        }

        public Rabbit(string name, int age, int id)
        {
            Init(name, age, id);
        }

        private void Init(string name, int age, int id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
    }

    
}
