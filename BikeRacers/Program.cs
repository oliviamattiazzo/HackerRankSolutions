using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacers
{
    class Program
    {
        static int CalcTime(int[] biker, int[] bike)
        {
            int calculatedTime = 0;

            if (bike[0] != biker[0])
                calculatedTime += (bike[0] > biker[0] ? bike[0] : biker[0]) - biker[0];
            if (bike[1] != biker[1])
                calculatedTime += (bike[1] > biker[1] ? bike[1] : biker[1]) - biker[1];

            return calculatedTime;
        }

        static long bikeRacers(int[][] bikers, int[][] bikes, int neededBikes)
        {
            List<int[]> lstBikers = bikers.ToList();
            List<int[]> lstBikes = bikes.ToList();
            
            List<Tuple<int, int[]>> lstTimes = new List<Tuple<int, int[]>>();
            int idBiker = 0;
            int idBike = 0;

            lstBikers.ForEach(bkr =>
            {
                idBiker++;
                idBike = 0;
                lstBikes.ForEach(bk =>
                {
                    idBike++;
                    int calculatedTime = CalcTime(bkr, bk);

                    if (!lstTimes.Any(p => p.Item2[1] == idBike) || calculatedTime < lstTimes.First(p => p.Item2[1] == idBike).Item1)
                        lstTimes.Add(new Tuple<int, int[]>(calculatedTime, new[] { idBiker, idBike }));
                });
            });

            lstTimes.OrderBy(p => p.Item1);

            List<int> bestTimes = new List<int>();
            for (int counter = 1; counter <= neededBikes; counter++)
            {
                bestTimes.Add(lstTimes.FirstOrDefault(p => p.Item2[0] == counter).Item1);
            }

            return bestTimes[neededBikes - 1] * bestTimes[neededBikes - 1];
        }

        static void Main(string[] args)
        {
            int numberBikers = 3;
            int numberBikes = 3;
            int neededBikes = 2;
            int[] coordinatesBikers11 = { 0, 1 };
            int[] coordinatesBikers12 = { 0, 2 };
            int[] coordinatesBikers13 = { 0, 3 };
            int[][] bikers1 = { coordinatesBikers11, coordinatesBikers12, coordinatesBikers13 };
            int[] coordinatesBikes11 = { 100, 1 };
            int[] coordinatesBikes12 = { 200, 2 };
            int[] coordinatesBikes13 = { 300, 3 };
            int[][] bikes1 = { coordinatesBikes11, coordinatesBikes12, coordinatesBikes13 };

            Console.WriteLine(bikeRacers(bikers1, bikes1, neededBikes));
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("40000");

            Console.WriteLine();

            numberBikers = 4;
            numberBikes = 4;
            neededBikes = 2;
            int[] coordinatesBikers21 = { 145, 862 };
            int[] coordinatesBikers22 = { 533, 105 };
            int[] coordinatesBikers23 = { 34, 192 };
            int[] coordinatesBikers24 = { 897, 656 };
            int[][] bikers2 = { coordinatesBikers21, coordinatesBikers22, coordinatesBikers23, coordinatesBikers24 };
            int[] coordinatesBikes21 = { 902, 518 };
            int[] coordinatesBikes22 = { 78, 108 };
            int[] coordinatesBikes23 = { 658, 369 };
            int[] coordinatesBikes24 = { 127, 364 };
            int[][] bikes2 = { coordinatesBikes21, coordinatesBikes22, coordinatesBikes23, coordinatesBikes24 };

            Console.WriteLine(bikeRacers(bikers2, bikes2, neededBikes));
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("19069");

            Console.ReadKey();
        }
    }
}
