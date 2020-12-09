using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> even = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (even.ContainsKey(num))
                {
                    even[num]++;

                }
                else
                    even.Add(num,1);
            }
            foreach (var item in even)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
