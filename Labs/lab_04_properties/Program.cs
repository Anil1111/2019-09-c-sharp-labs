using System;

namespace lab_04_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            rabbit.Age = 5;
            //
            //rabbit._bloodType...//invalid
        }
    }


    class Rabbit
    {
        private int _bloodType;//field
        private int _age;
        public string Name { get { return ""; } set {  } } //AUTO-IMPLEMENTED PROPERTY
        public int Age
        {
            get
            {
                return this.Age;
            }
            set
            {
                if (value > 0)
                    this._age = value;//value is c# keyword
            }
        }
    }
}
