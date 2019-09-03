using System;

namespace lab_03_private_public_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.Name = "Fantasia";
            person01.setNINO("ABC123");

            Console.WriteLine(person01.GetNINO());
        }
    }

    class Person
    {
        private string NINO;
        public string Name;

        //Getter and Setter methods to read / write data
        public string GetNINO() { return NINO; }
        public void setNINO(string nino) { NINO = nino; }
    }
}
