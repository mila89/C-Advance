using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rowCount = n[0];
            int colCount = n[1];
            int[,] matrix = ReadInput(rowCount, colCount);
            string[] input = Console.ReadLine().Split(" ");
            while (input[0]!="END")
            {
                if (Validation(matrix, input) && input[0].StartsWith("swap"))
                {
                    int tempInt = matrix[int.Parse(input[1]), int.Parse(input[2])];
                    matrix[int.Parse(input[1]), int.Parse(input[2])] = matrix[int.Parse(input[3]), int.Parse(input[4])];
                    matrix[int.Parse(input[3]), int.Parse(input[4])] = tempInt;
                    PrintMatrix(matrix);
                }
                else
                    Console.WriteLine("Invalid input!");

                
                input = Console.ReadLine().Split(" ");
            }


            static void PrintMatrix(int[,] matrixForPrint)
            {
                int row = matrixForPrint.GetLength(0);
                int col = matrixForPrint.GetLength(1);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrixForPrint[i,j]+" ");
                    }
                    Console.WriteLine();
                }
            }
            static bool Validation(int[ , ] matrix, string[] inputCommand)
            {
                // validation: if the given coordinates are valid
                if (inputCommand.Length!=5)
                    return false;
                if (int.Parse(inputCommand[1])>= matrix.GetLength(0) || int.Parse(inputCommand[1])<0 
                    || int.Parse(inputCommand[2]) >= matrix.GetLength(0) || int.Parse(inputCommand[2]) < 0
                    || int.Parse(inputCommand[3]) >= matrix.GetLength(1) || int.Parse(inputCommand[3]) < 0
                    || int.Parse(inputCommand[4]) >= matrix.GetLength(1) || int.Parse(inputCommand[4]) < 0)
                    return false;
                return true;
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
