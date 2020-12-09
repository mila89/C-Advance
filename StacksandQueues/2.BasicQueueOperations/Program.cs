using System;
using System.Collections.Generic;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main()
        {
            Queue<int> basic = new Queue<int>();
            string[] input = Console.ReadLine().Split(" ");
            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);
            string[] numbers = Console.ReadLine().Split(" ");
            for (int i = 0; i < n; i++)
            {
                basic.Enqueue(int.Parse(numbers[i]));
            }
            for (int i = 0; i < s; i++)
            {
                basic.Dequeue();
            }
            if (basic.Contains(x))
                Console.WriteLine("true");
            else
            {
                if (basic.Count > 0)
                {
                    PrintSmallest(basic);
                }
                else
                    Console.WriteLine("0");
            }

            static void PrintSmallest(Queue<int>qu)
            {
                int num = qu.Dequeue();
                while (qu.Count>0)
                {
                    int number = qu.Dequeue();
                    if (num > number)
                        num = number;
                }
                Console.WriteLine(num);
            }
        }
    }
}
