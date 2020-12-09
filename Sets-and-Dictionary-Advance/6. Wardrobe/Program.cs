using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wordrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                if (wordrobe.ContainsKey(input[0]))
                {
                    string[] clothes = input[1].Split(",");
                    Dictionary<string, int> colorItem = new Dictionary<string, int>();
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        colorItem = wordrobe[input[0]];
                        if (colorItem.ContainsKey(clothes[j]))
                            colorItem[clothes[j]]++;
                        else
                            colorItem.Add(clothes[j], 1);
                    }
                }
                else
                {
                    Dictionary<string, int> colorItem = new Dictionary<string, int>();
                    string[] clothes = input[1].Split(",");
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        if (colorItem.ContainsKey(clothes[j]))
                            colorItem[clothes[j]]++;
                        else
                            colorItem.Add(clothes[j], 1);
                    }
                    wordrobe.Add(input[0], colorItem);
                }
            }
            string[] findCloth = Console.ReadLine().Split(" ");
            bool isFound = false;
            foreach (var item in wordrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {
                    if (isFound == false)
                    {
                        if (item.Key == findCloth[0] && cloth.Key == findCloth[1])
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                            isFound = true;
                        }
                        else
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                    else
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}
