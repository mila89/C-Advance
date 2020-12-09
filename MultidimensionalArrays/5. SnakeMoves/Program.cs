using System;

namespace SnakeMoves
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ");
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            string[,] matrix = new string[rows, cols];
            string snake = Console.ReadLine();
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0 || i == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = snake[index].ToString();
                        index++;
                        if (index >= snake.Length)
                            index = 0;
                    }
                }
                else
                {
                    for (int j = cols-1; j >=0; j--)
                    {
                        matrix[i, j] = snake[index].ToString();
                        index++;
                        if (index >= snake.Length)
                            index = 0;
                    }
                }
            }
            PrintMatrix(matrix);

            static void PrintMatrix(string[,] matrixForPrint)
            {
                int row = matrixForPrint.GetLength(0);
                int col = matrixForPrint.GetLength(1);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrixForPrint[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
