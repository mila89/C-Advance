using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                jagged[i]= Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            }
            jagged = AnaliseArray(jagged);
            string[] input = Console.ReadLine().Split(" ");
            while (input[0]!="End")
            {
                jagged = OperateValue(jagged, int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]), input[0]);
                input = Console.ReadLine().Split(" ");
            }
            PrintArray(jagged);





            static void PrintArray(double[][] matrixForPrint)
            {
                int row = matrixForPrint.GetLength(0);
                for (int i = 0; i < row; i++)
                {
                    int col = matrixForPrint[i].Length;
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrixForPrint[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            static double[][] OperateValue(double[][] jagged, int row,int col, int value, string operation)
            {
                if (row < jagged.GetLength(0) && row >= 0 && col < jagged[row].Length && col >= 0)
                {
                    if (operation=="Add")
                        jagged[row][col] += value;
                    else if (operation=="Subtract")
                        jagged[row][col] -= value;
                }           
                return jagged;
            }

            static double[][] AnaliseArray(double[][] jagged)
            {
                for (int i = 0; i < jagged.GetLength(0) - 1; i++)
                {
                    if (jagged[i].Length == jagged[i + 1].Length)
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j] *= 2;
                            jagged[i + 1][j] *= 2;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j]=jagged[i][j]/2;
                        }
                        for (int j = 0; j < jagged[i+1].Length; j++)
                        {
                            jagged[i + 1][j] = jagged[i + 1][j] / 2;
                        }
                    }
                }
                return jagged;
            }
            
            
        }
    }
}
