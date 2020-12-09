using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        private static object queque;

        static void Main()
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>();
            int biggestOrder = 0;
            int sumOrders = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (biggestOrder < input[i])
                    biggestOrder = input[i];
                sumOrders += input[i];
                orders.Enqueue(input[i]);
            }
            while (orders.Count>0)
            {
                int tempNum = orders.Dequeue();
                sumOrders -= tempNum;
                if (sumOrders < tempNum)
                    break;                
            }

            Console.WriteLine(biggestOrder);
            if (orders.Count == 0)
                Console.WriteLine("Orders complete");
            else
            {
                Console.Write("Orders left: ");
                while (orders.Count>0)
                {
                    if (orders.Count>1)
                        Console.Write($"{orders.Dequeue()}, ");
                    else
                        Console.Write(orders.Dequeue());
                }
            }
        }
    }
}
