using System;

namespace lab_16_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "hello world";
            if (s.StartsWith("hello"))
            {
                Console.WriteLine("world");
            }

            Console.WriteLine(s.AmazingExtraStringMethod());
        }
    }

    abstract public class Holiday
    {
        public abstract void Travel();

        public void Places() { Console.WriteLine("Visiting Vienna, Salzburg"); }

        public void Activities() { Console.WriteLine("Skiiing, Walking, Fishing"); }
    }

    public class HolidayWithTravel : Holiday
    {
        public override void Travel() { Console.WriteLine("By Train, Eurostar, then hire a car"); }
    }

    public sealed class Security { }

    //class CannotInherit : Security { }


    public static class AddingToStrings
    {
        public static string AmazingExtraStringMethod(this string s)
        {
            s = s + "---> add your comment";
            return s;
        }

        public static string AmazingExtraStringMethod(this HolidayWithTravel s)
        {
            return "---> add your comment";
        }
    }
}
