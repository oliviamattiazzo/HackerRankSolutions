using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCity
{
    public class Program
    {
        const int MODULO = 1000000007;

        static int hackerrankCity(int[] A)
        {
            int numberIterations = A.Count();
            long sumDistances = 0;

            int nodes = 1;
            int connections = 0;
            long paths = 1;
            long exp = 3;
            long sumNodesPreviousIteration = 0;

            for (int counter = 1; counter <= numberIterations; counter++)
            {
                sumNodesPreviousIteration = sumDistances * 4;
                nodes *= 4;
                connections = (nodes / 2) + (counter % 2 == 0 ? 2 : 0);
                paths *= 5;
                if (counter > 1)
                    exp *= 3;

                sumDistances = sumNodesPreviousIteration;
                for (int counterExp = 1; counterExp <= exp; counterExp = counterExp + 3)
                {
                    sumDistances += (paths * (counterExp) * A[counter - 1]) + ((nodes + connections) * (1 + counterExp) * A[counter - 1]) + (nodes * (2 + counterExp) * A[counter - 1]);
                }
            }

            Console.WriteLine(sumDistances);
            
            return (int)(sumDistances % MODULO);
        }

        static void Main(string[] args)
        {
            int[] A = { 1 };
            int resultFirstTest = hackerrankCity(A);
            Console.WriteLine(resultFirstTest);
            Console.WriteLine("Result should be 29");

            int[] B = { 2, 1 };
            int resultSecondTest = hackerrankCity(B);
            Console.WriteLine(resultSecondTest);
            Console.WriteLine("Result should be 2641");

            Console.ReadKey();
        }
    }
}
