using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main()
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
 
            Action<List<int>> PrintNums = message => Console.WriteLine(string.Join(" ", message));
            Action<string> manipulateNums = com =>
            {

                switch (com)
                {
                    case "add":
                        input = input.Select(n => n + 1).ToList();
                        break;
                    case "multiply":
                        input.Select(n => n * 2).ToList();
                        break;
                    case "subtract":
                        input.Select(n => n - 1);
                        break;
                    case "print":
                        PrintNums(input);
                        break;
                    default:
                        break;
                }                
            };

            while (command != "end")
            {
                manipulateNums(command);
                command = Console.ReadLine();
            }
        }
    }
}
