using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab_12_rabbit_explosion_3age
{
    class Program
    {
        static void Main(string[] args)
        {
            lab_just_do_it_rabbit_explosion.Rabbit_Exponentional_Growth(1000);
        }
    }
    public class lab_just_do_it_rabbit_explosion
    {
        public static (int years, int population) Rabbit_Exponentional_Growth(int populationLimit)
        {
            int minBirthYear = 3;
            int currentPopulation = 0;
            int years = 0;

            var s = new Stopwatch();
            s.Start();

            var grandpa = new Rabbit("Grandpa", 0, minBirthYear);
            while (currentPopulation < populationLimit)
            {
                grandpa.AttemptBirth("bob", 0, minBirthYear);

                currentPopulation = grandpa.GetRabbitCount();

                Console.WriteLine($"Rabbits population: {currentPopulation}");

                years++;
                //  Thread.Sleep(10);
            }

            s.Stop();

            Console.WriteLine($"{years} years to reach population limit");
            Console.WriteLine($"Stopwatch millis: {s.ElapsedMilliseconds}");
            Console.WriteLine($"Stopwatch ticks: {s.ElapsedTicks}");

            return (years, currentPopulation);
        }
    }

    class Rabbit
    {
        public string Name;
        public int Age;
        public int MinBirthAge;
        public string DOB;

        List<Rabbit> rabbits;

        public Rabbit()
        {
            Init("Bob", 0, 3);
        }

        public Rabbit(string name, int age, int birth_age)
        {
            Init(name, age, birth_age);
        }

        private void Init(string name, int age, int birth_age)
        {
            rabbits = new List<Rabbit>();
            this.Name = name;
            this.Age = age;
            this.MinBirthAge = birth_age;
        }

        private void Birthday()
        {
            Age++;
        }

        public void AttemptBirth(string name, int age, int birth_age)
        {
            Birthday();

            if (Age < MinBirthAge)
                return;

            for (int i = 0; i < rabbits.Count; i++)
                rabbits[i].AttemptBirth(name, age, birth_age);

            var rabbit = new Rabbit(name, 0, birth_age);
            rabbit.DOB = DateTime.Now.ToString();
            rabbits.Add(rabbit);
        }
        public int GetRabbitCount()
        {
            int total = 0;

            for (int i = 0; i < rabbits.Count; i++)
                total += rabbits[i].GetRabbitCount();

            return total + 1;//+1 for self
        }
    }
}
