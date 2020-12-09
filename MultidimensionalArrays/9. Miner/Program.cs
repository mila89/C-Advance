using System;

namespace Miner
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[,] matrix = ReadInput(n, n);
            int coalsNum = CountCoals(matrix);
            int[] startPlace = FindStart(matrix);
            int row = startPlace[0];
            int col = startPlace[1];
            bool isEnd = false;
 
            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case "up":
                        if (IsValid(matrix, row-1, col))
                        {
                            row--;
                        }
                        break;
                    case "down":
                        if (IsValid(matrix, row + 1, col))
                        {
                            row++;
                        }
                        break;
                    case "right":
                        if (IsValid(matrix, row, col+1))
                        {
                            col++;
                        }
                        break;
                    case "left":
                        if (IsValid(matrix, row, col-1))
                        {
                            col--;
                        }
                        break;
                    default:
                        break;
                }

                if (matrix[row, col] == "c")
                {
                    coalsNum--;
                    matrix[row, col] = "*";
                    if (coalsNum == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({row}, {col})");
                        isEnd = true;
                        break;
                    }
                }
                else if (matrix[row, col] == "e")
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    isEnd = true;
                    //i = directions.Length;
                    break;
                } 
            }
            if (!isEnd)
                Console.WriteLine($"{coalsNum} coals left. ({row}, {col})");


            static int[] FindStart(string[,] matrix)
            {
                int[] result = new int[2];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == "s")
                        {
                            result[0] = i;
                            result[1] = j;
                            return result;
                        }
                    }
                }
                return result;
            }

            static bool IsValid(string[,] matrix, int row, int col)
            {
                if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                    return true;
                else
                    return false;
            }

            static int CountCoals(string[,] matrix)
            {
                int result = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == "c")
                            result++;
                    }
                }
                return result;
            }


            static string[,] ReadInput(int rowCount, int colCount)
            {

                string[,] matrix = new string[rowCount, colCount];
                for (int row = 0; row < rowCount; row++)
                {
                    string[] input = Console.ReadLine().Split(" ");
                    for (int col = 0; col < colCount; col++)
                    {
                        matrix[row, col] = input[col].ToString();
                    }
                }
                return matrix;
            }
        }
    }
}
