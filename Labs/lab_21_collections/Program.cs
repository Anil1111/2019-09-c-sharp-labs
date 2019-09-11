using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_21_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //dicitonary of key-value pairs
            //key is index 0,1,2,3
            //value is string saved
            //pair 0,"hi"  1,"there"
            var dictionary = new Dictionary<int, string>();

            dictionary.Add(0, "hi");
            dictionary.Add(1, "hello");//exception
            dictionary.TryAdd(0, "hi");//silent fail
            dictionary.TryAdd(2, "there");

            foreach(KeyValuePair<int,string> kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key,-10} {kvp.Value}");
            }
            Console.WriteLine("\n\n");


            //Queue  ---------------------------------------------------------
            Console.WriteLine("-------------- Queue ---------------------");
            Queue<int> intQueue = new Queue<int>();
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(9);
            intQueue.Enqueue(4);
            intQueue.Enqueue(5);

            Array.ForEach(intQueue.ToArray(), n => Console.WriteLine(n));
            Console.WriteLine("--------");

            intQueue.Dequeue();
            Array.ForEach(intQueue.ToArray(), n => Console.WriteLine(n));
            Console.WriteLine("--------");

            intQueue.Dequeue();
            intQueue.Dequeue();
            Array.ForEach(intQueue.ToArray(), n => Console.WriteLine(n));
            Console.WriteLine("-------------------------------------------");
            //Queue  -------------------------------------------------------

            //Stack  -------------------------------------------------------
            Console.WriteLine("-------------- Stack ---------------------");
            Stack<int> intStack = new Stack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(9);
            intStack.Push(4);
            intStack.Push(5);

            Array.ForEach(intStack.ToArray(), n => Console.WriteLine(n));
            Console.WriteLine("--------");

            intStack.Pop();
            Array.ForEach(intStack.ToArray(), n => Console.WriteLine(n));
            Console.WriteLine("--------");

            intStack.Pop();
            intStack.Pop();
            Array.ForEach(intStack.ToArray(), n => Console.WriteLine(n));
            Console.WriteLine("-------------------------------------------");

            //ArrayList
            Console.WriteLine("-------------- ArrayList ---------------------");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("hello");
            foreach(var item in arrayList)//must be 'var' otherwise would crash
                Console.WriteLine(item);
            Console.WriteLine("-------------------------------------------");

            //LinkedList
            LinkedList<string> tree = new LinkedList<string>();
           // tree.AddFirst("")

            //HashSet
            Console.WriteLine("-------------- HashSet ---------------------");
            HashSet<string> hashStrings = new HashSet<string>();
            hashStrings.Add("one");
            hashStrings.Add("two");
            hashStrings.Add("three");

            foreach(string str in hashStrings)
                Console.WriteLine(str);
            Console.WriteLine(hashStrings.GetHashCode());
            Console.WriteLine("-------------------------------------------");
        }
    }
}
