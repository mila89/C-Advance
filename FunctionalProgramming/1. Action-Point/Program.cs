using System;

namespace ActionPoint
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ");
            Action<string> PrintName = message => Console.WriteLine(message);
           // PrintName(input);
            
            foreach (var item in input)
            {
                PrintName(item);
            }
        }
    }
}
