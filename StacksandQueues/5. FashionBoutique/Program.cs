using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rack = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                clothes.Push(input[i]);
            }
            int numRack = 0;
            int piecesRack = 0;
            while (clothes.Count>0)
            {
                int currentPiece= clothes.Pop();
                if ((currentPiece + piecesRack) > rack)
                {
                    clothes.Push(currentPiece);
                    numRack++;
                    piecesRack = 0;
                }
                else if ((currentPiece + piecesRack) == rack)
                {
                    numRack++;
                    piecesRack = 0;
                }
                else if ((currentPiece + piecesRack) < rack)
                {
                    piecesRack += currentPiece;
                    if (clothes.Count == 0)
                        numRack++;
                }
            }
            Console.WriteLine(numRack);
        }
    }
}
