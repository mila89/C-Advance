using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> bombEffects = new Queue<int>(input);

            input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> bombCasing = new Stack<int>(input);
            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;
            while (bombCasing.Count > 0 && bombEffects.Count > 0)
            {
                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
                    break;
                int effect = bombEffects.Peek();
                int casing = bombCasing.Pop();
                if (effect + casing == 40)
                {
                    daturaBombs++;
                    bombEffects.Dequeue();
                }
                else if (effect + casing == 60)
                {
                    cherryBombs++;
                    bombEffects.Dequeue();
                }
                else if (effect + casing == 120)
                {
                    smokeDecoyBombs++;
                    bombEffects.Dequeue();
                }
                else
                {
                    casing -= 5;
                    bombCasing.Push(casing);
                }
            }
            PrintResult(bombEffects, bombCasing, daturaBombs, cherryBombs, smokeDecoyBombs);
        }

        static void PrintResult(Queue<int> bombEffects, Stack<int> bombCasing, int daturaBombs, int cherryBombs, int smokeDecoyBombs)
        {
            if (daturaBombs > 2 && cherryBombs > 2 && smokeDecoyBombs > 2)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            if (bombEffects.Count == 0)
                Console.WriteLine("Bomb Effects: empty");
            else
            {
                Console.Write("Bomb Effects: ");
                while (bombEffects.Count > 0)
                {
                    if (bombEffects.Count > 1)
                        Console.Write($"{bombEffects.Dequeue()}, ");
                    else
                        Console.Write($"{bombEffects.Dequeue()}");
                }
                Console.WriteLine();
            }
            if (bombCasing.Count == 0)
                Console.WriteLine("Bomb Casings: empty");
            else
            {
                Console.Write("Bomb Casings: ");
                while (bombCasing.Count > 0)
                {
                    if (bombCasing.Count > 1)
                        Console.Write($"{bombCasing.Pop()}, ");
                    else
                        Console.Write($"{bombCasing.Pop()}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
