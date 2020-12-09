using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int sum1 = 0;
            for (int i = 0; i < n; i++)
            {
                sum1 += matrix[i, i];
            }
            int sum2 = 0;
            int index = n-1;
            for (int i = 0; i < n; i++)
            {
                sum2+=matrix[i, index];
                index--;
            }
            Console.WriteLine(Math.Abs(sum2-sum1));
        }
    }
}
