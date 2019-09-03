using System;

namespace lab_04_class_summary
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance
            var person01 = new Person();

            //console.readline(); to input data from user
            Console.Write("Enter your name: ");
            person01.setName(Console.ReadLine());
            Console.Write("Enter your age: ");
            person01.setAge(int.Parse(Console.ReadLine()));

            Console.WriteLine($"Your name is not {person01.getName()}, it's Bob");
            Console.WriteLine($"Your age is: {person01.getAge()}" );
        }
    }


    //create a class with private and public fields and Get / Set
    class Person
    {
        private string Name;
        private int Age;

        public string getName() { return Name; }
        public void setName(string name) { Name = name; }

        public int getAge() { return Age; }
        public void setAge(int age) { Age = age;  }

    }

}
