using System;

namespace KnightGame
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix=ReadInput(n, n);
            int deletedKnight = 0;
            for (int i = 8; i >0; i--)
            {
                for (int x = 0; x <n ; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        if (matrix[x, y] == "K")
                        {
                            if (AttackNums(matrix, x, y) == i)
                            {
                                matrix[x, y] = "0";
                                deletedKnight++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(deletedKnight);


            static int AttackNums(string[,] matrix, int row, int col)
            {
                int matrixBorder = matrix.GetLength(0);
                int result = 0;
                if (row - 2 >= 0 && col - 1 >= 0)
                    if (matrix[row - 2, col - 1] == "K")
                        result++;

                if (row - 1 >= 0 && col - 2 >= 0)
                    if (matrix[row - 1, col - 2] == "K")
                        result++;

                if (row - 2 >= 0 && col + 1 <matrixBorder)
                    if (matrix[row - 2, col + 1] == "K")
                        result++;

                if (row - 1 >= 0 && col +2 < matrixBorder)
                    if (matrix[row -1, col +2] == "K")
                        result++;
                if (row + 2 < matrixBorder && col - 1 >= 0)
                    if (matrix[row + 2, col - 1] == "K")
                        result++;

                if (row + 1 < matrixBorder && col - 2 >= 0)
                    if (matrix[row + 1, col - 2] == "K")
                        result++;

                if (row +1 < matrixBorder && col +2 < matrixBorder)
                    if (matrix[row +1, col +2] == "K")
                        result++;

                if (row + 2 < matrixBorder && col + 1 < matrixBorder)
                    if (matrix[row +2, col + 1] == "K")
                        result++;

               


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
}
