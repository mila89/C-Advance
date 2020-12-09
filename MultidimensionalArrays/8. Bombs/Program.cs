using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = ReadInput(n, n);
            
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                int[] arr = input[i].Split(",").Select(int.Parse).ToArray();
                int row = int.Parse(arr[0].ToString());
                int col= int.Parse(arr[1].ToString());
                ExplodeBomb(matrix, row, col);
            }
            int sum = 0;
            int aliveCells = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(matrix);

            static void PrintMatrix(int[,] matrixForPrint)
            {
                int row = matrixForPrint.GetLength(0);
                int col = matrixForPrint.GetLength(1);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrixForPrint[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            static void ExplodeBomb(int[,]matrix,int row, int col)
            {
                if (IsValid(matrix, row-1, col-1))
                {
                    if (matrix[row - 1, col - 1]>0)
                        matrix[row - 1, col - 1] -= matrix[row, col];
                }
                if (IsValid(matrix, row-1, col))
                {
                    if (matrix[row - 1, col] > 0)
                        matrix[row - 1, col] -= matrix[row, col];
                }
                if (IsValid(matrix, row - 1, col + 1))
                {
                    if (matrix[row - 1, col + 1] > 0)
                        matrix[row - 1, col + 1] -= matrix[row, col];
                }
                if (IsValid(matrix, row, col - 1))
                {
                    if (matrix[row, col - 1] > 0)
                        matrix[row, col - 1] -= matrix[row, col];
                }
                if (IsValid(matrix, row, col + 1))
                {
                    if (matrix[row, col + 1] > 0)
                        matrix[row, col + 1] -= matrix[row, col];
                }
                if (IsValid(matrix, row + 1, col - 1))
                {
                    if (matrix[row + 1, col-1] > 0)
                        matrix[row + 1, col - 1] -= matrix[row, col];
                }
                if (IsValid(matrix, row + 1, col))
                {
                    if (matrix[row + 1, col] > 0)
                        matrix[row + 1, col] -= matrix[row, col];
                }
                if (IsValid(matrix, row + 1, col + 1))
                {
                    if (matrix[row + 1, col + 1] > 0)
                        matrix[row + 1, col + 1] -= matrix[row, col];
                }
                matrix[row, col] = 0;
            }

            static bool IsValid(int[,] matrix, int row, int col)
            {
                if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                    return true;
                else
                    return false;
            }

            static int[,] ReadInput(int rowCount, int colCount)
            {

                int[,] matrix = new int[rowCount, colCount];
                for (int row = 0; row < rowCount; row++)
                {
                    int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    for (int col = 0; col < colCount; col++)
                    {
                        matrix[row, col] = input[col];
                    }
                }
                return matrix;
            }
        }
    }
}
