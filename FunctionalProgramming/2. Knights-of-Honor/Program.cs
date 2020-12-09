using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsofHonor
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split().ToList();
            input = input.Select(name=>$"Sir {name}").ToList();
            Action<string[]> PrintName = message => Console.WriteLine(string.Join(Environment.NewLine, message));
            PrintName(input.ToArray());
        }
    }
}
