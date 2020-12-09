using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rowCount = n[0];
            int colCount = n[1];
            int[,]matrix=ReadInput(rowCount,colCount);
            int maxSum = 0;
            int sum = 0;
            int[,] matrixOutput = new int[3, 3];
            for (int i = 0; i < rowCount-2; i++)
            {
                for (int j = 0; j < colCount-2; j++)
                {
                    int[,] matrixTemp = new int[3, 3];
                    
                    int tempRow = 0;
                    for (int inRow = i; inRow < i+3; inRow++)
                    {
                        int tempCol = 0;
                        for (int inCol = j; inCol < j+3; inCol++)
                        {
                            
                            sum += matrix[inRow, inCol];
                            matrixTemp[tempRow, tempCol]= matrix[inRow, inCol];
                            tempCol++;
                        }
                        tempRow++;
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        matrixOutput = matrixTemp;
                        tempRow = 0;
                    }
                    sum = 0;
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < matrixOutput.GetLength(0); i++)
            {
                for (int j = 0; j < matrixOutput.GetLength(1); j++)
                {
                    Console.Write(matrixOutput[i,j]+" ");
                }
                Console.WriteLine();
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
