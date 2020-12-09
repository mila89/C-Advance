using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsandBottles
{
    class Program
    {
        static void Main()
        {
            int[] cupsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>();
            Stack<int> bottles = new Stack<int>();
            for (int i = 0; i < cupsInput.Length; i++)
            {
                cups.Enqueue(cupsInput[i]);
            }
            for (int i = 0; i < bottlesInput.Length; i++)
            {
                bottles.Push(bottlesInput[i]);
            }
            int wastedWater = 0;
            while (cups.Count>0 && bottles.Count>0)
            {
                
                int currentCup = cups.Peek();
                while (currentCup>0 && bottles.Count>0)
                {
                    int currentBottle = bottles.Pop();
                    if (currentBottle - currentCup >= 0)
                    {
                        cups.Dequeue();
                        wastedWater += currentBottle - currentCup;
                        currentCup -= currentBottle;
                    }
                    else 
                    {
                        currentCup -= currentBottle;
                    }

                }  
            }
            if (bottles.Count > 0)
            {
                Console.Write("Bottles: ");
               while (bottles.Count>0)
                {
                    Console.Write(bottles.Pop()+" ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("Cups: ");
                while (cups.Count>0)
                {
                    Console.Write(cups.Dequeue()+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
