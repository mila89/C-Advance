using System;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main()
        {
            int dimensions = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimensions, dimensions];
            int indexRow = 0;
            int indexCol = -1;

            string direction = "right";
            int num = 1;
            int borderRow = dimensions;
            int borderCol = dimensions;
            int leftBorder = 0;
            int upBorder = 0;
            while (num <= dimensions * dimensions)
            {
                if (direction == "right")
                {
                    indexCol++;
                    for (int j = indexCol; j < borderCol; j++)
                    {
                        matrix[indexRow, j] = num;
                        indexCol++;
                        num++;
                        if (num > dimensions * dimensions)
                            break;
                    }
                    borderCol--;
                    direction = "down";
                    indexCol--;
                }
                if (direction == "down")
                {
                    indexRow++;
                    for (int j = indexRow; j < borderRow; j++)
                    {
                        matrix[indexRow, indexCol] = num;
                        indexRow++;
                        num++;
                        if (num > dimensions * dimensions)
                            break;
                    }
                    borderRow--;
                    indexRow--;
                    direction = "left";
                }
                if (direction == "left")
                {
                    indexCol--;
                    for (int j = indexCol; j >= leftBorder; j--)
                    {
                        matrix[indexRow, j] = num;
                        indexCol--;
                        num++;
                        if (num > dimensions * dimensions)
                            break;
                    }
                    leftBorder++;
                    direction = "up";
                    indexCol++;
                }
                if (direction == "up")
                {
                    indexRow--;
                    for (int j = indexRow; j > upBorder; j--)
                    {
                        matrix[indexRow, indexCol] = num;
                        indexRow--;
                        num++;
                        if (num > dimensions * dimensions)
                            break;
                    }
                    upBorder++;
                    direction = "right";
                    indexRow++;
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
