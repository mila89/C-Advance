using System;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] teritory = new char[n, n];
            Point coordinates = FindCoordinate(teritory, n);
            int row = coordinates.X;
            int col = coordinates.Y;
            int food = 0;
            bool endGame = false;
            while (endGame == false && food < 10)
            {
                string command = Console.ReadLine();
                teritory[row, col] = '.';
                switch (command)
                {
                    case "right":
                        col++;
                        break;
                    case "left":
                        col--;
                        break;
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                    default:
                        break;
                }
                if (IsValidIndex(teritory, row, col))
                {
                    if (teritory[row, col] == '*')
                    {
                        food++;
                    }
                    else if (teritory[row, col] == 'B')
                    {
                        teritory[row, col] = '.';
                        coordinates = FindB(teritory);
                        row = coordinates.X;
                        col = coordinates.Y;
                    }
                    teritory[row, col] = 'S';
                }
                else
                {
                    endGame = true;
                }
            }
            PrintResult(teritory, food, endGame);
        }

        private static void PrintResult(char[,] teritory, int food, bool end)
        {
            if (end)
                Console.WriteLine("Game over!");
            else if (food >= 10)
                Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {food}");
            for (int i = 0; i < teritory.GetLength(0); i++)
            {
                for (int j = 0; j < teritory.GetLength(1); j++)
                {
                    Console.Write(teritory[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static Point FindCoordinate(char[,] teritory, int length)
        {
            Point result = new Point();
            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < length; j++)
                {
                    teritory[i, j] = input[j];
                    if (input[j] == 'S')
                    {
                        result.X = i;
                        result.Y = j;
                    }
                }
            }
            return result;
        }

        private static Point FindB(char[,] teritory)
        {
            Point result = new Point();
            for (int i = 0; i < teritory.GetLength(0); i++)
            {
                for (int j = 0; j < teritory.GetLength(1); j++)
                {
                    if (teritory[i, j] == 'B')
                    {
                        teritory[i, j] = 'S';
                        result.X = i;
                        result.Y = j;
                        break;
                    }
                }
            }
            return result;
        }

        private static bool IsValidIndex(char[,] teritory, int v1, int v2)
        {
            if (v1 >= teritory.GetLength(0) || v2 >= teritory.GetLength(1)|| v1<0 || v2<0)
                return false;
            return true;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
