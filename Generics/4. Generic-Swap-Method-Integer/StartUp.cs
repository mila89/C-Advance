using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SwapElements(list, input[0], input[1]);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        static void SwapElements<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
