using System;
using System.Collections;
using System.Collections.Generic;

namespace BasicStackOperations
{
    class Program
    {
        static void Main()
        {
            Stack<int> basic = new Stack<int>();
            string[] input = Console.ReadLine().Split(" ");
            int n = int.Parse(input[0]);
            int s= int.Parse(input[1]);
            int x = int.Parse(input[2]);
            string[] numbers = Console.ReadLine().Split(" ");
            for (int i = 0; i < n; i++)
            {
                basic.Push(int.Parse(numbers[i]));
            }
            for (int i = 0; i < s; i++)
            {
                basic.Pop();
            }
            if (basic.Contains(x))
                Console.WriteLine("true");
            else
            {
                if (basic.Count>0)
                    Console.WriteLine($"{basic.Pop()}");
                else
                    Console.WriteLine("0");
            }
        }
    }
}
