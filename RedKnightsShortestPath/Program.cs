using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedKnightsShortestPath
{
    class Program
    {
        static Tuple<int[], int> decideMovement(int n, int i_start, int j_start, int i_end, int j_end)
        {
            if (i_start > i_end && j_start > j_end) //Upper left
            {
                i_start -= 2;
                j_start -= 1;
                
                return new Tuple<int[], int>(new[] { i_start, j_start }, 1);
            }

            if (i_start > i_end && j_start < j_end) //Upper right
            {
                i_start -= 2;
                j_start += 1;
                return new Tuple<int[], int>(new[] { i_start, j_start }, 2);
            }

            if (i_start == i_end && j_start < j_end) //Right
            {
                j_start += 2;
                return new Tuple<int[], int>(new[] { i_start, j_start }, 3);
            }

            if (i_start < i_end && j_start <= j_end) //Lower Right
            {
                i_start += 2;
                j_start += 1;
                return new Tuple<int[], int>(new[] { i_start, j_start }, 4);
            }

            if (i_start < i_end && j_start >= j_end) //Lower Left
            {
                i_start += 2;
                j_start -= 1;
                return new Tuple<int[], int>(new[] { i_start, j_start }, 5);
            }

            if (i_start == i_end && j_start > j_end) //Left
            {
                j_start -= 2;
                return new Tuple<int[], int>(new[] { i_start, j_start }, 6);
            }
            
            return new Tuple<int[], int>(new[] { i_start, j_start }, 0); //Impossible
        }

        static void printShortestPath(int n, int i_start, int j_start, int i_end, int j_end)
        {
            int qtdMovements = 0;
            List<string> lstMovements = new List<string>();
            bool resultIsImpossible = false;
            List<List<int>> visitedPositions = new List<List<int>>(); 

            while ((i_start != i_end || j_start != j_end) && !resultIsImpossible)
            {
                Tuple<int[], int> result = decideMovement(n, i_start, j_start, i_end, j_end);

                if (visitedPositions.Any(p => p[0] == result.Item1[0] && p[1] == result.Item1[1]))
                    resultIsImpossible = true;

                i_start = result.Item1[0];
                j_start = result.Item1[1];

                qtdMovements++;
                lstMovements.Add(ConvertOrderToMovement(result.Item2));
                visitedPositions.Add(result.Item1.ToList());

                resultIsImpossible = resultIsImpossible ? true : lstMovements.Any(p => p == "Impossible");
            }

            if (!resultIsImpossible)
                Console.WriteLine(qtdMovements);

            lstMovements.Sort();
            lstMovements.Reverse();

            Console.WriteLine(resultIsImpossible ? "Impossible" : string.Join(" ", lstMovements));
        }

        static string ConvertOrderToMovement(int order)
        {
            switch (order)
            {
                case 1:
                    return "UL";
                case 2:
                    return "UR";
                case 3:
                    return "R";
                case 4:
                    return "LR";
                case 5:
                    return "LL";
                case 6:
                    return "L";
            }

            return "Impossible";
        }

        static void Main(string[] args)
        {
            int board = 7;
            int i_start = 6;
            int j_start = 6;
            int i_end = 0;
            int j_end = 1;

            printShortestPath(board, i_start, j_start, i_end, j_end);
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("4");
            Console.WriteLine("UL UL UL L");

            Console.WriteLine();

            board = 6;
            i_start = 5;
            j_start = 1;
            i_end = 0;
            j_end = 5;
            printShortestPath(board, i_start, j_start, i_end, j_end);
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("Impossible");

            Console.WriteLine();

            board = 7;
            i_start = 0;
            j_start = 3;
            i_end = 4;
            j_end = 3;
            printShortestPath(board, i_start, j_start, i_end, j_end);
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("2");
            Console.WriteLine("LR LL");

            Console.WriteLine();

            board = 10;
            i_start = 9;
            j_start = 9;
            i_end = 6;
            j_end = 3;
            printShortestPath(board, i_start, j_start, i_end, j_end);
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("Impossible");

            Console.WriteLine();

            board = 70;
            i_start = 7;
            j_start = 15;
            i_end = 67;
            j_end = 3;
            printShortestPath(board, i_start, j_start, i_end, j_end);
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("30");
            Console.WriteLine("LR LR LR LR LR LR LR LR LR LL LL LL LL LL LL LL LL LL LL LL LL LL LL LL LL LL LL LL LL LL");

            Console.WriteLine();

            board = 100;
            i_start = 2;
            j_start = 24;
            i_end = 92;
            j_end = 45;
            printShortestPath(board, i_start, j_start, i_end, j_end);
            Console.WriteLine("**** Resultado ****");
            Console.WriteLine("45");
            Console.WriteLine("LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LR LL LL LL LL LL LL LL LL LL LL LL LL");

            Console.ReadKey();
        }
    }
}
