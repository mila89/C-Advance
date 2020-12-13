using System;

namespace Bee
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] teritory = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string rowMatrix = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    teritory[i, j] = rowMatrix[j];
                }
            }
            Point coordinates = FindBee(teritory);
            int row = coordinates.X;
            int col = coordinates.Y;
            int pollinatedFlowers = 0;
            Func<int, int, bool> validCoordinates = (r, c) => (row >= 0 && row < n && col < n && col >= 0);

            string input = Console.ReadLine();
            while (validCoordinates(row,col) && input!="End")
            {
                teritory[row, col] = '.';
                switch (input)
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
                if (validCoordinates(row,col))
                {
                    if (teritory[row, col] == 'f')
                        pollinatedFlowers++;
                    else if (teritory[row, col] == 'O')
                    {
                        teritory[row, col] = '.';
                        if (input == "right")
                            col++;
                        else if (input == "left")
                            col--;
                        else if (input == "down")
                            row++;
                        else if (input == "up")
                            row--;
                        if (teritory[row, col] == 'f')
                            pollinatedFlowers++;
                    }
                    teritory[row, col] = 'B';
                }
                input = Console.ReadLine();
            }
            PrintResult(teritory, row, col,pollinatedFlowers,validCoordinates(row,col));
        }

        private static void PrintResult(char[,] teritory, int row, int col,int pollinatedF, bool validC)
        {
            if (!validC)
                Console.WriteLine("The bee got lost!");
            if (pollinatedF<5)
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinatedF} flowers more");
            else
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedF} flowers!");
            PrintMatrix(teritory);
        }

        private static void PrintMatrix(char[,] teritory)
        {
            for (int i = 0; i < teritory.GetLength(0); i++)
            {
                for (int j = 0; j < teritory.GetLength(1); j++)
                {
                    Console.Write(teritory[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static Point FindBee(char[,] teritory)
        {
            Point result = new Point();
            for (int i = 0; i < teritory.GetLength(0); i++)
            {
                for (int j = 0; j < teritory.GetLength(1); j++)
                {
                    if (teritory[i, j] == 'B')
                        return new Point(i, j);
                }
            }
            return result;
        }
    }

    class Point
    {
        public Point()
        {

        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
