using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_17_rabbit_database_explosion
{
    class Program
    {
        static List<Rabbit> rabbits;
        static void Main(string[] args)
        {
            DisplayRabbits();

            //new rabbit : WPF Textbox01.text ==> use for Age, Name (2 boxes)
            //button Add : run this code

            var newRabbit = new Rabbit()
            {
                Age = 0,
                Name = $"Rabbit{rabbits.Count + 1}"
            };

            using (var db = new RabbitDbEntities())
            {
                
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }
            System.Threading.Thread.Sleep(200);

            DisplayRabbits();
        }

        static void DisplayRabbits()
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                Console.WriteLine($"{"ID",-5}" + $"{"Name",-12}" + $"Age");
                rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitId,-5}" + $"{rabbit.Name,-12}" + $"{rabbit.Age}"));
                Console.WriteLine("----------------------");
            }
        }
    }
}
