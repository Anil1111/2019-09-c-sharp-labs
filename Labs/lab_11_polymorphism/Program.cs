using System;

namespace lab_11_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent(40, "Bob");
            p.Add();
            p.Add();
            Console.WriteLine(p.GetDescriptions());

            var c = new Child(10, "Jimmy");
            c.Add();
            Console.WriteLine(c.GetDescriptions());
        }
    }

    class Parent
    {
        public int Age;
        public string Name;

        public Parent() { }

        public Parent(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual void Add()
        {
            Age++;
        }

        public virtual string GetDescriptions()
        {
            return $"I am a PARENT and Number is: {Age} and Description is: {Name}";
        }
    }

    class Child : Parent
    {
        public Child(int age, string name) : base(age, name)
        {
        }

        public override void Add()
        {
            Age += 40;
            base.Add();
        }

        public override string GetDescriptions()
        {
            return $"I am a CHILD and I am now older than my parent: Age is: {Age} and Name is: {Name}";
        }
    }

    //CREATE A BASE CLASS (PARENT)

    //CREATE CHILD CLASS

    //ADD 2 FIELDS (ONE NUMERIC)

    //ADD CONSTRUCTOR

    //PARENT ADD METHOD (CHANGE NUMBER)

    //11.40
}
