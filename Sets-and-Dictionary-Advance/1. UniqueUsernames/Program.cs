﻿using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main()
        {
            HashSet<string> names = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}