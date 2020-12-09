using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main()
        {
            int[] rowsCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int row = rowsCols[0];
            int col = rowsCols[1];
            string[,] matrix = ReadInput(row, col);
            string directions = Console.ReadLine();
            rowsCols = FindStart(matrix);
            row = rowsCols[0];
            col = rowsCols[1];

            bool playerWin = false;
            bool playerDied = false;

            for (int i = 0; i < directions.Length; i++)
            {
                matrix[row, col] = ".";
                rowsCols[0] = -1;
                rowsCols[1] = -1;
                switch (directions[i])
                {
                    case 'U':
                        if (IsValid(matrix, row - 1, col))
                        {
                            row--;
                        }
                        else
                        {
                            playerWin = true;
                            SpreadBunny(matrix);
                        }
                        break;
                    case 'D':
                        if (IsValid(matrix, row + 1, col))
                        {
                            row++;
                        }
                        else
                        {
                            playerWin = true;
                            SpreadBunny(matrix);
                        }
                        break;
                    case 'R':
                        if (IsValid(matrix, row, col + 1))
                        {
                            col++;
                        }
                        else
                        {
                            playerWin = true;
                            SpreadBunny(matrix);
                        }
                        break;
                    case 'L':
                        if (IsValid(matrix, row, col - 1))
                        {
                            col--;
                        }
                        else
                        {
                            playerWin = true;
                            SpreadBunny(matrix);
                        }
                        break;
                    default:
                        break;
                }
                if (playerWin)
                    break;
                else
                {
                    if (matrix[row, col] == "B")
                        playerDied = true;
                    else
                        matrix[row, col] = "P";
                    rowsCols = SpreadBunny(matrix);
                    if (rowsCols[0] == row && rowsCols[1] == col)
                    {
                        playerDied = true;
                    }
                    if (playerDied)
                        break;
                }
            }

            if (playerWin)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"won: {row} {col}");
            }
            if (playerDied)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {row} {col}");
            }


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

            static int[] SpreadBunny(string[,] matrix)
            {
                int[] result = new int[2];
                List<Bunny> bunnysList = GetBunnies(matrix);

                for (int i = 0; i < bunnysList.Count; i++)
                {                    
                    result = Spread(matrix, bunnysList[i].x, bunnysList[i].y);
                }
                return result;
            }


            static List<Bunny> GetBunnies(string[,] matrix)
            {
                List<Bunny> bunnysList = new List<Bunny>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == "B")
                        {
                            Bunny currentBunny = new Bunny();
                            currentBunny.x = i;
                            currentBunny.y = j;
                            bunnysList.Add(currentBunny);
                        }
                    }
                }
                return bunnysList;
            }


            static int[] Spread(string[,] matrix, int row, int col)
            {
                int[] result = new int[2];
                result[0] = -1;
                result[1] = -1;
                bool isEnd = false;
                if (IsValid(matrix, row - 1, col))
                {
                    if (matrix[row - 1, col] == "P")
                    {
                        result[0] = row - 1;
                        result[1] = col;
                        isEnd = true;
                    }
                    matrix[row - 1, col] = "B";
                }
                if (IsValid(matrix, row, col - 1))
                {
                    if (matrix[row, col - 1] == "P")
                    {
                        result[0] = row;
                        result[1] = col - 1;
                        isEnd = true;
                    }
                    matrix[row, col - 1] = "B";
                }

                if (IsValid(matrix, row, col + 1))
                {
                    if (matrix[row, col + 1] == "P")
                    {
                        result[0] = row;
                        result[1] = col + 1;
                        isEnd = true;
                    }
                    matrix[row, col + 1] = "B";
                }
                if (IsValid(matrix, row + 1, col))
                {
                    if (matrix[row + 1, col] == "P")
                    {
                        result[0] = row + 1;
                        result[1] = col;
                        isEnd = true;
                    }
                    matrix[row + 1, col] = "B";
                }
                if (isEnd)
                    return result;
                else
                {
                    result[0] = -1;
                    result[1] = -1;
                    return result;
                }
            }


            static bool IsValid(string[,] matrix, int row, int col)
            {
                if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                    return true;
                else
                    return false;
            }

            static int[] FindStart(string[,] matrix)
            {
                int[] result = new int[2];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == "P")
                        {
                            result[0] = i;
                            result[1] = j;
                            matrix[i, j] = ".";
                            return result;
                        }
                    }
                }
                return result;
            }

            static string[,] ReadInput(int rowCount, int colCount)
            {

                string[,] matrix = new string[rowCount, colCount];
                for (int row = 0; row < rowCount; row++)
                {
                    string input = Console.ReadLine();
                    for (int col = 0; col < colCount; col++)
                    {
                        matrix[row, col] = input[col].ToString();
                    }
                }
                return matrix;
            }
        }
    }

    class Bunny
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
