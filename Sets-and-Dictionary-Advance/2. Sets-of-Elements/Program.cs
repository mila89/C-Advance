using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsofElements
{
    class Program
    {
        static void Main()
        {
            List<int> first = new List<int>();
            HashSet<int> second = new HashSet<int>();
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            HashSet<int> output = new HashSet<int>();
            for (int i = 0; i < input[0]; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < input[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < first.Count; i++)
            {
                if (second.Contains(first[i])&& !output.Contains(first[i]))
                {
                    Console.Write(first[i] + " ");
                    output.Add(first[i]);
                }
            }
        }
    }
}
