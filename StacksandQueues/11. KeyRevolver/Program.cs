using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>();
            Queue<int> locks = new Queue<int>();
            int inteligenceValue = int.Parse(Console.ReadLine());

            for (int i = 0; i < bulletsInput.Length; i++)
            {
                bullets.Push(bulletsInput[i]);
            }
            for (int i = 0; i < locksInput.Length; i++)
            {
                locks.Enqueue(locksInput[i]);
            }
            int countBarrel = 0;
            while (bullets.Count > 0 && locks.Count>0)
            {
                int currentBullet = bullets.Pop();
                int currenLock = locks.Peek();
                countBarrel++;
                if (currentBullet <= currenLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (countBarrel >= barrelSize && bullets.Count>0 )
                {
                    Console.WriteLine("Reloading!");
                    countBarrel = 0;
                }
            }
            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int priceEarned = inteligenceValue - (bulletsInput.Length - bullets.Count) * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${priceEarned}");
            }

        }
    }
}
