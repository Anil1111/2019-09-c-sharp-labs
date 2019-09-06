using System;

namespace lab_09_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            var merc01 = new Mercedes("CHASSIS34623453", "Silver", 5000);
            var merc02 = new Mercedes();

            var aclass = new AClass("CHASSIS123", "Blue", 2500);

            var a104_01 = new A104("CHASSIS456", "Red", 2500);
            var a104_02 = new A104("CHASSIS456", "Red");

            Console.WriteLine(a104_01.GetDescription());
        }
    }


    class Mercedes
    {
        protected string engineChassisID;
        public string Colour { get; set; }
        public int Length { get; set; }

        public Mercedes() { } //blank default one : must have this if have other constructors

        public Mercedes(string engineChassisID, string colour, int length)
        {
            this.engineChassisID = engineChassisID;
            this.Colour = colour;
            this.Length = length;
        }

        public string GetDescription()
        {
            return $"Engine Chassis: {engineChassisID}\n" +
                   $"Colour: {Colour}\n" +
                   $"Length: {Length}";
        }
    } 

     class AClass : Mercedes
    {
        public AClass() { }

        public AClass(string engineChassisID, string colour, int length)
        {
            this.engineChassisID = engineChassisID;
            this.Colour = colour;
            this.Length = length;
        }
    }

    class A104 : AClass
    {
        public A104() { }

        public A104(string engineChassisID, string colour, int length = 2300) : base(engineChassisID, colour, length)
        {
        }
    }


}
