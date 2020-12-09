using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemical = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                for (int j = 0; j < input.Length; j++)
                {
                    chemical.Add(input[j]);
                }
            }
            PrintSet(chemical);

            static void PrintSet(SortedSet<string> set)
            {
                foreach (var item in set)
                {
                    Console.Write(item+" ");
                }
            }
        }
    }
}
