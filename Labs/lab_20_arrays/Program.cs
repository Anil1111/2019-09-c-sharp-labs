using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_20_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array01 = new int[10];
            int[] arrayLiteral = new int[] { 1, 2, 3, 4, 5 };
            string[] stringLiteral = new string[] { "one", "two", "three" };

            int[,] _2darray = new int[10, 10];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    _2darray[i, j] = (i * i) * (j * j);
                }
            }

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sum += _2darray[i, j];
                }
            }

            Console.WriteLine(sum);

            int[,,] _3darray = new int[10, 10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        _3darray[i, j, k] = (i * i) * (j * j) * (k * k);
                    }
                }
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        sum += _3darray[i, j, k];
                    }
                }
            }
            Console.WriteLine(sum);


            //jagged array
            int[][] myJaggedArray = new int[10][];

            myJaggedArray[0] = new int[5];
            Console.WriteLine(myJaggedArray[0].Length); //5
            myJaggedArray[1] = new int[] { 1, 2, 3 };
        }
    }
}
