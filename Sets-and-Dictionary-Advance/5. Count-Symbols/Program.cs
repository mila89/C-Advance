using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (occurrences.ContainsKey(input[i]))
                    occurrences[input[i]]++;
                else
                    occurrences.Add(input[i], 1);
            }
            foreach (var item in occurrences)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
