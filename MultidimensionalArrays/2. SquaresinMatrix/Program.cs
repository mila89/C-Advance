using System;
using System.Linq;

namespace SquaresinMatrix
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            string[,] matrix = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                string[] inputMatrix = Console.ReadLine().Split(" ");
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = inputMatrix[j];
                }
            }
            int countSquares = 0;
            for (int i = 0; i < row-1; i++)
            {
                for (int j = 0; j < col-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        string temp = matrix[i, j];
                        if (matrix[i+1,j]==temp && matrix[i+1,j+1]==temp)
                            countSquares++;
                    }
                }
            }
            Console.WriteLine(countSquares);
        }
    }
}
